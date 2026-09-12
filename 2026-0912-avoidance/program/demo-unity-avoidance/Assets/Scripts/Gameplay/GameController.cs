using UnityEngine;

/// <summary>
/// 主游戏流程控制器：
/// 1. 初始化时收集场景中所有MoveKey、玩家（GamePlayer）与掉落点（DropPoints），统一禁用其功能（准备阶段不可交互）
/// 2. 自动进入开始流程：准备倒计时结束后开始游戏，启用所有MoveKey、玩家与掉落点的功能
/// 3. 准备阶段时长可在Inspector中配置，设为0则初始化后立即开始
/// 4. 准备阶段在控制台按整秒输出剩余倒计时秒数，倒计时结束输出游戏开始提示
/// 5. 结束流程：DropPoints掉落表所有物体完成后触发EndGame，游戏结束并再次禁用所有功能
/// </summary>
public class GameController : MonoBehaviour
{
    // ==================== 私有字段 ====================

    /// <summary>游戏状态</summary>
    private enum GameState
    {
        /// <summary>准备阶段：MoveKey、玩家与掉落点功能禁用中</summary>
        Ready,

        /// <summary>游戏进行中：MoveKey、玩家与掉落点功能已启用</summary>
        Playing,

        /// <summary>游戏结束：所有功能再次禁用</summary>
        GameOver,
    }

    /// <summary>准备阶段持续时间（秒），倒计时结束自动开始游戏</summary>
    [SerializeField] private float m_readyDuration = 3f;

    /// <summary>场景中所有MoveKey缓存</summary>
    private MoveKey[] m_moveKeys;

    /// <summary>场景中所有玩家缓存</summary>
    private GamePlayer[] m_players;

    /// <summary>场景中所有掉落点缓存</summary>
    private DropPoints[] m_dropPoints;

    /// <summary>当前游戏状态</summary>
    private GameState m_state = GameState.Ready;

    /// <summary>准备阶段剩余时间（秒）</summary>
    private float m_readyTimer;

    /// <summary>上一次已输出的整秒倒计时（-1表示尚未输出过），用于避免同一秒内重复输出</summary>
    private int m_lastCountdownSecond = -1;

    // ==================== 生命周期 ====================

    void Start()
    {
        // 初始化：获取所有MoveKey（含未激活对象，保证后续激活的也纳入流程），统一禁用其功能
        m_moveKeys = FindObjectsByType<MoveKey>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        if (m_moveKeys.Length == 0)
        {
            Debug.LogWarning("[GameController] 场景中未找到任何MoveKey。", this);
        }
        SetMoveKeysEnabled(false);

        // 获取所有玩家（含未激活对象，保证后续激活的也纳入流程），准备阶段同样禁用其功能
        m_players = FindObjectsByType<GamePlayer>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        if (m_players.Length == 0)
        {
            Debug.LogWarning("[GameController] 场景中未找到任何GamePlayer。", this);
        }
        SetPlayersEnabled(false);

        // 获取所有掉落点（含未激活对象，保证后续激活的也纳入流程），准备阶段同样禁用其功能
        m_dropPoints = FindObjectsByType<DropPoints>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        if (m_dropPoints.Length == 0)
        {
            Debug.LogWarning("[GameController] 场景中未找到任何DropPoints。", this);
        }
        SetDropPointsEnabled(false);

        // 进入准备阶段，倒计时结束后自动开始游戏
        m_state = GameState.Ready;
        m_readyTimer = m_readyDuration;
        m_lastCountdownSecond = -1;
    }

    void Update()
    {
        // 仅准备阶段需要逐帧驱动倒计时；游戏进行中与结束状态均无逐帧逻辑（结束由DropPoints主动触发）
        if (m_state == GameState.Ready)
        {
            UpdateReadyCountdown();
        }
    }

    // ==================== 准备阶段 ====================

    /// <summary>
    /// 准备阶段倒计时：递减剩余时间，每跨过整秒边界输出一次剩余秒数（如3、2、1），
    /// 归零后自动开始游戏
    /// </summary>
    private void UpdateReadyCountdown()
    {
        m_readyTimer -= Time.deltaTime;

        // 每跨过整秒边界输出一次剩余秒数（如3、2、1），避免逐帧重复输出
        int remainingSecond = Mathf.CeilToInt(m_readyTimer);
        if (remainingSecond > 0 && remainingSecond != m_lastCountdownSecond)
        {
            m_lastCountdownSecond = remainingSecond;
            Debug.Log($"[GameController] 倒计时：{remainingSecond}", this);
        }

        if (m_readyTimer <= 0f)
        {
            StartGame();
        }
    }

    // ==================== 游戏流程 ====================

    /// <summary>
    /// 开始游戏：进入Playing状态并启用所有MoveKey与玩家的功能；
    /// 幂等，重复调用不生效
    /// </summary>
    public void StartGame()
    {
        if (m_state == GameState.Playing)
            return;

        m_state = GameState.Playing;
        Debug.Log("[GameController] 游戏开始！", this);
        SetMoveKeysEnabled(true);
        SetPlayersEnabled(true);
        SetDropPointsEnabled(true);
    }

    /// <summary>
    /// 结束游戏：进入GameOver状态并禁用所有MoveKey、玩家与掉落点的功能；
    /// 仅游戏进行中可结束（由DropPoints在掉落表所有物体完成后触发）；
    /// 幂等，重复调用不生效
    /// </summary>
    public void EndGame()
    {
        if (m_state != GameState.Playing)
            return;

        m_state = GameState.GameOver;
        Debug.Log("[GameController] 游戏结束！", this);
        SetMoveKeysEnabled(false);
        SetPlayersEnabled(false);
        SetDropPointsEnabled(false);
    }

    /// <summary>批量设置所有MoveKey的点击功能开关</summary>
    private void SetMoveKeysEnabled(bool enabled)
    {
        if (m_moveKeys == null)
            return;

        foreach (MoveKey moveKey in m_moveKeys)
        {
            moveKey.SetFunctionalityEnabled(enabled);
        }
    }

    /// <summary>批量设置所有玩家的功能开关</summary>
    private void SetPlayersEnabled(bool enabled)
    {
        if (m_players == null)
            return;

        foreach (GamePlayer player in m_players)
        {
            player.SetFunctionalityEnabled(enabled);
        }
    }

    /// <summary>批量设置所有掉落点的功能开关</summary>
    private void SetDropPointsEnabled(bool enabled)
    {
        if (m_dropPoints == null)
            return;

        foreach (DropPoints dropPoints in m_dropPoints)
        {
            dropPoints.SetFunctionalityEnabled(enabled);
        }
    }

    // ==================== 公开接口 ====================

    /// <summary>当前是否处于游戏进行中</summary>
    public bool IsPlaying() => m_state == GameState.Playing;

    /// <summary>当前是否处于游戏结束状态</summary>
    public bool IsGameOver() => m_state == GameState.GameOver;

    /// <summary>获取准备阶段持续时间（秒）</summary>
    public float GetReadyDuration() => m_readyDuration;

    /// <summary>设置准备阶段持续时间（秒）</summary>
    public void SetReadyDuration(float duration) => m_readyDuration = duration;

    /// <summary>获取准备阶段剩余时间（秒）</summary>
    public float GetRemainingReadyTime() => Mathf.Max(0f, m_readyTimer);
}
