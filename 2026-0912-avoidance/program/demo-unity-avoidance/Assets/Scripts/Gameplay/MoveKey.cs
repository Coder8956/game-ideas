using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 移动按键（点击变色反馈 + 通知玩家移动）
/// 鼠标/触屏每次点击Cube，Cube短暂变为提示色作为点击反馈，并通知玩家向本按键移动：
/// 1. 使用新Input System检测指针按下：触屏优先（兼容Device Simulator与真机，
///    模拟器里点击被翻译为Touch事件，Mouse收不到），其次鼠标（兼容编辑器Game视图）；
///    并从主相机向指针位置发射线判断是否点中本Cube
///    （项目仅启用新Input System后端，旧输入链路的OnMouseDown消息不会触发，故不能依赖）
/// 2. 点击后立即变为提示色，持续一段时间后自动恢复原色，保证每次点击都有可见反馈
/// 3. 提示色与持续时间均可在Inspector中配置
/// 4. 点击命中后通知场景中所有玩家向本MoveKey移动（是否移动由玩家按自身功能开关与X坐标判断）
/// 5. 点击反馈功能可由外部（如GameController）启停：未启用时不响应点击，禁用时立即还原提示色
/// </summary>
public class MoveKey : MonoBehaviour
{
    // ==================== 私有字段 ====================

    /// <summary>点击提示色</summary>
    [SerializeField] private Color m_highlightColor = Color.yellow;

    /// <summary>提示色持续时间（秒）</summary>
    [SerializeField] private float m_highlightDuration = 0.2f;

    /// <summary>主相机缓存</summary>
    private Camera m_mainCamera;

    /// <summary>自身Collider缓存，用于射线命中判断</summary>
    private Collider m_collider;

    /// <summary>MeshRenderer缓存</summary>
    private MeshRenderer m_meshRenderer;

    /// <summary>材质实例缓存（renderer.material会生成实例，避免直接改动共享材质资产）</summary>
    private Material m_material;

    /// <summary>点击前的原始颜色，用于恢复</summary>
    private Color m_originalColor;

    /// <summary>提示色剩余时间（秒），小于等于0表示当前未处于提示状态</summary>
    private float m_highlightTimer;

    /// <summary>上一帧是否有指针（触屏或鼠标左键）处于按下状态，用于按下边沿检测</summary>
    private bool m_wasPressed;

    /// <summary>点击反馈功能是否启用，未启用时不响应点击（由GameController在游戏流程中控制）</summary>
    private bool m_functionalityEnabled = true;

    /// <summary>场景中所有玩家缓存，成功点击时通知其向本MoveKey移动</summary>
    private GamePlayer[] m_players;

    /// <summary>MoveKey层遮罩：射线检测仅命中该层，避免玩家等其他层物体遮挡射线导致点击判断失效</summary>
    private int m_moveKeyLayerMask;

    // ==================== 生命周期 ====================

    void Awake()
    {
        // NameToLayer禁止在字段初始化器中调用（Awake之前），故在此构建层遮罩
        m_moveKeyLayerMask = LayerMask.GetMask("MoveKey");
        m_mainCamera = Camera.main;
        m_collider = GetComponent<Collider>();
        m_meshRenderer = GetComponent<MeshRenderer>();
        // 取材质实例，避免直接修改被多个Cube共享的材质资产
        m_material = m_meshRenderer.material;
        m_originalColor = m_material.color;

        // 缓存场景中所有玩家（含未激活对象，与GameController收集口径一致），成功点击时逐一通知
        m_players = FindObjectsByType<GamePlayer>(FindObjectsInactive.Include, FindObjectsSortMode.None);
    }

    void Update()
    {
        HandleClick();

        // 提示计时，归零时恢复原色
        if (m_highlightTimer > 0f)
        {
            m_highlightTimer -= Time.deltaTime;
            if (m_highlightTimer <= 0f)
            {
                m_highlightTimer = 0f;
                m_material.color = m_originalColor;
            }
        }
    }

    // ==================== 点击处理 ====================

    /// <summary>
    /// 每帧读取指针按下状态，检测"从未按下到按下"的边沿作为一次点击；
    /// 触屏优先（Device Simulator与真机上点击走Touchscreen），其次鼠标（编辑器Game视图）；
    /// 从主相机向指针位置发射线，命中自身Collider则变为提示色并重置计时，提示中再次点击同样有效
    /// （用状态边沿而非wasPressedThisFrame：编辑器中输入更新的消费时机可能落在Update相位之外，单帧标志会被吞掉）
    /// </summary>
    private void HandleClick()
    {
        // 触屏优先：模拟器/真机上点击被翻译为Touch事件，Mouse收不到
        Vector2 pointerPos = Vector2.zero;
        bool pressed = false;
        var touch = Touchscreen.current;
        if (touch != null && touch.primaryTouch.press.isPressed)
        {
            pressed = true;
            pointerPos = touch.primaryTouch.position.ReadValue();
        }
        else
        {
            var mouse = Mouse.current;
            if (mouse != null && mouse.leftButton.isPressed)
            {
                pressed = true;
                pointerPos = mouse.position.ReadValue();
            }
        }

        bool clicked = pressed && !m_wasPressed;
        m_wasPressed = pressed;

        // 功能未启用时忽略点击（按压边沿照常跟踪，避免重新启用时把旧按压误判为新点击）
        if (!clicked || !m_functionalityEnabled)
            return;

        if (m_mainCamera == null) m_mainCamera = Camera.main;
        if (m_mainCamera == null) return;

        Ray ray = m_mainCamera.ScreenPointToRay(pointerPos);
        if (Physics.Raycast(ray, out RaycastHit hit, 200f, m_moveKeyLayerMask) && hit.collider == m_collider)
        {
            m_material.color = m_highlightColor;
            m_highlightTimer = m_highlightDuration;

            // 成功点击：通知所有玩家向本MoveKey移动（是否移动由玩家自行判断）
            NotifyPlayersToMove();
        }
    }

    /// <summary>通知场景中所有玩家向本MoveKey移动（是否移动由玩家按自身功能开关与X坐标判断）</summary>
    private void NotifyPlayersToMove()
    {
        if (m_players == null)
            return;

        foreach (GamePlayer player in m_players)
        {
            player.RequestMoveTo(this);
        }
    }

    // ==================== 公开接口 ====================

    /// <summary>获取点击提示色</summary>
    public Color GetHighlightColor() => m_highlightColor;

    /// <summary>设置点击提示色</summary>
    public void SetHighlightColor(Color color) => m_highlightColor = color;

    /// <summary>获取提示色持续时间（秒）</summary>
    public float GetHighlightDuration() => m_highlightDuration;

    /// <summary>设置提示色持续时间（秒）</summary>
    public void SetHighlightDuration(float duration) => m_highlightDuration = duration;

    /// <summary>当前点击反馈功能是否启用</summary>
    public bool IsFunctionalityEnabled() => m_functionalityEnabled;

    /// <summary>
    /// 设置点击反馈功能是否启用；
    /// 禁用时立即清除提示计时并还原原色，避免残留在提示状态
    /// </summary>
    public void SetFunctionalityEnabled(bool enabled)
    {
        m_functionalityEnabled = enabled;

        if (!enabled)
        {
            m_highlightTimer = 0f;
            if (m_material != null)
            {
                m_material.color = m_originalColor;
            }
        }
    }
}
