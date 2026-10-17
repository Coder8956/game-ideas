using UnityEngine;
using UnityEngine.InputSystem;

namespace UGU.Runtime
{
/// <summary>
/// 第三人称控制器。
/// 继承自 UGUTPHAnimator，负责根位移控制、移动类型切换、
/// 旋转控制、冲刺/瞄准/跳跃等动作输入的处理。
/// 独立处理键盘输入，并与 UGUTPCamera 协同工作。
/// </summary>
public class UGUTPHController : UGUTPHAnimator
{
    // ── 输入配置 ──────────────────────────────────────────────

    [Header("Input")]

    [Tooltip("向前移动按键（主）")]
    [SerializeField] protected Key m_moveForwardKey = Key.W;
    [Tooltip("向后移动按键（主）")]
    [SerializeField] protected Key m_moveBackwardKey = Key.S;
    [Tooltip("向左移动按键（主）")]
    [SerializeField] protected Key m_moveLeftKey = Key.A;
    [Tooltip("向右移动按键（主）")]
    [SerializeField] protected Key m_moveRightKey = Key.D;

    [Tooltip("向前移动按键（备用，方向键）")]
    [SerializeField] protected Key m_moveForwardAltKey = Key.UpArrow;
    [Tooltip("向后移动按键（备用，方向键）")]
    [SerializeField] protected Key m_moveBackwardAltKey = Key.DownArrow;
    [Tooltip("向左移动按键（备用，方向键）")]
    [SerializeField] protected Key m_moveLeftAltKey = Key.LeftArrow;
    [Tooltip("向右移动按键（备用，方向键）")]
    [SerializeField] protected Key m_moveRightAltKey = Key.RightArrow;

    [Tooltip("瞄准/横移切换按键")]
    [SerializeField] protected Key m_strafeKey = Key.Tab;
    [Tooltip("冲刺按键")]
    [SerializeField] protected Key m_sprintKey = Key.LeftShift;
    [Tooltip("跳跃按键")]
    [SerializeField] protected Key m_jumpKey = Key.Space;

    // ── 运行时状态 ──────────────────────────────────────────

    /// <summary>场景中的第三人称相机</summary>
    public UGUTPCamera TpCamera { get; private set; }
    /// <summary>主相机</summary>
    public Camera CameraMain { get; private set; }

    // ── 生命周期 ─────────────────────────────────────────────

    /// <summary>初始化：调用 Init 并初始化相机</summary>
    protected virtual void Start()
    {
        Init();
        InitializeTpCamera();
    }

    /// <summary>固定更新：驱动运动器与移动类型控制</summary>
    protected virtual void FixedUpdate()
    {
        UpdateMotor();
        ControlLocomotionType();
    }

    /// <summary>每帧更新：处理输入并更新动画</summary>
    protected virtual void Update()
    {
        InputHandle();
        UpdateAnimator();
    }

    /// <summary>延迟更新：在相机 Update 之后执行旋转控制，消除帧间延迟导致的转向卡顿</summary>
    protected virtual void LateUpdate()
    {
        ControlRotationType();
    }

    /// <summary>动画根位移回调：由 Animator 驱动角色位移</summary>
    public virtual void OnAnimatorMove()
    {
        ControlAnimatorRootMotion();
    }

    // ── 相机初始化 ────────────────────────────────────────────

    /// <summary>
    /// 查找场景中的 UGUTPCamera 并将其主目标设为当前角色。
    /// </summary>
    protected virtual void InitializeTpCamera()
    {
        if (TpCamera == null)
        {
            TpCamera = FindFirstObjectByType<UGUTPCamera>();
            if (TpCamera == null)
                return;
            TpCamera.SetMainTarget(this.transform);
        }
    }

    // ── 输入处理 ──────────────────────────────────────────────

    /// <summary>
    /// 每帧输入总入口，依次处理移动、相机引用、冲刺、瞄准、跳跃。
    /// </summary>
    protected virtual void InputHandle()
    {
        MoveInput();
        UpdateCameraReference();
        SprintInput();
        StrafeInput();
        JumpInput();
    }

    /// <summary>
    /// 读取 WASD/方向键输入，写入 Input 向量。
    /// X 轴：A/D（左右），Z 轴：W/S（前后）。
    /// </summary>
    public virtual void MoveInput()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        var newInput = Input;
        newInput.x = (keyboard[m_moveRightKey].isPressed || keyboard[m_moveRightAltKey].isPressed ? 1f : 0f)
                   - (keyboard[m_moveLeftKey].isPressed || keyboard[m_moveLeftAltKey].isPressed ? 1f : 0f);
        newInput.z = (keyboard[m_moveForwardKey].isPressed || keyboard[m_moveForwardAltKey].isPressed ? 1f : 0f)
                   - (keyboard[m_moveBackwardKey].isPressed || keyboard[m_moveBackwardAltKey].isPressed ? 1f : 0f);
        Input = newInput;
    }

    /// <summary>
    /// 查找主相机并设置旋转参考目标，然后根据相机朝向更新角色移动方向。
    /// </summary>
    protected virtual void UpdateCameraReference()
    {
        if (!CameraMain)
        {
            if (!Camera.main) Debug.Log("Missing a Camera with the tag MainCamera, please add one.");
            else
            {
                CameraMain = Camera.main;
                RotateTarget = CameraMain.transform;
            }
        }

        if (CameraMain)
        {
            UpdateMoveDirection(CameraMain.transform);
        }
    }

    /// <summary>
    /// Tab 键切换瞄准/横移模式。
    /// </summary>
    protected virtual void StrafeInput()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard[m_strafeKey].wasPressedThisFrame)
            Strafe();
    }

    /// <summary>
    /// 左 Shift 键按下/松开切换冲刺状态。
    /// </summary>
    protected virtual void SprintInput()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard[m_sprintKey].wasPressedThisFrame)
            Sprint(true);
        else if (keyboard[m_sprintKey].wasReleasedThisFrame)
            Sprint(false);
    }

    /// <summary>
    /// 跳跃条件判定：着地、坡度小于限制、非跳跃中、非停止移动。
    /// </summary>
    /// <returns>是否满足跳跃条件</returns>
    protected virtual bool JumpConditions()
    {
        return IsGrounded && GroundAngle() < SlopeLimit && !IsJumping && !StopMove;
    }

    /// <summary>
    /// 空格键触发跳跃（满足条件时）。
    /// </summary>
    protected virtual void JumpInput()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard[m_jumpKey].wasPressedThisFrame && JumpConditions())
            Jump();
    }

    // ── 根位移控制 ────────────────────────────────────────────

    /// <summary>
    /// 控制动画根位移的应用：
    /// - 无输入时直接使用动画的根位置和根旋转；
    /// - 启用根位移时通过 MoveCharacter 应用额外移动方向。
    /// </summary>
    public virtual void ControlAnimatorRootMotion()
    {
        if (!this.enabled) return;

        // 无输入时直接同步动画根位移结果
        if (m_inputSmooth == Vector3.zero)
        {
            transform.position = m_animator.rootPosition;
            transform.rotation = m_animator.rootRotation;
        }

        // 启用根位移时叠加移动方向
        if (m_useRootMotion)
            MoveCharacter(m_moveDirection);
    }

    // ── 移动类型控制 ──────────────────────────────────────────

    /// <summary>
    /// 根据移动类型（自由/瞄准/混合）设置移动速度和动画速度。
    /// 非根位移模式下直接驱动角色移动。
    /// </summary>
    public virtual void ControlLocomotionType()
    {
        if (m_lockMovement) return;

        // 自由移动模式：使用自由速度
        if (m_locomotionType.Equals(LocomotionType.FreeWithStrafe) && !IsStrafing || m_locomotionType.Equals(LocomotionType.OnlyFree))
        {
            SetControllerMoveSpeed(m_freeSpeed);
            SetAnimatorMoveSpeed(m_freeSpeed);
        }
        // 瞄准移动模式：使用瞄准速度
        else if (m_locomotionType.Equals(LocomotionType.OnlyStrafe) || m_locomotionType.Equals(LocomotionType.FreeWithStrafe) && IsStrafing)
        {
            IsStrafing = true;
            SetControllerMoveSpeed(m_strafeSpeed);
            SetAnimatorMoveSpeed(m_strafeSpeed);
        }

        // 非根位移模式直接驱动刚体移动
        if (!m_useRootMotion)
            MoveCharacter(m_moveDirection);
    }

    // ── 旋转控制 ──────────────────────────────────────────────

    /// <summary>
    /// 控制角色旋转：
    /// 根据是否有输入或是否跟随相机旋转来决定旋转方向，
    /// 平滑插值输入向量后旋转角色。
    /// </summary>
    public virtual void ControlRotationType()
    {
        if (m_lockRotation) return;

        // 判定是否需要旋转：有输入 或 瞄准模式（始终朝向相机）或 配置了静止时跟随相机
        bool validInput = Input != Vector3.zero || IsStrafing || m_freeSpeed.rotateWithCamera;

        if (validInput)
        {
            // 平滑输入向量
            m_inputSmooth = Vector3.Lerp(m_inputSmooth, Input, (IsStrafing ? m_strafeSpeed.movementSmooth : m_freeSpeed.movementSmooth) * Time.deltaTime);

            // 获取相机前方向：优先使用 TpCamera.LookForward（Update 中已更新），回退到 RotateTarget
            Vector3 cameraForward = TpCamera != null ? TpCamera.LookForward : (RotateTarget ? RotateTarget.forward : Vector3.forward);

            // 确定旋转方向：
            // - 瞄准模式（非冲刺或允许瞄准冲刺）或静止且配置跟随相机 → 朝相机方向
            // - 否则 → 朝移动方向
            bool useCameraDir = (IsStrafing && (!IsSprinting || m_sprintOnlyFree == false) || (m_freeSpeed.rotateWithCamera && Input == Vector3.zero));
            Vector3 dir = useCameraDir ? cameraForward : m_moveDirection;
            RotateToDirection(dir);
        }
    }

    /// <summary>
    /// 更新移动方向向量。
    /// 有参考变换（相机）时基于相机朝向计算本地方向；否则使用世界方向。
    /// 无输入时平滑回零。
    /// </summary>
    /// <param name="referenceTransform">参考变换（通常为主相机）</param>
    public virtual void UpdateMoveDirection(Transform referenceTransform = null)
    {
        // 无输入时平滑归零
        if (Input.magnitude <= 0.01)
        {
            m_moveDirection = Vector3.Lerp(m_moveDirection, Vector3.zero, (IsStrafing ? m_strafeSpeed.movementSmooth : m_freeSpeed.movementSmooth) * Time.deltaTime);
            return;
        }

        if (referenceTransform && !m_rotateByWorld)
        {
            // 基于相机朝向计算移动方向（相机右方 = 角色右方，相机右方旋转 -90° = 角色前方）
            var right = referenceTransform.right;
            right.y = 0;
            var forward = Quaternion.AngleAxis(-90, Vector3.up) * right;
            m_moveDirection = (m_inputSmooth.x * right) + (m_inputSmooth.z * forward);
        }
        else
        {
            // 世界坐标方向
            m_moveDirection = new Vector3(m_inputSmooth.x, 0, m_inputSmooth.z);
        }
    }

    // ── 动作输入 ──────────────────────────────────────────────

    /// <summary>
    /// 冲刺切换逻辑：
    /// - 持续冲刺模式下每次按下切换开关；
    /// - 非持续模式下按下开启、松开关闭；
    /// - 需满足冲刺条件（有输入、着地等）。
    /// </summary>
    /// <param name="value">true = 按下，false = 松开</param>
    public virtual void Sprint(bool value)
    {
        // 冲刺条件：有输入、着地、且不处于瞄准行走中
        var sprintConditions = (Input.sqrMagnitude > 0.1f && IsGrounded &&
            !(IsStrafing && !m_strafeSpeed.walkByDefault && (m_horizontalSpeed >= 0.5 || m_horizontalSpeed <= -0.5 || m_verticalSpeed <= 0.1f)));

        if (value && sprintConditions)
        {
            if (Input.sqrMagnitude > 0.1f)
            {
                if (IsGrounded && m_useContinuousSprint)
                {
                    // 持续冲刺：切换开关
                    IsSprinting = !IsSprinting;
                }
                else if (!IsSprinting)
                {
                    // 非持续冲刺：按下即开
                    IsSprinting = true;
                }
            }
            else if (!m_useContinuousSprint && IsSprinting)
            {
                IsSprinting = false;
            }
        }
        else if (IsSprinting)
        {
            // 不满足条件时关闭冲刺
            IsSprinting = false;
        }
    }

    /// <summary>
    /// 切换瞄准/横移模式。
    /// </summary>
    public virtual void Strafe()
    {
        IsStrafing = !IsStrafing;
    }

    /// <summary>
    /// 跳跃：设置跳跃计时器并播放跳跃动画。
    /// 静止时播放原地跳跃，移动时播放移动跳跃。
    /// </summary>
    public virtual void Jump()
    {
        m_jumpCounter = m_jumpTimer;
        IsJumping = true;

        // 根据是否移动选择不同跳跃动画
        if (Input.sqrMagnitude < 0.1f)
            m_animator.CrossFadeInFixedTime("Jump", 0.1f);
        else
            m_animator.CrossFadeInFixedTime("JumpMove", .2f);
    }
}
}
