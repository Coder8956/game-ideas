using UnityEngine;

namespace UGU.Runtime
{
/// <summary>
/// 第三人称动画控制器。
/// 继承自 UGUTPHMotor，负责将运动状态同步到 Animator 参数，
/// 以及根据移动速度计算输入幅度（InputMagnitude）。
/// </summary>
public class UGUTPHAnimator : UGUTPHMotor
{
    // ── 常量 ──────────────────────────────────────────────────

    /// <summary>行走动画速度阈值</summary>
    public const float WalkSpeed = 0.5f;
    /// <summary>跑步动画速度阈值</summary>
    public const float RunningSpeed = 1f;
    /// <summary>冲刺动画速度阈值</summary>
    public const float SprintSpeed = 1.5f;

    // ── 动画更新 ──────────────────────────────────────────────

    /// <summary>
    /// 每帧将角色运动状态同步到 Animator 参数：
    /// - 瞄准/冲刺/着地布尔值；
    /// - 地面距离浮点值；
    /// - 瞄准模式下的水平/垂直输入速度；
    /// - 自由模式下的垂直输入速度；
    /// - 输入幅度（InputMagnitude）。
    /// </summary>
    public virtual void UpdateAnimator()
    {
        if (m_animator == null || !m_animator.enabled) return;

        // 同步布尔参数
        m_animator.SetBool(UGUTPHAnimatorParameters.IsStrafing, IsStrafing);
        m_animator.SetBool(UGUTPHAnimatorParameters.IsSprinting, IsSprinting);
        m_animator.SetBool(UGUTPHAnimatorParameters.IsGrounded, IsGrounded);
        // 同步地面距离
        m_animator.SetFloat(UGUTPHAnimatorParameters.GroundDistance, m_groundDistance);

        if (IsStrafing)
        {
            // 瞄准模式：同时设置水平和垂直速度
            m_animator.SetFloat(UGUTPHAnimatorParameters.InputHorizontal, StopMove ? 0 : m_horizontalSpeed, m_strafeSpeed.animationSmooth, Time.deltaTime);
            m_animator.SetFloat(UGUTPHAnimatorParameters.InputVertical, StopMove ? 0 : m_verticalSpeed, m_strafeSpeed.animationSmooth, Time.deltaTime);
        }
        else
        {
            // 自由模式：仅设置垂直速度
            m_animator.SetFloat(UGUTPHAnimatorParameters.InputVertical, StopMove ? 0 : m_verticalSpeed, m_freeSpeed.animationSmooth, Time.deltaTime);
        }

        // 设置输入幅度（停止时为 0）
        m_animator.SetFloat(UGUTPHAnimatorParameters.InputMagnitude, StopMove ? 0f : m_inputMagnitude, IsStrafing ? m_strafeSpeed.animationSmooth : m_freeSpeed.animationSmooth, Time.deltaTime);
    }

    /// <summary>
    /// 根据移动方向和速度配置计算动画参数：
    /// 将世界空间移动方向转换为角色本地空间，得到前后/左右速度，
    /// 然后根据是否默认行走和是否冲刺来计算输入幅度。
    /// </summary>
    /// <param name="speed">当前移动速度配置</param>
    public virtual void SetAnimatorMoveSpeed(MovementSpeed speed)
    {
        // 将世界方向转换为角色本地空间方向
        Vector3 relativeInput = transform.InverseTransformDirection(m_moveDirection);
        m_verticalSpeed = relativeInput.z;
        m_horizontalSpeed = relativeInput.x;

        var newInput = new Vector2(m_verticalSpeed, m_horizontalSpeed);

        if (speed.walkByDefault)
        {
            // 默认行走：冲刺时上限为 RunningSpeed，否则 WalkSpeed
            m_inputMagnitude = Mathf.Clamp(newInput.magnitude, 0, IsSprinting ? RunningSpeed : WalkSpeed);
        }
        else
        {
            // 默认跑步：冲刺时输入幅度 +0.5 并限制在 SprintSpeed，否则 RunningSpeed
            m_inputMagnitude = Mathf.Clamp(IsSprinting ? newInput.magnitude + 0.5f : newInput.magnitude, 0, IsSprinting ? SprintSpeed : RunningSpeed);
        }
    }
}

/// <summary>
/// Animator 参数哈希值缓存类。
/// 使用 Animator.StringToHash 预计算参数名哈希，避免运行时字符串查找开销。
/// </summary>
public static partial class UGUTPHAnimatorParameters
{
    /// <summary>水平输入（左右移动），用于瞄准模式动画</summary>
    public static int InputHorizontal = Animator.StringToHash("InputHorizontal");
    /// <summary>垂直输入（前后移动），用于自由/瞄准模式动画</summary>
    public static int InputVertical = Animator.StringToHash("InputVertical");
    /// <summary>输入幅度（移动强度），用于混合树动画过渡</summary>
    public static int InputMagnitude = Animator.StringToHash("InputMagnitude");
    /// <summary>是否着地</summary>
    public static int IsGrounded = Animator.StringToHash("IsGrounded");
    /// <summary>是否瞄准/横移模式</summary>
    public static int IsStrafing = Animator.StringToHash("IsStrafing");
    /// <summary>是否冲刺</summary>
    public static int IsSprinting = Animator.StringToHash("IsSprinting");
    /// <summary>与地面的距离</summary>
    public static int GroundDistance = Animator.StringToHash("GroundDistance");
}
}
