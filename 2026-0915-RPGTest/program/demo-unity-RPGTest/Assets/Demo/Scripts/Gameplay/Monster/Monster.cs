using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 怪物巡逻控制器
/// 控制怪物在NavMesh地面上随机行走：
/// 1. 以出生点为中心，在巡逻半径内随机选取NavMesh上的目标点，取点时避开其他怪物的当前位置与目的地
/// 2. 选定目标后先在原地转身朝向路径前进方向，转身完成后再放行代理开始行走
/// 3. 行走时通过NavMeshAgent自动寻路移动到目标点，播放行走动画，到达后播放待机动画
/// 4. 到达后随机待机一段时间，再继续巡逻，循环往复
/// 多只怪物通过"按体型自适应的避让半径 + 互不相同的避让优先级 + 目的地间距约束"互不相撞、不抢路
/// </summary>
public class Monster : MonoBehaviour
{
    // ==================== 私有字段 ====================

    [Header("组件引用")]
    [Tooltip("动画器，未赋值时自动在子物体中查找")]
    [SerializeField] private Animator m_animator;

    [Tooltip("导航代理，未赋值时自动在同物体上查找")]
    [SerializeField] private NavMeshAgent m_navMeshAgent;

    [Header("巡逻参数")]
    [Tooltip("以出生点为中心的随机巡逻半径（米）")]
    [SerializeField] private float m_wanderRadius = 10f;

    [Tooltip("两次巡逻之间的最小待机时间（秒）")]
    [SerializeField] private float m_minIdleTime = 1f;

    [Tooltip("两次巡逻之间的最大待机时间（秒）")]
    [SerializeField] private float m_maxIdleTime = 4f;

    [Tooltip("原地转身角速度（度/秒）——先转身朝向前进方向，转身完成后再开始行走")]
    [SerializeField] private float m_turnSpeed = 240f;

    [Tooltip("巡逻目的地与其他怪物当前位置/目的地的最小间距（米），防止出发点与到达点挤在一起")]
    [SerializeField] private float m_separationDistance = 2.5f;

    [Header("动画参数")]
    [Tooltip("行走动画状态名，与MonA001_AC控制器中的状态名一致")]
    [SerializeField] private string m_walkStateName = "Monster38_Walk";

    [Tooltip("待机动画状态名，与MonA001_AC控制器中的状态名一致")]
    [SerializeField] private string m_idleStateName = "Monster38_Idle01";

    [Tooltip("动画状态切换的混合时长（秒）")]
    [SerializeField] private float m_animationCrossFadeTime = 0.25f;

    /// <summary>随机取点的最大尝试次数——避免极小概率下反复取不到有效点形成死循环</summary>
    private const int MaxPickAttempts = 10;

    /// <summary>到达判定距离容差（米）——代理stoppingDistance为0时防止浮点误差导致永远判定未到达</summary>
    private const float ArriveDistanceEpsilon = 0.05f;

    /// <summary>目标点最小距离系数——保证每次巡逻至少走出巡逻半径的一定比例，而不是原地小碎步</summary>
    private const float MinWanderDistanceFactor = 0.3f;

    /// <summary>NavMesh采样半径（米）——把候选点/出生点吸附到最近的可行走地面</summary>
    private const float NavMeshSnapDistance = 2f;

    /// <summary>放行行走后忽略到达判定的短暂时间（秒）——起步与重寻路窗口内状态不稳定，防止误判为已到达</summary>
    private const float ArrivalCheckDelay = 0.3f;

    /// <summary>转身完成的角度容差（度）——当前朝向与前进方向的夹角小于该值即视为转身完成</summary>
    private const float TurnCompleteAngleEpsilon = 2f;

    /// <summary>到达点与其他怪物挤在一起时，不作停留、稍候即另寻目标的等待时长（秒）</summary>
    private const float CrowdedLeaveDelay = 0.5f;

    /// <summary>避让半径下限（米）——按模型包围盒推导半径时的钳制下限，过小会导致视觉穿插</summary>
    private const float MinAvoidRadius = 0.5f;

    /// <summary>避让半径上限（米）——过大会导致窄区寻路失败</summary>
    private const float MaxAvoidRadius = 2f;

    /// <summary>避让优先级基准值——数值越小优先级越高，相遇时对方让行</summary>
    private const int AvoidPriorityBase = 30;

    /// <summary>避让优先级档位数量——同场景内最多分配6个互不相同的优先级</summary>
    private const int AvoidPrioritySlotCount = 6;

    /// <summary>相邻两档避让优先级的间隔</summary>
    private const int AvoidPriorityStep = 10;

    /// <summary>当前场景内所有活跃的怪物实例——取点与到达拥挤判断时用于互相避让</summary>
    private static readonly List<Monster> s_instances = new List<Monster>();

    /// <summary>实例计数器——为每个实例分配互不相同的避让优先级</summary>
    private static int s_priorityCounter;

    /// <summary>巡逻状态：待机 → 原地转身 → 行走，循环往复</summary>
    private enum PatrolState
    {
        Idle,      // 待机：倒计时归零后选取下一个巡逻目标
        Turning,   // 转身：原地旋转至路径前进方向，期间保持待机动画且代理不移动
        Walking    // 行走：沿NavMesh路径移动，仅在转身完成后进入
    }

    private Vector3 m_spawnPosition;                 // 出生点，巡逻中心
    private float m_idleTimer;                       // 剩余待机时间，归零后开始下一次巡逻
    private float m_walkTimer;                       // 本次已行走时间，用于延迟到达判定
    private Vector3 m_currentDestination;            // 本次巡逻的目的地，供其他怪物取点时避让
    private bool m_hasDestination;                   // 是否存在未完成的巡逻目的地
    private PatrolState m_state = PatrolState.Idle;  // 当前巡逻状态

    // ==================== 生命周期 ====================

    void Awake()
    {
        // 组件引用兜底：动画器在子物体（模型）上，导航代理在怪物根物体上
        if (m_animator == null)
            m_animator = GetComponentInChildren<Animator>();
        if (m_navMeshAgent == null)
            m_navMeshAgent = GetComponent<NavMeshAgent>();

        ApplyAvoidanceSettings();
    }

    void OnEnable()
    {
        s_instances.Add(this);
    }

    void OnDisable()
    {
        s_instances.Remove(this);
    }

    void Start()
    {
        m_spawnPosition = transform.position;

        // 出生点可能与NavMesh有微小高度偏差（地面高度≠0），吸附到最近的NavMesh点，
        // 保证代理isOnNavMesh为真、SetDestination能正常寻路
        if (m_navMeshAgent != null &&
            NavMesh.SamplePosition(m_spawnPosition, out NavMeshHit spawnHit, NavMeshSnapDistance, NavMesh.AllAreas))
        {
            m_navMeshAgent.Warp(spawnHit.position);
        }

        // 出生先随机待机一段时间再开始巡逻
        m_idleTimer = Random.Range(m_minIdleTime, m_maxIdleTime);
        PlayAnimation(m_idleStateName);
    }

    void Update()
    {
        // 组件缺失时无法巡逻，保持静止避免空引用
        if (m_navMeshAgent == null || m_animator == null)
            return;

        switch (m_state)
        {
            case PatrolState.Idle:
                UpdateIdling();
                break;
            case PatrolState.Turning:
                UpdateTurning();
                break;
            case PatrolState.Walking:
                UpdateWalking();
                break;
        }
    }

    // ==================== 巡逻逻辑 ====================

    /// <summary>
    /// 行走状态：每帧检查是否到达目标点
    /// 到达后停止寻路，随机待机并切换到待机动画；
    /// 若到达点附近有其他怪物则稍候即另寻目标，避免并肩停留
    /// </summary>
    private void UpdateWalking()
    {
        m_walkTimer += Time.deltaTime;

        // 刚放行行走的短暂时间内不判定到达，防止起步阶段被误判为已到达
        if (m_walkTimer < ArrivalCheckDelay)
            return;

        if (!HasArrived())
            return;

        m_state = PatrolState.Idle;
        m_navMeshAgent.isStopped = true;
        m_hasDestination = false;
        PlayAnimation(m_idleStateName);

        // 其他怪物在我行走期间挪近到达点时（如恰好路过或停驻），尽快离开避免挤在一起
        m_idleTimer = IsStandingTooCloseToOther()
            ? CrowdedLeaveDelay
            : Random.Range(m_minIdleTime, m_maxIdleTime);
    }

    /// <summary>
    /// 待机状态：待机计时归零后随机选取新目标点，请求寻路并进入转身状态
    /// 代理此时保持停止，待转身完成后才放行行走
    /// </summary>
    private void UpdateIdling()
    {
        m_idleTimer -= Time.deltaTime;
        if (m_idleTimer > 0f)
            return;

        // 取不到有效点（如出生点周围NavMesh极小或其他怪物占位）时稍等片刻重试
        if (!TryPickRandomDestination(out Vector3 destination))
        {
            m_idleTimer = 1f;
            return;
        }

        // 先请求寻路但保持代理停止：等路径算出后原地转身，转身到位才放行行走
        m_navMeshAgent.isStopped = true;
        m_navMeshAgent.updateRotation = false;   // 转身期间由本脚本接管朝向，避免代理抢先旋转
        m_navMeshAgent.SetDestination(destination);
        m_currentDestination = destination;
        m_hasDestination = true;
        m_state = PatrolState.Turning;           // 转身阶段沿用待机动画
    }

    /// <summary>
    /// 转身状态：等待路径计算完成后，以固定角速度原地旋转至路径前进方向
    /// 转身到位后放行代理开始行走；路径异常时放弃本次巡逻回到待机重试
    /// </summary>
    private void UpdateTurning()
    {
        // 路径尚未计算完成，暂无法获知前进方向
        if (m_navMeshAgent.pathPending)
            return;

        // 无有效路径或只能走到半程（目标不可达/被体型半径挡住）时放弃本次巡逻，稍后重新取点
        if (!m_navMeshAgent.hasPath || m_navMeshAgent.pathStatus != NavMeshPathStatus.PathComplete)
        {
            CancelTurning();
            return;
        }

        // corners[0]为当前位置，corners[1]为第一个前进拐点；拐点过少说明目标已在脚下，无需转身
        Vector3[] corners = m_navMeshAgent.path.corners;
        if (corners.Length < 2)
        {
            CancelTurning();
            return;
        }

        Vector3 moveDirection = corners[1] - transform.position;
        moveDirection.y = 0f;
        if (moveDirection.sqrMagnitude < 0.0001f)
        {
            CancelTurning();
            return;
        }

        // 以固定角速度原地转向前进方向（代理已停止，此处旋转不会与移动叠加）
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, m_turnSpeed * Time.deltaTime);

        // 夹角进入容差即视为转身完成，放行代理开始行走
        if (Quaternion.Angle(transform.rotation, targetRotation) <= TurnCompleteAngleEpsilon)
        {
            StartWalking();
        }
    }

    /// <summary>放弃本次转身，清除路径并回到待机状态稍后重试</summary>
    private void CancelTurning()
    {
        m_state = PatrolState.Idle;
        m_hasDestination = false;
        m_navMeshAgent.ResetPath();
        m_navMeshAgent.updateRotation = true;
        m_idleTimer = 1f;
    }

    /// <summary>转身完成后放行代理沿路径行走，并切换到行走动画</summary>
    private void StartWalking()
    {
        m_state = PatrolState.Walking;
        m_walkTimer = 0f;
        m_navMeshAgent.updateRotation = true;
        m_navMeshAgent.isStopped = false;
        PlayAnimation(m_walkStateName);
    }

    /// <summary>
    /// 是否已到达目标点
    /// 路径计算完成且剩余距离进入停止范围、速度已降为零视为到达；
    /// 目标不可达等异常情况（无路径）也按到达处理，避免卡死在行走状态
    /// </summary>
    private bool HasArrived()
    {
        if (m_navMeshAgent.pathPending)
            return false;

        if (!m_navMeshAgent.hasPath)
            return true;

        return m_navMeshAgent.remainingDistance <= m_navMeshAgent.stoppingDistance + ArriveDistanceEpsilon
            && m_navMeshAgent.velocity.sqrMagnitude < 0.01f;
    }

    /// <summary>
    /// 以出生点为中心，在巡逻半径内随机取一个NavMesh上的可行走点，
    /// 且不落在其他怪物的当前位置或目的地附近
    /// </summary>
    private bool TryPickRandomDestination(out Vector3 destination)
    {
        float minDistance = m_wanderRadius * MinWanderDistanceFactor;

        for (int attempt = 0; attempt < MaxPickAttempts; attempt++)
        {
            // 随机方向 + 随机距离，距离下限保证巡逻有实际位移
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            float randomDistance = Random.Range(minDistance, m_wanderRadius);
            Vector3 candidate = m_spawnPosition + new Vector3(randomDirection.x, 0f, randomDirection.y) * randomDistance;

            // 用NavMesh采样把候选点吸附到可行走地面，过滤悬崖、边缘等不可达位置
            if (!NavMesh.SamplePosition(candidate, out NavMeshHit hit, NavMeshSnapDistance, NavMesh.AllAreas))
                continue;

            // 落在其他怪物的占位范围（当前位置/目的地附近）会导致到达后挤在一起，重新取点
            if (IsPointOccupiedByOther(hit.position))
                continue;

            destination = hit.position;
            return true;
        }

        destination = Vector3.zero;
        return false;
    }

    /// <summary>
    /// 目标点是否落在其他怪物的占位范围内：
    /// 其他怪物的当前位置（含其待机点/出发点）或其正在前往的目的地附近
    /// </summary>
    private bool IsPointOccupiedByOther(Vector3 point)
    {
        float thresholdSq = m_separationDistance * m_separationDistance;

        foreach (Monster other in s_instances)
        {
            if (other == this)
                continue;

            if (FlatDistanceSq(point, other.transform.position) < thresholdSq)
                return true;

            // 对方选定了相同目标点时两头挤向一处，同样视为占位冲突
            if (other.m_hasDestination && FlatDistanceSq(point, other.m_currentDestination) < thresholdSq)
                return true;
        }

        return false;
    }

    /// <summary>当前位置是否与其他怪物挤在一起（仅看位置，用于到达时的拥挤判断）</summary>
    private bool IsStandingTooCloseToOther()
    {
        float thresholdSq = m_separationDistance * m_separationDistance;

        foreach (Monster other in s_instances)
        {
            if (other == this)
                continue;

            if (FlatDistanceSq(transform.position, other.transform.position) < thresholdSq)
                return true;
        }

        return false;
    }

    /// <summary>水平面（忽略Y轴）上的两点距离平方</summary>
    private static float FlatDistanceSq(Vector3 a, Vector3 b)
    {
        Vector3 delta = a - b;
        delta.y = 0f;
        return delta.sqrMagnitude;
    }

    /// <summary>
    /// 依据模型实际包围盒推导避让半径，并分配互不相同的避让优先级：
    /// 代理默认半径(0.5)远小于模型体宽会导致怪物视觉穿插；
    /// 优先级相同时两代理互不相让，狭路相遇会僵持抢路
    /// </summary>
    private void ApplyAvoidanceSettings()
    {
        if (m_navMeshAgent == null)
            return;

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        if (renderers.Length > 0)
        {
            Bounds bounds = renderers[0].bounds;
            for (int i = 1; i < renderers.Length; i++)
                bounds.Encapsulate(renderers[i].bounds);

            // 取水平面上较大的包围尺寸的一半作为避让半径，保证视觉身体不重叠
            float bodyRadius = Mathf.Max(bounds.size.x, bounds.size.z) * 0.5f;
            m_navMeshAgent.radius = Mathf.Clamp(bodyRadius, MinAvoidRadius, MaxAvoidRadius);
        }

        m_navMeshAgent.avoidancePriority = AvoidPriorityBase
            + (s_priorityCounter++ % AvoidPrioritySlotCount) * AvoidPriorityStep;
    }

    /// <summary>
    /// 以固定时长混合切换动画状态，避免待机/行走动画之间硬切跳变
    /// </summary>
    private void PlayAnimation(string stateName)
    {
        m_animator.CrossFadeInFixedTime(stateName, m_animationCrossFadeTime);
    }

    // ==================== 公开接口 ====================

    /// <summary>当前是否正在巡逻行走</summary>
    public bool IsWalking() => m_state == PatrolState.Walking;

    /// <summary>获取巡逻半径（米）</summary>
    public float GetWanderRadius() => m_wanderRadius;

    /// <summary>设置巡逻半径（米）</summary>
    public void SetWanderRadius(float radius) => m_wanderRadius = Mathf.Max(0.1f, radius);

    /// <summary>获取最小待机时间（秒）</summary>
    public float GetMinIdleTime() => m_minIdleTime;

    /// <summary>设置最小待机时间（秒）</summary>
    public void SetMinIdleTime(float time) => m_minIdleTime = Mathf.Max(0f, time);

    /// <summary>获取最大待机时间（秒）</summary>
    public float GetMaxIdleTime() => m_maxIdleTime;

    /// <summary>设置最大待机时间（秒），不允许小于最小待机时间</summary>
    public void SetMaxIdleTime(float time) => m_maxIdleTime = Mathf.Max(m_minIdleTime, time);

    /// <summary>获取原地转身角速度（度/秒）</summary>
    public float GetTurnSpeed() => m_turnSpeed;

    /// <summary>设置原地转身角速度（度/秒）</summary>
    public void SetTurnSpeed(float turnSpeed) => m_turnSpeed = Mathf.Max(1f, turnSpeed);

    /// <summary>获取与其他怪物的最小间距（米）</summary>
    public float GetSeparationDistance() => m_separationDistance;

    /// <summary>设置与其他怪物的最小间距（米）</summary>
    public void SetSeparationDistance(float distance) => m_separationDistance = Mathf.Max(0f, distance);
}
