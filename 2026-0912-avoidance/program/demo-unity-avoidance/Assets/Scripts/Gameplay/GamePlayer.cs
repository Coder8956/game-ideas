using UnityEngine;

/// <summary>
/// 玩家脚本：
/// 1. 在Inspector中配置所属MoveKey、相对该MoveKey的世界坐标Y轴偏移与移动速度
/// 2. 初始化时玩家世界位置 = MoveKey世界位置 + Y轴偏移，即摆放到MoveKey正上方指定高度
/// 3. MoveKey被成功点击时会请求玩家向其移动：若玩家世界X坐标与该MoveKey的世界X坐标相等则忽略请求，
///    否则以配置的移动速度向该MoveKey顶面站位匀速移动，到达后自动停止；移动中新请求会更新目标
/// 4. 玩家功能可由外部（如GameController）在游戏流程中启停，未启用时不参与游戏逻辑（含移动）
/// </summary>
public class GamePlayer : MonoBehaviour
{
    // ==================== 私有字段 ====================

    /// <summary>配置的MoveKey，作为玩家初始位置的参照物</summary>
    [SerializeField] private MoveKey m_moveKey;

    /// <summary>相对MoveKey世界坐标的Y轴偏移（默认1.5 = 立方体半高0.5 + 胶囊体半高1，玩家恰好立于MoveKey顶面）</summary>
    [SerializeField] private float m_yOffset = 1.5f;

    /// <summary>移动速度（单位/秒）</summary>
    [SerializeField, Min(0f)] private float m_moveSpeed = 5f;

    /// <summary>玩家功能是否启用，未启用时不参与游戏逻辑（由GameController在游戏流程中控制）</summary>
    private bool m_functionalityEnabled = true;

    /// <summary>移动目标位置（世界坐标），无值表示当前没有移动任务</summary>
    private Vector3? m_moveTarget;

    /// <summary>X坐标相等判定容差，小于该值视为X坐标相等，避免浮点误差在已对齐时仍触发移动</summary>
    private const float XEpsilon = 0.0001f;

    // ==================== 生命周期 ====================

    void Awake()
    {
        InitializePosition();
    }

    void Update()
    {
        HandleMovement();
    }

    // ==================== 位置初始化 ====================

    /// <summary>
    /// 初始化玩家位置：世界位置 = MoveKey世界位置 + Y轴偏移；
    /// 未配置MoveKey时保持Inspector中的摆放位置并告警，不阻断流程
    /// </summary>
    private void InitializePosition()
    {
        if (m_moveKey == null)
        {
            Debug.LogWarning("[GamePlayer] 未配置MoveKey，玩家位置保持Inspector中的摆放位置。", this);
            return;
        }

        transform.position = GetStandingPosition(m_moveKey);
    }

    // ==================== 移动逻辑 ====================

    /// <summary>
    /// 处理进行中的移动：以配置的移动速度每帧向目标匀速推进；
    /// 剩余距离不足一步时直接精确落位并结束移动，避免速度过快时越过目标往复抖动
    /// </summary>
    private void HandleMovement()
    {
        if (!m_functionalityEnabled || !m_moveTarget.HasValue)
            return;

        Vector3 target = m_moveTarget.Value;
        Vector3 toTarget = target - transform.position;
        float step = m_moveSpeed * Time.deltaTime;

        if (toTarget.magnitude <= step)
        {
            transform.position = target;
            m_moveTarget = null;
            return;
        }

        transform.position += toTarget.normalized * step;
    }

    /// <summary>计算立于指定MoveKey顶面的世界坐标（MoveKey世界位置 + Y轴偏移）</summary>
    private Vector3 GetStandingPosition(MoveKey moveKey)
    {
        Vector3 position = moveKey.transform.position;
        position.y += m_yOffset;
        return position;
    }

    // ==================== 公开接口 ====================

    /// <summary>获取配置的MoveKey</summary>
    public MoveKey GetMoveKey() => m_moveKey;

    /// <summary>设置配置的MoveKey</summary>
    public void SetMoveKey(MoveKey moveKey) => m_moveKey = moveKey;

    /// <summary>获取相对MoveKey世界坐标的Y轴偏移</summary>
    public float GetYOffset() => m_yOffset;

    /// <summary>设置相对MoveKey世界坐标的Y轴偏移</summary>
    public void SetYOffset(float yOffset) => m_yOffset = yOffset;

    /// <summary>获取移动速度（单位/秒）</summary>
    public float GetMoveSpeed() => m_moveSpeed;

    /// <summary>设置移动速度（单位/秒），负值按0处理</summary>
    public void SetMoveSpeed(float speed) => m_moveSpeed = Mathf.Max(0f, speed);

    /// <summary>
    /// 请求玩家向指定MoveKey移动（由MoveKey在成功被点击时调用）：
    /// 功能未启用或未传入MoveKey时忽略；玩家世界X坐标与该MoveKey的世界X坐标相等（已在其正上方）时同样忽略；
    /// 否则将移动目标更新为该MoveKey顶面站位，移动中再次请求以最新目标为准
    /// </summary>
    public void RequestMoveTo(MoveKey moveKey)
    {
        if (!m_functionalityEnabled || moveKey == null)
            return;

        // 需求约定：仅当玩家世界X坐标不等于MoveKey世界X坐标时才移动
        if (Mathf.Abs(transform.position.x - moveKey.transform.position.x) <= XEpsilon)
            return;

        m_moveTarget = GetStandingPosition(moveKey);
    }

    /// <summary>当前玩家功能是否启用</summary>
    public bool IsFunctionalityEnabled() => m_functionalityEnabled;

    /// <summary>
    /// 设置玩家功能是否启用（由GameController在游戏流程中控制）；
    /// 禁用时同时取消进行中的移动任务，与MoveKey禁用时清除提示状态的语义一致
    /// </summary>
    public void SetFunctionalityEnabled(bool enabled)
    {
        m_functionalityEnabled = enabled;

        if (!enabled)
        {
            m_moveTarget = null;
        }
    }
}
