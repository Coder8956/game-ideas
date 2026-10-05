using UnityEngine;
using UnityEngine.AI;
using UGU.Runtime.FSM;

namespace UGU.Runtime
{
    /// <summary>
    /// 敌方坦克巡逻控制器：基于 <see cref="FSMMachineBehaviour"/> 的有限状态机实现，
    /// 使用 NavMeshAgent 在场景中循环前往随机目标点，
    /// 每次选点保证目标点与起点（当前位置）的距离不小于 m_minDestinationDistance。
    /// 运动流程为「先转向、再运动，二者不可同时进行」：
    /// <para>1. 到达选点后先原地转向对准目标方向（轮子呈现原地转向滚动）；</para>
    /// <para>2. 对准后再沿路径前进（轮子呈现前进滚动）；</para>
    /// <para>3. 运动中若发现朝向偏离路径方向，先停下转向、对准后再继续移动。</para>
    /// 状态机流转：等待 NavMesh 就绪 → 选点 → 转向 → 前进（到达/路径失效 → 重新选点；
    /// 选点失败 → 短暂等待后重试）。状态切换由 <see cref="FSMMachine"/> 统一驱动。
    /// 轮子滚动复用 <see cref="UGTankWheels"/> 组件，表现与玩家坦克一致。
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class UGTankEnemyBrain : FSMMachineBehaviour
    {
        /// <summary>巡逻状态机状态 ID</summary>
        private enum BrainState
        {
            /// <summary>等待 NavMesh 就绪（代理未上网格时停留于此）</summary>
            WaitingForNavMesh,

            /// <summary>选点：在巡逻半径内采样一个可达目标点</summary>
            PickingDestination,

            /// <summary>原地转向，对准目标方向（代理暂停移动）</summary>
            Turning,

            /// <summary>沿路径前进（不进行任何转向）</summary>
            Moving,

            /// <summary>选点失败后的短暂等待，计时结束重新选点</summary>
            Waiting,
        }

        [Header("巡逻")]
        [Tooltip("随机目标点的采样半径（米）")]
        [SerializeField]
        private float m_patrolRadius = 30f;

        [Tooltip("目标点与当前位置的最小距离（米）")]
        [SerializeField]
        private float m_minDestinationDistance = 5f;

        [Tooltip("每次选点的采样尝试次数")]
        [SerializeField]
        private int m_sampleAttempts = 20;

        [Header("组件")]
        [Tooltip("导航代理；留空自动获取")]
        [SerializeField]
        private NavMeshAgent m_agent;

        [Tooltip("轮子滚动组件（仅表现用）；留空自动获取本物体或子物体上的 UGTankWheels")]
        [SerializeField]
        private UGTankWheels m_wheels;

        /// <summary>转向对准的判定容差（度），达到该偏差内视为已对准</summary>
        private const float TurnTolerance = 3f;

        /// <summary>运动中允许的最大朝向偏差（度），超过则停下重新转向</summary>
        private const float HeadingTolerance = 5f;

        /// <summary>选点失败后的重试间隔（秒）</summary>
        private const float RetryInterval = 0.5f;

        /// <summary>路径缓存，用于校验目标点可达性</summary>
        private NavMeshPath m_path;

        /// <summary>上一帧的 Y 轴朝向，用于计算实际转向角速度</summary>
        private float m_lastYaw;

        /// <summary>最近一次选点是否成功；由 PickingDestination 状态写入，转移条件据此放行</summary>
        private bool m_destinationPicked;

        /// <summary>选点失败后的重试倒计时</summary>
        private float m_retryTimer;

        private void Start()
        {
            if (m_agent == null) m_agent = GetComponent<NavMeshAgent>();
            if (m_wheels == null) m_wheels = GetComponent<UGTankWheels>() ?? GetComponentInChildren<UGTankWheels>();

            if (m_agent == null)
            {
                Debug.LogWarning($"{name}: 缺少 NavMeshAgent 组件，巡逻未开始。", this);
                return;
            }

            if (m_wheels == null)
                Debug.LogWarning($"{name}: 缺少 UGTankWheels 组件，轮子滚动动画不可用（巡逻仍正常进行）。", this);

            m_path = new NavMeshPath();
            m_lastYaw = transform.eulerAngles.y;

            // 关闭代理自动转向：朝向完全由状态机控制（先转向、后运动）
            m_agent.updateRotation = false;

            // —— 注册状态 ——
            Machine.AddState(BrainState.WaitingForNavMesh, new WaitingForNavMeshState(this));
            Machine.AddState(BrainState.PickingDestination, new PickingDestinationState(this));
            Machine.AddState(BrainState.Turning, new TurningState(this));
            Machine.AddState(BrainState.Moving, new MovingState(this));
            Machine.AddState(BrainState.Waiting, new WaitingState(this));

            // —— 注册转移 ——
            // NavMesh 就绪后开始选点
            Machine.AddTransition(BrainState.WaitingForNavMesh, BrainState.PickingDestination,
                () => m_agent != null && m_agent.isOnNavMesh);

            // 选点成功 → 原地转向；失败 → 短暂等待后重试
            Machine.AddTransition(BrainState.PickingDestination, BrainState.Turning,
                () => m_destinationPicked);
            Machine.AddTransition(BrainState.PickingDestination, BrainState.Waiting,
                () => !m_destinationPicked);
            Machine.AddTransition(BrainState.Waiting, BrainState.PickingDestination,
                () => m_retryTimer <= 0f);

            // 转向期间：若路径已完成/失效，优先重新选点；对准后才放行前进
            Machine.AddTransition(BrainState.Turning, BrainState.PickingDestination,
                () => HasArrived() || IsPathInvalid());
            Machine.AddTransition(BrainState.Turning, BrainState.Moving,
                () => IsAligned());

            // 前进期间：到达/路径失效优先重新选点；偏离航向则停下重新转向
            Machine.AddTransition(BrainState.Moving, BrainState.PickingDestination,
                () => HasArrived() || IsPathInvalid());
            Machine.AddTransition(BrainState.Moving, BrainState.Turning,
                () => HeadingDeviated());

            // 调试日志：输出状态切换，不需要可删除
            // Machine.StateChanged += (from, to) =>
            //     Debug.Log($"[UGTankEnemyBrain] {from?.ToString() ?? "无"} → {to}", this);

            StartMachine(BrainState.WaitingForNavMesh);
        }

        /// <summary>是否已到达当前目标（或代理当前无路径）。</summary>
        private bool HasArrived()
        {
            return !m_agent.pathPending
                && (!m_agent.hasPath || m_agent.remainingDistance <= m_agent.stoppingDistance + 0.1f);
        }

        /// <summary>当前路径是否已失效。</summary>
        private bool IsPathInvalid() => m_agent.pathStatus == NavMeshPathStatus.PathInvalid;

        /// <summary>
        /// 是否已对准目标朝向（纯判定，不执行旋转，供转移条件使用）。
        /// </summary>
        private bool IsAligned()
        {
            return Quaternion.Angle(transform.rotation, Quaternion.Euler(0f, GetTargetYaw(), 0f)) <= TurnTolerance;
        }

        /// <summary>运动中朝向是否偏离路径方向超过 <see cref="HeadingTolerance"/>。</summary>
        private bool HeadingDeviated()
        {
            return Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, GetTargetYaw())) > HeadingTolerance;
        }

        /// <summary>
        /// 原地转向至目标朝向；返回是否已对准（对准后会将朝向精确归位）。
        /// </summary>
        private bool TurnTowards(float targetYaw)
        {
            var targetRot = Quaternion.Euler(0f, targetYaw, 0f);
            if (Quaternion.Angle(transform.rotation, targetRot) <= TurnTolerance)
            {
                transform.rotation = targetRot;
                return true;
            }

            var turnSpeed = m_agent != null ? m_agent.angularSpeed : 120f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
            return false;
        }

        /// <summary>
        /// 计算当前需要对准的目标朝向：优先取路径下一个拐点方向，否则取目标点方向。
        /// </summary>
        private float GetTargetYaw()
        {
            var dir = m_agent.steeringTarget - transform.position;
            dir.y = 0f;
            if (dir.sqrMagnitude < 0.01f)
            {
                dir = m_agent.destination - transform.position;
                dir.y = 0f;
            }

            if (dir.sqrMagnitude < 0.01f) return transform.eulerAngles.y;
            return Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        }

        /// <summary>
        /// 在巡逻半径内采样一个与当前位置距离 ≥ minDestinationDistance、
        /// 且在 NavMesh 上路径完整可达的目标点；找到则设置给代理并返回 true。
        /// </summary>
        private bool TryPickDestination()
        {
            for (var i = 0; i < m_sampleAttempts; i++)
            {
                if (TrySampleDestination(m_patrolRadius, m_minDestinationDistance, out var point)
                    && m_agent.CalculatePath(point, m_path)
                    && m_path.status == NavMeshPathStatus.PathComplete)
                {
                    m_agent.SetDestination(point);

                    // 先转向后运动：转向期间暂停移动（Turning 状态进入时也会重申）
                    m_agent.isStopped = true;
                    return true;
                }
            }

            Debug.LogWarning($"{name}: 未能在 {m_patrolRadius}m 半径内找到可达且距起点 ≥{m_minDestinationDistance}m 的目标点，稍后重试。", this);
            return false;
        }

        /// <summary>
        /// 在随机水平方向、随机半径处采样 NavMesh 上的位置，并校验与起点的距离。
        /// </summary>
        private bool TrySampleDestination(float radius, float minDist, out Vector3 point)
        {
            var origin = transform.position;

            var dir = Random.insideUnitSphere;
            dir.y = 0f;
            if (dir.sqrMagnitude < 0.0001f) dir = Vector3.forward;
            dir.Normalize();

            var target = origin + dir * Random.Range(minDist, radius);
            if (NavMesh.SamplePosition(target, out var hit, 10f, NavMesh.AllAreas))
            {
                point = hit.position;
                return Vector3.Distance(point, origin) >= minDist;
            }

            point = Vector3.zero;
            return false;
        }

        /// <summary>等待 NavMesh 就绪；就绪后由转移条件放行到选点。</summary>
        private sealed class WaitingForNavMeshState : FSMState
        {
            private readonly UGTankEnemyBrain m_owner;

            public WaitingForNavMeshState(UGTankEnemyBrain owner) => m_owner = owner;

            public override void OnEnter()
            {
                if (!m_owner.m_agent.isOnNavMesh)
                    Debug.LogWarning($"{m_owner.name}: NavMeshAgent 未就绪或场景未烘焙 NavMesh，等待就绪后自动开始巡逻。请在 Navigation 窗口烘焙导航网格。", m_owner);
            }
        }

        /// <summary>选点：进入时采样可达目标点；成功/失败由转移条件分别放行到转向/等待。</summary>
        private sealed class PickingDestinationState : FSMState
        {
            private readonly UGTankEnemyBrain m_owner;

            public PickingDestinationState(UGTankEnemyBrain owner) => m_owner = owner;

            public override void OnEnter()
            {
                m_owner.m_destinationPicked = m_owner.TryPickDestination();
            }
        }

        /// <summary>原地转向：暂停代理并驱动轮子呈现转向滚动；对准后由转移条件放行到前进。</summary>
        private sealed class TurningState : FSMState
        {
            private readonly UGTankEnemyBrain m_owner;

            public TurningState(UGTankEnemyBrain owner) => m_owner = owner;

            public override void OnEnter()
            {
                m_owner.m_agent.isStopped = true;
                m_owner.m_lastYaw = m_owner.transform.eulerAngles.y;
            }

            public override void OnUpdate(float deltaTime)
            {
                if (m_owner.m_wheels == null) return;

                if (m_owner.TurnTowards(m_owner.GetTargetYaw()))
                    return; // 已对准：本轮不再驱动轮子，切换交由转移条件

                var yaw = m_owner.transform.eulerAngles.y;
                var turnRate = Mathf.DeltaAngle(m_owner.m_lastYaw, yaw) / Mathf.Max(deltaTime, 1e-4f);
                m_owner.m_lastYaw = yaw;
                m_owner.m_wheels.Drive(0f, turnRate);
            }
        }

        /// <summary>前进：放行代理并驱动轮子呈现前进滚动；到达/失效/偏离航向由转移条件处理。</summary>
        private sealed class MovingState : FSMState
        {
            private readonly UGTankEnemyBrain m_owner;

            public MovingState(UGTankEnemyBrain owner) => m_owner = owner;

            public override void OnEnter()
            {
                m_owner.m_agent.isStopped = false;
                m_owner.m_lastYaw = m_owner.transform.eulerAngles.y;
            }

            public override void OnUpdate(float deltaTime)
            {
                if (m_owner.m_wheels == null) return;

                var yaw = m_owner.transform.eulerAngles.y;
                m_owner.m_lastYaw = yaw;
                m_owner.m_wheels.Drive(Vector3.Dot(m_owner.m_agent.velocity, m_owner.transform.forward), 0f);
            }
        }

        /// <summary>选点失败后的短暂等待：计时结束后由转移条件放行到重新选点。</summary>
        private sealed class WaitingState : FSMState
        {
            private readonly UGTankEnemyBrain m_owner;

            public WaitingState(UGTankEnemyBrain owner) => m_owner = owner;

            public override void OnEnter() => m_owner.m_retryTimer = RetryInterval;

            public override void OnUpdate(float deltaTime) => m_owner.m_retryTimer -= deltaTime;
        }
    }
}
