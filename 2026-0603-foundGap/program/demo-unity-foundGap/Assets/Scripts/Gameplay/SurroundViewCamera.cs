using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 环绕观察相机
/// 以目标物体为中心，使用鼠标环绕观察：
/// 1. 交互全部使用 Unity 新输入系统（UnityEngine.InputSystem）
/// 2. 鼠标拖拽以目标为中心环绕观察，采用轨迹球旋转（俯仰不受极点限制），
///    可连续越过目标正上/正下方，实现无死角环绕
/// 3. 可配置按键（默认鼠标中键）一键回到默认机位（Awake 时记录的朝向与距离）
/// 4. 旋转交互模式可配置：
///    4.1 自由模式——始终跟随鼠标观察；
///    4.2 按键模式——按住配置键（默认鼠标右键）时跟随鼠标观察
/// </summary>
public class SurroundViewCamera : MonoBehaviour
{
    // ==================== 枚举 ====================

    /// <summary>旋转交互模式</summary>
    public enum RotationMode
    {
        /// <summary>自由模式：始终跟随鼠标观察</summary>
        Free = 0,

        /// <summary>按键模式：按住旋转键（默认鼠标右键）时跟随鼠标观察</summary>
        HoldButton = 1,
    }

    // ==================== Inspector 字段 ====================

    [Header("观察设置")]

    [Tooltip("环绕观察的中心目标；未设置时以世界原点为中心")]
    [SerializeField] private Transform m_target;

    [Tooltip("旋转交互模式：自由模式=始终跟随鼠标；按键模式=按住旋转键时跟随鼠标")]
    [SerializeField] private RotationMode m_rotationMode = RotationMode.Free;

    [Tooltip("旋转灵敏度（度/像素）")]
    [SerializeField] private float m_rotateSpeed = 0.25f;

    [Header("按键设置")]

    [Tooltip("回到默认机位的按键，默认：鼠标中键")]
    [SerializeField] private InputActionProperty m_resetAction = new InputActionProperty(
        new InputAction("ResetView", InputActionType.Button, "<Mouse>/middleButton"));

    [Tooltip("按键模式下按住后跟随鼠标旋转的按键，默认：鼠标右键")]
    [SerializeField] private InputActionProperty m_rotateAction = new InputActionProperty(
        new InputAction("HoldToRotate", InputActionType.Button, "<Mouse>/rightButton"));

    // ==================== 私有字段 ====================

    /// <summary>默认机位朝向（Awake 时对准目标记录）</summary>
    private Quaternion m_defaultRotation;

    /// <summary>默认机位距目标距离（Awake 时记录）</summary>
    private float m_defaultDistance;

    /// <summary>当前距目标的环绕距离</summary>
    private float m_distance;

    /// <summary>是否已记录默认机位（Awake 完成后为 true）</summary>
    private bool m_hasDefaultView;

    /// <summary>m_target 未赋值的警告是否已输出过（避免每帧刷屏）</summary>
    private bool m_targetMissingWarned;

    // ==================== 生命周期 ====================

    void Awake()
    {
        Vector3 toCenter = GetCenter() - transform.position;
        m_distance = toCenter.magnitude;

        if (m_distance < 0.0001f)
        {
            // 相机与目标重合时无法环绕观察：保持当前朝向、按朝向后退默认距离
            Debug.LogWarning("[SurroundViewCamera] 相机初始位置与目标重合，已按当前朝向后退默认距离 5。", this);
            m_distance = 5f;
            m_defaultRotation = transform.rotation;
        }
        else
        {
            // 初始机位对准目标（不改变位置），避免第一帧跳变
            Vector3 dir = toCenter.normalized;
            Vector3 up = Mathf.Abs(Vector3.Dot(dir, Vector3.up)) > 0.999f ? Vector3.forward : Vector3.up;
            m_defaultRotation = Quaternion.LookRotation(dir, up);
            transform.rotation = m_defaultRotation;
        }

        m_defaultDistance = m_distance;
        m_hasDefaultView = true;
    }

    void OnEnable()
    {
        EnableAction(m_resetAction);
        EnableAction(m_rotateAction);
    }

    void OnDisable()
    {
        DisableAction(m_resetAction);
        DisableAction(m_rotateAction);
    }

    void LateUpdate()
    {
        // 一键回到默认机位
        if (WasActionPressedThisFrame(m_resetAction))
        {
            ResetToDefaultView();
            return;
        }

        // 按交互模式判断本帧是否跟随鼠标旋转
        if (m_rotationMode == RotationMode.Free || IsActionHeld(m_rotateAction))
        {
            Mouse mouse = Mouse.current;
            if (mouse != null)
            {
                Vector2 delta = mouse.delta.ReadValue();
                if (delta != Vector2.zero)
                {
                    ApplyOrbit(delta);
                }
            }
        }

        // 每帧以目标为中心刷新位置（目标移动时相机自动跟随保持环绕）
        UpdatePositionFromRotation();
    }

    // ==================== 逻辑 ====================

    /// <summary>
    /// 按鼠标增量环绕目标旋转（轨迹球方式）：
    /// 水平拖拽绕相机当前上轴、垂直拖拽绕相机当前右轴旋转；
    /// 俯仰不受极点限制，可连续越过目标正上/正下方，实现无死角环绕。
    /// </summary>
    private void ApplyOrbit(Vector2 mouseDelta)
    {
        Quaternion rotation = transform.rotation;

        // 鼠标向右拖拽：相机绕自身上轴环绕（等效于把目标向右拖转）
        rotation = Quaternion.AngleAxis(mouseDelta.x * m_rotateSpeed, rotation * Vector3.up) * rotation;
        // 鼠标向下拖拽：相机绕自身右轴向上越过目标（等效于把目标向下翻转）
        rotation = Quaternion.AngleAxis(-mouseDelta.y * m_rotateSpeed, rotation * Vector3.right) * rotation;

        transform.rotation = rotation;
        UpdatePositionFromRotation();
    }

    /// <summary>保持当前朝向，把相机放到以目标为中心、距离 m_distance 的环绕轨道上</summary>
    private void UpdatePositionFromRotation()
    {
        transform.position = GetCenter() - transform.forward * m_distance;
    }

    /// <summary>获取环绕中心：目标位置；目标未设置时回退世界原点（只警告一次）</summary>
    private Vector3 GetCenter()
    {
        if (m_target != null)
        {
            return m_target.position;
        }

        if (!m_targetMissingWarned)
        {
            m_targetMissingWarned = true;
            Debug.LogWarning("[SurroundViewCamera] 未设置观察目标（m_target），已回退以世界原点为中心。", this);
        }
        return Vector3.zero;
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

    /// <summary>动作对应按键是否正处于按住状态</summary>
    private static bool IsActionHeld(InputActionProperty property)
    {
        return property.action != null && property.action.IsPressed();
    }

    // ==================== 公开接口 ====================

    /// <summary>获取观察目标</summary>
    public Transform GetTarget() => m_target;

    /// <summary>设置观察目标</summary>
    public void SetTarget(Transform target) => m_target = target;

    /// <summary>获取旋转交互模式</summary>
    public RotationMode GetRotationMode() => m_rotationMode;

    /// <summary>设置旋转交互模式</summary>
    public void SetRotationMode(RotationMode mode) => m_rotationMode = mode;

    /// <summary>获取旋转灵敏度（度/像素）</summary>
    public float GetRotateSpeed() => m_rotateSpeed;

    /// <summary>设置旋转灵敏度（度/像素）</summary>
    public void SetRotateSpeed(float speed) => m_rotateSpeed = speed;

    /// <summary>回到默认机位：恢复 Awake 时记录的朝向与距离（便于 UI 等外部调用）</summary>
    public void ResetToDefaultView()
    {
        if (!m_hasDefaultView)
        {
            return;
        }

        transform.rotation = m_defaultRotation;
        m_distance = m_defaultDistance;
        UpdatePositionFromRotation();
    }
}
