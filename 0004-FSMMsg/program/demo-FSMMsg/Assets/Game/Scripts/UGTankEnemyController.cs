using UnityEngine;
using UnityEngine.AI;

namespace UGU.Runtime
{
    /// <summary>
    /// 敌方坦克巡逻控制器：使用 NavMeshAgent 在场景中循环前往随机目标点，
    /// 每次选点保证目标点与起点（当前位置）的距离不小于 m_minDestinationDistance。
    /// 运动流程为「先转向、再运动，二者不可同时进行」：
    /// <para>1. 到达选点后先原地转向对准目标方向（轮子呈现原地转向滚动）；</para>
    /// <para>2. 对准后再沿路径前进（轮子呈现前进滚动）；</para>
    /// <para>3. 运动中若发现朝向偏离路径方向，先停下转向、对准后再继续移动。</para>
    /// 轮子滚动复用 <see cref="UGTankWheels"/> 组件，表现与玩家坦克一致。
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class UGTankEnemyController : MonoBehaviour
    {
        /// <summary>巡逻状态：先转向、后运动</summary>
        private enum PatrolState
        {
            /// <summary>原地转向，对准目标方向（代理暂停移动）</summary>
            Turning,

            /// <summary>沿路径前进（不进行任何转向）</summary>
            Moving,
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

        [Tooltip("轮子滚动组件；留空自动获取本物体或子物体上的 UGTankWheels")]
        [SerializeField]
        private UGTankWheels m_wheels;

        /// <summary>转向对准的判定容差（度），达到该偏差内视为已对准</summary>
        private const float TurnTolerance = 3f;

        /// <summary>运动中允许的最大朝向偏差（度），超过则停下重新转向</summary>
        private const float HeadingTolerance = 5f;

        /// <summary>路径缓存，用于校验目标点可达性</summary>
        private NavMeshPath m_path;

        /// <summary>上一帧的 Y 轴朝向，用于计算实际转向角速度</summary>
        private float m_lastYaw;

        /// <summary>当前巡逻状态</summary>
        private PatrolState m_state = PatrolState.Turning;

        private void Start()
        {
            if (m_agent == null) m_agent = GetComponent<NavMeshAgent>();
            if (m_wheels == null) m_wheels = GetComponent<UGTankWheels>() ?? GetComponentInChildren<UGTankWheels>();
            m_path = new NavMeshPath();
            m_lastYaw = transform.eulerAngles.y;

            if (m_agent == null)
            {
                Debug.LogWarning($"{name}: 缺少 NavMeshAgent 组件，巡逻未开始。", this);
                return;
            }

            // 关闭代理自动转向：朝向完全由本脚本控制（先转向、后运动）
            m_agent.updateRotation = false;

            if (m_agent.isOnNavMesh)
                PickNextDestination();
            else
                Debug.LogWarning($"{name}: NavMeshAgent 未就绪或场景未烘焙 NavMesh，巡逻未开始。请在 Navigation 窗口烘焙导航网格。", this);
        }

        private void Update()
        {
            if (m_agent == null || !m_agent.isOnNavMesh) return;

            // 到达目标后，循环选择下一个目标点
            if (!m_agent.pathPending && (!m_agent.hasPath || m_agent.remainingDistance <= m_agent.stoppingDistance + 0.1f))
            {
                PickNextDestination();
                return;
            }

            // 路径失效时重新选点
            if (m_agent.pathStatus == NavMeshPathStatus.PathInvalid)
            {
                PickNextDestination();
                return;
            }

            if (m_wheels == null) return;

            switch (m_state)
            {
                case PatrolState.Turning:
                {
                    // 原地转向对准目标方向（代理处于停止状态，转向与移动不会同时进行）
                    if (TurnTowards(GetTargetYaw()))
                        StartMoving();

                    var yaw = transform.eulerAngles.y;
                    var turnRate = Mathf.DeltaAngle(m_lastYaw, yaw) / Mathf.Max(Time.deltaTime, 1e-4f);
                    m_lastYaw = yaw;
                    m_wheels.Drive(0f, turnRate);
                    break;
                }

                case PatrolState.Moving:
                {
                    // 运动中检查朝向是否偏离路径方向，偏离则先停下、转入转向状态
                    if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, GetTargetYaw())) > HeadingTolerance)
                    {
                        m_agent.isStopped = true;
                        m_state = PatrolState.Turning;
                        break;
                    }

                    var yaw = transform.eulerAngles.y;
                    m_lastYaw = yaw;
                    m_wheels.Drive(Vector3.Dot(m_agent.velocity, transform.forward), 0f);
                    break;
                }
            }
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
        /// 转向完成：放行代理开始移动。
        /// </summary>
        private void StartMoving()
        {
            m_agent.isStopped = false;
            m_state = PatrolState.Moving;
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
        /// 且在 NavMesh 上路径完整可达的目标点；找到则设置给代理并转入「转向」状态。
        /// </summary>
        private void PickNextDestination()
        {
            for (var i = 0; i < m_sampleAttempts; i++)
            {
                if (TrySampleDestination(m_patrolRadius, m_minDestinationDistance, out var point)
                    && m_agent.CalculatePath(point, m_path)
                    && m_path.status == NavMeshPathStatus.PathComplete)
                {
                    m_agent.SetDestination(point);

                    // 先转向后运动：转向期间暂停移动
                    m_agent.isStopped = true;
                    m_state = PatrolState.Turning;
                    return;
                }
            }

            Debug.LogWarning($"{name}: 未能在 {m_patrolRadius}m 半径内找到可达且距起点 ≥{m_minDestinationDistance}m 的目标点，稍后重试。", this);
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
    }
}
