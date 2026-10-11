using System.Collections.Generic;
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
    /// <para>避让：本物体上的 Trigger 碰撞体（Collider.isTrigger = true）检测到 Tag 为
    /// Enemy 或 Player 的对象进入范围时，任意状态转移打断当前行为进入避让状态——
    /// 范围内存在玩家则直接远离玩家（所有敌方坦克都远离玩家）；均为敌方坦克时按基本
    /// 交通规则（靠右行驶）互相避让；威胁离开触发器后恢复到进入避让前的状态继续巡逻。</para>
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

            /// <summary>避让：Enemy/Player 进入 Trigger 范围后打断当前行为，按规则避让</summary>
            Avoiding,
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

        [Header("避让")]
        [Tooltip("避让目标点与当前位置的距离（米）")]
        [SerializeField]
        private float m_avoidDistance = 6f;

        [Tooltip("避让期间重新计算避让方向的间隔（秒），用于跟随移动中的目标")]
        [SerializeField]
        private float m_avoidRecomputeInterval = 0.25f;

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

        /// <summary>处于避让触发器范围内的威胁（Tag 为 Enemy 或 Player 的碰撞体）</summary>
        private readonly List<Collider> m_threats = new List<Collider>();

        /// <summary>进入避让前的状态；威胁离开触发器后据此恢复</summary>
        private BrainState m_stateBeforeAvoid;

        /// <summary>避让方向重算倒计时</summary>
        private float m_avoidRecomputeTimer;

        /// <summary>当前避让目标点（已采样到 NavMesh 上）</summary>
        private Vector3 m_avoidPoint;

        /// <summary>当前避让朝向（避让目标点方向的角度）</summary>
        private float m_avoidYaw;

        /// <summary>进入避让前代理是否持有巡逻目标点，用于避让结束后恢复</summary>
        private bool m_savedHasPath;

        /// <summary>进入避让前代理的巡逻目标点</summary>
        private Vector3 m_savedDestination;

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

            // 避让检测依赖 Trigger 碰撞体与刚体，缺一不可
            var trigger = GetComponent<Collider>();
            if (trigger == null || !trigger.isTrigger)
                Debug.LogWarning($"{name}: 缺少 Trigger 碰撞体（Collider.isTrigger = true），避让检测不可用。请在根物体上添加触发器并勾选 Is Trigger。", this);
            if (GetComponent<Rigidbody>() == null)
                Debug.LogWarning($"{name}: 缺少 Rigidbody 组件，Trigger 事件不会触发，避让检测不可用。", this);

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
            Machine.AddState(BrainState.Avoiding, new AvoidingState(this));

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

            // 任意状态转移（优先于普通转移求值）：Enemy/Player 进入 Trigger 范围 → 打断当前行为进入避让
            Machine.AddAnyTransition(BrainState.Avoiding, () => HasAvoidThreat());

            // 避让结束（威胁离开 Trigger 范围）→ 恢复到进入避让前的状态
            Machine.AddTransition(BrainState.Avoiding, BrainState.Moving,
                () => !HasAvoidThreat() && m_stateBeforeAvoid == BrainState.Moving);
            Machine.AddTransition(BrainState.Avoiding, BrainState.Turning,
                () => !HasAvoidThreat() && m_stateBeforeAvoid == BrainState.Turning);
            Machine.AddTransition(BrainState.Avoiding, BrainState.Waiting,
                () => !HasAvoidThreat() && m_stateBeforeAvoid == BrainState.Waiting);
            Machine.AddTransition(BrainState.Avoiding, BrainState.WaitingForNavMesh,
                () => !HasAvoidThreat() && m_stateBeforeAvoid == BrainState.WaitingForNavMesh);
            Machine.AddTransition(BrainState.Avoiding, BrainState.PickingDestination,
                () => !HasAvoidThreat() && m_stateBeforeAvoid != BrainState.Moving
                    && m_stateBeforeAvoid != BrainState.Turning
                    && m_stateBeforeAvoid != BrainState.Waiting
                    && m_stateBeforeAvoid != BrainState.WaitingForNavMesh);

            // 记录进入避让前的状态，供避让结束后恢复
            Machine.StateChanged += (from, to) =>
            {
                if (to != null && to.Equals(BrainState.Avoiding) && from != null)
                    m_stateBeforeAvoid = (BrainState)from;
            };

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

        // —— 避让检测：基于本物体上的 Trigger 碰撞体（Collider.isTrigger = true）——

        /// <summary>进入 Trigger 范围：仅关注 Tag 为 Enemy 或 Player 的对象。</summary>
        private void OnTriggerEnter(Collider other)
        {
            if (IsAvoidThreat(other) && !m_threats.Contains(other))
                m_threats.Add(other);
        }

        /// <summary>离开 Trigger 范围：从威胁列表中移除。</summary>
        private void OnTriggerExit(Collider other)
        {
            m_threats.Remove(other);
        }

        /// <summary>是否为需要避让的威胁（Tag 为 Enemy 或 Player）。</summary>
        private static bool IsAvoidThreat(Collider other)
        {
            return other != null && (other.CompareTag("Enemy") || other.CompareTag("Player"));
        }

        /// <summary>范围内是否存在威胁；顺带清理已被销毁的碰撞体。</summary>
        private bool HasAvoidThreat()
        {
            for (var i = m_threats.Count - 1; i >= 0; i--)
            {
                if (m_threats[i] == null) m_threats.RemoveAt(i);
            }

            return m_threats.Count > 0;
        }

        /// <summary>
        /// 计算并缓存当前避让目标点与朝向，并设置给代理。
        /// 玩家优先：范围内存在玩家时直接远离玩家（满足“所有敌方坦克都远离玩家”）；
        /// 否则对每个敌方坦克按基本交通规则（靠右行驶）互相避让。
        /// </summary>
        private void RecomputeAvoidance()
        {
            var origin = transform.position;
            var dir = ComputeAvoidDirection(origin);
            m_avoidPoint = SampleAvoidPoint(origin, dir);
            m_avoidYaw = GetYawTowards(origin, m_avoidPoint);
            m_agent.SetDestination(m_avoidPoint);
        }

        /// <summary>
        /// 计算避让方向：范围内存在玩家 → 远离最近的玩家（玩家优先）；
        /// 全部为敌方坦克 → 远离对方并叠加自身右侧偏置（“靠右行驶”交通规则，双方错身通过）。
        /// </summary>
        private Vector3 ComputeAvoidDirection(Vector3 origin)
        {
            // 玩家优先：取最近的玩家，直接远离
            Transform player = null;
            var playerSqrDistance = float.MaxValue;
            foreach (var threat in m_threats)
            {
                if (threat == null || !threat.CompareTag("Player")) continue;
                var sqrDistance = (threat.transform.position - origin).sqrMagnitude;
                if (sqrDistance < playerSqrDistance)
                {
                    playerSqrDistance = sqrDistance;
                    player = threat.transform;
                }
            }

            if (player != null)
            {
                var toPlayer = player.position - origin;
                toPlayer.y = 0f;
                return toPlayer.sqrMagnitude > 0.0001f ? -toPlayer.normalized : transform.forward;
            }

            // 全部为敌方坦克：基本交通规则避让（远离对方 + 自身右侧偏置）
            var sum = Vector3.zero;
            var count = 0;
            foreach (var threat in m_threats)
            {
                if (threat == null) continue;
                var toOther = threat.transform.position - origin;
                toOther.y = 0f;
                if (toOther.sqrMagnitude > 0.0001f)
                {
                    sum += -toOther.normalized + transform.right;
                    count++;
                }
            }

            if (count == 0) return transform.forward;
            var dir = sum / count;
            dir.y = 0f;
            return dir.sqrMagnitude > 0.0001f ? dir.normalized : transform.forward;
        }

        /// <summary>把避让目标点采样到 NavMesh 上；失败时在避让方向近处回退采样，仍失败则原地等待。</summary>
        private Vector3 SampleAvoidPoint(Vector3 origin, Vector3 dir)
        {
            var target = origin + dir.normalized * m_avoidDistance;
            if (NavMesh.SamplePosition(target, out var hit, m_avoidDistance, NavMesh.AllAreas))
                return hit.position;

            if (NavMesh.SamplePosition(origin + dir.normalized * 2f, out hit, 5f, NavMesh.AllAreas))
                return hit.position;

            return origin;
        }

        /// <summary>计算从 from 指向 to 的朝向角（Y 轴欧拉角）；两点几乎重合时保持当前朝向。</summary>
        private float GetYawTowards(Vector3 from, Vector3 to)
        {
            var dir = to - from;
            dir.y = 0f;
            if (dir.sqrMagnitude < 0.01f) return transform.eulerAngles.y;
            return Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
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

        /// <summary>
        /// 避让：Enemy/Player 进入 Trigger 范围后由任意状态转移打断进入。
        /// 玩家优先直接远离；敌方坦克间按“靠右行驶”交通规则互相避让。
        /// 与巡逻一致采用「先转向、再运动」：先原地转向避让朝向，对准后向避让点前进。
        /// 威胁离开触发器后由转移条件恢复到进入避让前的状态。
        /// </summary>
        private sealed class AvoidingState : FSMState
        {
            private readonly UGTankEnemyBrain m_owner;

            public AvoidingState(UGTankEnemyBrain owner) => m_owner = owner;

            public override void OnEnter()
            {
                // 保存巡逻目标点，避让结束后恢复；暂停代理，先原地转向避让方向
                m_owner.m_savedHasPath = m_owner.m_agent.hasPath;
                m_owner.m_savedDestination = m_owner.m_agent.hasPath ? m_owner.m_agent.destination : Vector3.zero;
                m_owner.m_agent.isStopped = true;
                m_owner.m_lastYaw = m_owner.transform.eulerAngles.y;
                m_owner.m_avoidRecomputeTimer = 0f;
                m_owner.RecomputeAvoidance();
            }

            public override void OnUpdate(float deltaTime)
            {
                // 定时重算避让方向，跟随移动中的目标（威胁已离开时由转移条件接管恢复）
                m_owner.m_avoidRecomputeTimer -= deltaTime;
                if (m_owner.m_avoidRecomputeTimer <= 0f)
                {
                    m_owner.RecomputeAvoidance();
                    m_owner.m_avoidRecomputeTimer = m_owner.m_avoidRecomputeInterval;
                }

                // 先转向：未对准时暂停移动、原地旋转，驱动轮子呈现转向滚动
                if (!m_owner.TurnTowards(m_owner.m_avoidYaw))
                {
                    m_owner.m_agent.isStopped = true;
                    if (m_owner.m_wheels == null) return;
                    var yaw = m_owner.transform.eulerAngles.y;
                    var turnRate = Mathf.DeltaAngle(m_owner.m_lastYaw, yaw) / Mathf.Max(deltaTime, 1e-4f);
                    m_owner.m_lastYaw = yaw;
                    m_owner.m_wheels.Drive(0f, turnRate);
                    return;
                }

                // 已对准：放行代理向避让点前进，驱动轮子呈现前进滚动
                m_owner.m_agent.isStopped = false;
                if (m_owner.m_wheels == null) return;
                var forwardYaw = m_owner.transform.eulerAngles.y;
                m_owner.m_lastYaw = forwardYaw;
                m_owner.m_wheels.Drive(Vector3.Dot(m_owner.m_agent.velocity, m_owner.transform.forward), 0f);
            }

            public override void OnExit()
            {
                // 恢复进入避让前保存的巡逻目标点，使巡逻无感续跑
                if (m_owner.m_savedHasPath)
                    m_owner.m_agent.SetDestination(m_owner.m_savedDestination);
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
