using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 怪物巡逻控制器
/// 控制怪物在NavMesh地面上随机行走：
/// 1. 以出生点为中心，在巡逻半径内随机选取NavMesh上的目标点
/// 2. 通过NavMeshAgent自动寻路移动到目标点
/// 3. 行走时播放行走动画，到达后播放待机动画
/// 4. 到达后随机待机一段时间，再继续巡逻，循环往复
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

    /// <summary>开始行走后忽略到达判定的短暂时间（秒）——路径尚未计算完成时hasPath可能仍为空，防止误判为已到达</summary>
    private const float ArrivalCheckDelay = 0.3f;

    private Vector3 m_spawnPosition;   // 出生点，巡逻中心
    private float m_idleTimer;         // 剩余待机时间，归零后开始下一次巡逻
    private float m_walkTimer;         // 本次已行走时间，用于延迟到达判定
    private bool m_isWalking;          // 是否处于行走（巡逻）状态

    // ==================== 生命周期 ====================

    void Awake()
    {
        // 组件引用兜底：动画器在子物体（模型）上，导航代理在怪物根物体上
        if (m_animator == null)
            m_animator = GetComponentInChildren<Animator>();
        if (m_navMeshAgent == null)
            m_navMeshAgent = GetComponent<NavMeshAgent>();
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

        if (m_isWalking)
        {
            UpdateWalking();
        }
        else
        {
            UpdateIdling();
        }
    }

    // ==================== 巡逻逻辑 ====================

    /// <summary>
    /// 行走状态：每帧检查是否到达目标点
    /// 到达后停止寻路，随机待机并切换到待机动画
    /// </summary>
    private void UpdateWalking()
    {
        m_walkTimer += Time.deltaTime;

        // 刚设置目标点的短暂时间内路径可能还未生成，此时不判定到达
        if (m_walkTimer < ArrivalCheckDelay)
            return;

        if (!HasArrived())
            return;

        m_isWalking = false;
        m_navMeshAgent.isStopped = true;
        m_idleTimer = Random.Range(m_minIdleTime, m_maxIdleTime);
        PlayAnimation(m_idleStateName);
    }

    /// <summary>
    /// 待机状态：待机计时归零后随机选取新目标点并开始行走
    /// </summary>
    private void UpdateIdling()
    {
        m_idleTimer -= Time.deltaTime;
        if (m_idleTimer > 0f)
            return;

        // 取不到有效点（如出生点周围NavMesh极小）时稍等片刻重试
        if (!TryPickRandomDestination(out Vector3 destination))
        {
            m_idleTimer = 1f;
            return;
        }

        m_isWalking = true;
        m_walkTimer = 0f;
        m_navMeshAgent.isStopped = false;
        m_navMeshAgent.SetDestination(destination);
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
    /// 以出生点为中心，在巡逻半径内随机取一个NavMesh上的可行走点
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
            if (NavMesh.SamplePosition(candidate, out NavMeshHit hit, NavMeshSnapDistance, NavMesh.AllAreas))
            {
                destination = hit.position;
                return true;
            }
        }

        destination = Vector3.zero;
        return false;
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
    public bool IsWalking() => m_isWalking;

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
}
