using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 游戏控制器
/// 负责全局玩法功能：
/// 1. 切换准星 UI（ImgCrosshair）显示/隐藏：按下配置按键（默认 F 键）在显示与隐藏之间切换，
///    交互使用 Unity 新输入系统（UnityEngine.InputSystem），按键可在 Inspector 中更改
/// </summary>
public class GameController : MonoBehaviour
{
    // ==================== Inspector 字段 ====================

    [Header("UI 设置")]

    [Tooltip("准星 UI 对象（ImgCrosshair）；未设置时只警告一次并忽略按键切换")]
    [SerializeField] private GameObject m_crosshair;

    [Tooltip("切换准星显示/隐藏的按键，默认：F 键")]
    [SerializeField] private InputActionProperty m_toggleCrosshairAction = new InputActionProperty(
        new InputAction("ToggleCrosshair", InputActionType.Button, "<Keyboard>/f"));

    // ==================== 私有字段 ====================

    /// <summary>m_crosshair 未赋值的警告是否已输出过（避免每帧刷屏）</summary>
    private bool m_crosshairMissingWarned;

    // ==================== 生命周期 ====================

    void OnEnable()
    {
        EnableAction(m_toggleCrosshairAction);
    }

    void OnDisable()
    {
        DisableAction(m_toggleCrosshairAction);
    }

    void Update()
    {
        // 按下切换键：在显示与隐藏之间切换准星 UI
        if (WasActionPressedThisFrame(m_toggleCrosshairAction))
        {
            ToggleCrosshair();
        }
    }

    // ==================== 输入 ====================

    /// <summary>启用输入动作</summary>
    private static void EnableAction(InputActionProperty property)
    {
        if (property.action != null)
        {
            property.action.Enable();
        }
    }

    /// <summary>禁用输入动作</summary>
    private static void DisableAction(InputActionProperty property)
    {
        if (property.action != null)
        {
            property.action.Disable();
        }
    }

    /// <summary>动作对应按键是否在本帧被按下</summary>
    private static bool WasActionPressedThisFrame(InputActionProperty property)
    {
        return property.action != null && property.action.WasPressedThisFrame();
    }

    // ==================== 公开接口 ====================

    /// <summary>获取准星 UI 对象</summary>
    public GameObject GetCrosshair() => m_crosshair;

    /// <summary>设置准星 UI 对象</summary>
    public void SetCrosshair(GameObject crosshair) => m_crosshair = crosshair;

    /// <summary>准星 UI 是否正在显示（激活状态）；未设置时恒为 false</summary>
    public bool IsCrosshairVisible() => m_crosshair != null && m_crosshair.activeSelf;

    /// <summary>
    /// 切换准星 UI 显示/隐藏：取当前激活状态的反值（便于按键与 UI 等外部调用）；
    /// m_crosshair 未设置时回退为忽略切换并只警告一次。
    /// </summary>
    public void ToggleCrosshair()
    {
        if (m_crosshair == null)
        {
            if (!m_crosshairMissingWarned)
            {
                m_crosshairMissingWarned = true;
                Debug.LogWarning("[GameController] 未设置准星对象（m_crosshair），切换已被忽略。", this);
            }
            return;
        }

        m_crosshair.SetActive(!m_crosshair.activeSelf);
    }
}
