using UnityEngine;

namespace UGU.Runtime
{
/// <summary>
/// 第三人称运动器（基类）。
/// 负责角色的物理初始化、地面检测、坡度限制、移动、旋转、
/// 跳跃和空中控制等底层运动逻辑。
/// </summary>
public class UGUTPHMotor : MonoBehaviour
{
    // ── Inspector 配置 ────────────────────────────────────────

    [Header("Movement")]

    [Tooltip("是否使用根位移（Root Motion）驱动移动。关闭时使用刚体速度移动，开启时根位移作为额外速度叠加")]
    [SerializeField] protected bool m_useRootMotion = false;

    [Tooltip("是否使用世界坐标轴旋转角色（关闭则使用相机坐标轴）——等距视角相机需开启")]
    [SerializeField] protected bool m_rotateByWorld = false;

    [Tooltip("持续冲刺模式：按下切换开关，角色持续冲刺直到体力耗尽或停止移动。\n关闭时角色仅在按键期间冲刺")]
    [SerializeField] protected bool m_useContinuousSprint = true;

    [Tooltip("是否仅在自由移动模式下才能冲刺")]
    [SerializeField] protected bool m_sprintOnlyFree = true;

    [Tooltip("移动类型：自由+瞄准混合 / 仅瞄准 / 仅自由")]
    [SerializeField] protected LocomotionType m_locomotionType = LocomotionType.FreeWithStrafe;

    [Tooltip("自由移动模式的速度配置")]
    [SerializeField] protected MovementSpeed m_freeSpeed;
    [Tooltip("瞄准移动模式的速度配置")]
    [SerializeField] protected MovementSpeed m_strafeSpeed;

    [Header("Airborne")]

    [Tooltip("跳跃时是否利用当前刚体速度影响跳跃距离")]
    [SerializeField] private bool m_jumpWithRigidbodyForce = false;

    [Tooltip("空中是否可以旋转角色")]
    [SerializeField] private bool m_jumpAndRotate = true;

    [Tooltip("跳跃持续时间（秒），在此期间持续施加向上力")]
    [SerializeField] protected float m_jumpTimer = 0.3f;

    [Tooltip("额外跳跃高度。设为 0 则仅依赖根位移跳跃")]
    [SerializeField] private float m_jumpHeight = 4f;

    [Tooltip("空中移动速度")]
    [SerializeField] private float m_airSpeed = 5f;

    [Tooltip("空中方向变化平滑度")]
    [SerializeField] private float m_airSmooth = 6f;

    [Tooltip("非着地时施加的额外重力")]
    [SerializeField] private float m_extraGravity = -10f;

    [Header("Ground")]

    [Tooltip("角色可行走的地面层")]
    [SerializeField] private LayerMask m_groundLayer = 1 << 0;

    [Tooltip("判定为离地的最小地面距离")]
    [SerializeField] private float m_groundMinDistance = 0.25f;

    [Tooltip("判定为完全离地的最大地面距离")]
    [SerializeField] private float m_groundMaxDistance = 0.5f;

    [Tooltip("可行走的最大坡度角（度）")]
    [Range(30, 80)]
    [SerializeField] private float m_slopeLimit = 75f;

    // ── 运行时状态 ──────────────────────────────────────────

    public Vector3 Input { get; set; }
    public Transform RotateTarget { get; set; }

    protected Animator m_animator;
    private Rigidbody m_rigidbody;
    /// <summary>常规摩擦物理材质（有输入时使用）</summary>
    private PhysicsMaterial m_frictionPhysics, m_maxFrictionPhysics, m_slippyPhysics;
    private CapsuleCollider m_capsuleCollider;

    /// <summary>输入幅度（0~1.5），用于动画混合树</summary>
    protected float m_inputMagnitude;
    /// <summary>本地空间垂直速度（前后）</summary>
    protected float m_verticalSpeed;
    /// <summary>本地空间水平速度（左右）</summary>
    protected float m_horizontalSpeed;
    /// <summary>当前移动速度（经过平滑插值）</summary>
    private float m_moveSpeed;
    /// <summary>垂直速度缓存（离地时记录）</summary>
    private float m_verticalVelocity;
    private float m_colliderRadius, m_colliderHeight;
    private Vector3 m_colliderCenter;
    /// <summary>跳跃达到的最高点 Y 坐标</summary>
    private float m_heightReached;
    /// <summary>跳跃剩余计时</summary>
    protected float m_jumpCounter;
    /// <summary>与地面的距离</summary>
    protected float m_groundDistance;
    private RaycastHit m_groundHit;
    /// <summary>锁定移动（停止所有移动逻辑）</summary>
    protected bool m_lockMovement = false;
    /// <summary>锁定旋转（停止所有旋转逻辑）</summary>
    protected bool m_lockRotation = false;
    /// <summary>平滑后的输入向量</summary>
    protected Vector3 m_inputSmooth;
    /// <summary>当前移动方向（世界空间）</summary>
    protected Vector3 m_moveDirection;

    // ── 属性 ─────────────────────────────────────────────────

    /// <summary>是否处于瞄准/横移模式</summary>
    public bool IsStrafing { get; set; }
    /// <summary>是否着地</summary>
    public bool IsGrounded { get; protected set; }
    /// <summary>是否冲刺中</summary>
    public bool IsSprinting { get; set; }
    /// <summary>是否跳跃中</summary>
    public bool IsJumping { get; protected set; }
    /// <summary>是否因坡度过大而停止移动</summary>
    public bool StopMove { get; protected set; }
    /// <summary>最大可行走坡度角</summary>
    public float SlopeLimit => m_slopeLimit;

    // ── 生命周期 ─────────────────────────────────────────────

    /// <summary>
    /// 初始化运动器：获取组件引用、创建物理材质、记录碰撞体原始尺寸。
    /// </summary>
    public void Init()
    {
        m_animator = GetComponent<Animator>();
        m_animator.updateMode = AnimatorUpdateMode.Fixed;

        // 创建常规摩擦材质（摩擦系数 0.25）
        m_frictionPhysics = new PhysicsMaterial
        {
            name = "frictionPhysics",
            staticFriction = .25f,
            dynamicFriction = .25f,
            frictionCombine = PhysicsMaterialCombine.Multiply
        };

        // 创建最大摩擦材质（静止时使用，防止滑动）
        m_maxFrictionPhysics = new PhysicsMaterial
        {
            name = "maxFrictionPhysics",
            staticFriction = 1f,
            dynamicFriction = 1f,
            frictionCombine = PhysicsMaterialCombine.Maximum
        };

        // 创建无摩擦材质（空中或陡坡时使用）
        m_slippyPhysics = new PhysicsMaterial
        {
            name = "slippyPhysics",
            staticFriction = 0f,
            dynamicFriction = 0f,
            frictionCombine = PhysicsMaterialCombine.Minimum
        };

        // strafe 模式始终跟随相机转向，固定覆盖 Inspector 配置
        m_strafeSpeed.rotateWithCamera = true;

        m_rigidbody = GetComponent<Rigidbody>();
        m_capsuleCollider = GetComponent<CapsuleCollider>();

        // 缓存碰撞体原始参数
        m_colliderCenter = m_capsuleCollider.center;
        m_colliderRadius = m_capsuleCollider.radius;
        m_colliderHeight = m_capsuleCollider.height;

        IsGrounded = true;
    }

    /// <summary>
    /// 每物理帧更新运动器：
    /// 地面检测 → 坡度限制检测 → 跳跃行为控制 → 空中控制。
    /// </summary>
    public virtual void UpdateMotor()
    {
        CheckGround();
        CheckSlopeLimit();
        ControlJumpBehaviour();
        AirControl();
    }

    // ── 移动逻辑 ─────────────────────────────────────────────

    /// <summary>
    /// 根据速度配置设置控制器移动速度。
    /// 默认行走模式下在行走/跑步间切换，否则在跑步/冲刺间切换。
    /// </summary>
    /// <param name="speed">移动速度配置</param>
    public virtual void SetControllerMoveSpeed(MovementSpeed speed)
    {
        if (speed.walkByDefault)
            // 默认行走：冲刺时用跑步速度，否则行走速度
            m_moveSpeed = Mathf.Lerp(m_moveSpeed, IsSprinting ? speed.runningSpeed : speed.walkSpeed, speed.movementSmooth * Time.deltaTime);
        else
            // 默认跑步：冲刺时用冲刺速度，否则跑步速度
            m_moveSpeed = Mathf.Lerp(m_moveSpeed, IsSprinting ? speed.sprintSpeed : speed.runningSpeed, speed.movementSmooth * Time.deltaTime);
    }

    /// <summary>
    /// 通过刚体速度驱动角色移动。
    /// 平滑输入后计算目标位置和目标速度，保留 Y 轴速度（重力/跳跃）。
    /// 着地且非跳跃时才执行移动。
    /// </summary>
    /// <param name="direction">移动方向</param>
    public virtual void MoveCharacter(Vector3 direction)
    {
        // 平滑输入向量
        m_inputSmooth = Vector3.Lerp(m_inputSmooth, Input, (IsStrafing ? m_strafeSpeed.movementSmooth : m_freeSpeed.movementSmooth) * Time.deltaTime);

        // 空中或跳跃中不执行地面移动
        if (!IsGrounded || IsJumping) return;

        // 规范化方向向量
        direction.y = 0;
        direction.x = Mathf.Clamp(direction.x, -1f, 1f);
        direction.z = Mathf.Clamp(direction.z, -1f, 1f);
        if (direction.magnitude > 1f)
            direction.Normalize();

        // 计算目标位置（根位移模式下叠加在动画根位置上）
        Vector3 targetPosition = (m_useRootMotion ? m_animator.rootPosition : m_rigidbody.position) + direction * (StopMove ? 0 : m_moveSpeed) * Time.deltaTime;
        // 目标速度 = 目标位移 / 时间
        Vector3 targetVelocity = (targetPosition - transform.position) / Time.deltaTime;

        // 保留 Y 轴速度（重力或跳跃）
        targetVelocity.y = m_rigidbody.linearVelocity.y;
        m_rigidbody.linearVelocity = targetVelocity;
    }

    /// <summary>
    /// 坡度限制检测：
    /// 从角色腰部向前方发射射线检测前方地面角度，
    /// 若超过坡度限制则停止移动，防止爬上过陡的斜坡。
    /// </summary>
    public virtual void CheckSlopeLimit()
    {
        if (Input.sqrMagnitude < 0.1) return;

        RaycastHit hitinfo;
        var hitAngle = 0f;

        // 从角色中部向前方检测地面角度
        if (Physics.Linecast(transform.position + Vector3.up * (m_capsuleCollider.height * 0.5f), transform.position + m_moveDirection.normalized * (m_capsuleCollider.radius + 0.2f), out hitinfo, m_groundLayer))
        {
            hitAngle = Vector3.Angle(Vector3.up, hitinfo.normal);

            // 前方坡度超限时，再向前方稍远处检测确认
            var targetPoint = hitinfo.point + m_moveDirection.normalized * m_capsuleCollider.radius;
            if ((hitAngle > m_slopeLimit) && Physics.Linecast(transform.position + Vector3.up * (m_capsuleCollider.height * 0.5f), targetPoint, out hitinfo, m_groundLayer))
            {
                hitAngle = Vector3.Angle(Vector3.up, hitinfo.normal);

                // 确认坡度超限且非近乎垂直 → 停止移动
                if (hitAngle > m_slopeLimit && hitAngle < 85f)
                {
                    StopMove = true;
                    return;
                }
            }
        }
        StopMove = false;
    }

    /// <summary>
    /// 旋转角色朝向指定位置。
    /// </summary>
    /// <param name="position">目标世界坐标位置</param>
    public virtual void RotateToPosition(Vector3 position)
    {
        Vector3 desiredDirection = position - transform.position;
        RotateToDirection(desiredDirection.normalized);
    }

    /// <summary>
    /// 旋转角色朝向指定方向，使用当前移动模式的旋转速度。
    /// </summary>
    /// <param name="direction">目标方向（世界空间）</param>
    public virtual void RotateToDirection(Vector3 direction)
    {
        RotateToDirection(direction, IsStrafing ? m_strafeSpeed.rotationSpeed : m_freeSpeed.rotationSpeed);
    }

    /// <summary>
    /// 旋转角色朝向指定方向，使用指定旋转速度。
    /// 空中且配置不允许空中旋转时跳过。
    /// </summary>
    /// <param name="direction">目标方向</param>
    /// <param name="rotationSpeed">旋转速度</param>
    public virtual void RotateToDirection(Vector3 direction, float rotationSpeed)
    {
        // 空中且不允许空中旋转时跳过
        if (!m_jumpAndRotate && !IsGrounded) return;
        direction.y = 0f;
        // 使用 RotateTowards 平滑旋转
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, direction.normalized, rotationSpeed * Time.deltaTime, .1f);
        Quaternion newRotation = Quaternion.LookRotation(desiredForward);
        transform.rotation = newRotation;
    }

    // ── 跳跃 ─────────────────────────────────────────────────

    /// <summary>
    /// 跳跃行为控制：
    /// 跳跃计时期间持续施加向上力（m_jumpHeight），
    /// 计时结束后清除跳跃状态。
    /// </summary>
    protected virtual void ControlJumpBehaviour()
    {
        if (!IsJumping) return;

        // 递减跳跃计时器
        m_jumpCounter -= Time.deltaTime;
        if (m_jumpCounter <= 0)
        {
            m_jumpCounter = 0;
            IsJumping = false;
        }
        // 持续施加向上速度
        var vel = m_rigidbody.linearVelocity;
        vel.y = m_jumpHeight;
        m_rigidbody.linearVelocity = vel;
    }

    /// <summary>
    /// 空中控制：
    /// - 记录达到的最高高度；
    /// - 平滑输入向量；
    /// - 根据配置使用刚体力或速度方式控制空中移动。
    /// </summary>
    public virtual void AirControl()
    {
        // 着地且非跳跃中 → 不需要空中控制
        if ((IsGrounded && !IsJumping)) return;

        // 记录最高点
        if (transform.position.y > m_heightReached) m_heightReached = transform.position.y;

        // 空中输入平滑
        m_inputSmooth = Vector3.Lerp(m_inputSmooth, Input, m_airSmooth * Time.deltaTime);

        // 模式一：使用刚体力驱动空中移动
        if (m_jumpWithRigidbodyForce && !IsGrounded)
        {
            m_rigidbody.AddForce(m_moveDirection * m_airSpeed * Time.deltaTime, ForceMode.VelocityChange);
            return;
        }

        // 模式二：使用速度驱动空中移动
        m_moveDirection.y = 0;
        m_moveDirection.x = Mathf.Clamp(m_moveDirection.x, -1f, 1f);
        m_moveDirection.z = Mathf.Clamp(m_moveDirection.z, -1f, 1f);

        Vector3 targetPosition = m_rigidbody.position + (m_moveDirection * m_airSpeed) * Time.deltaTime;
        Vector3 targetVelocity = (targetPosition - transform.position) / Time.deltaTime;

        // 保留 Y 轴速度
        targetVelocity.y = m_rigidbody.linearVelocity.y;
        // 平滑插值到目标速度
        m_rigidbody.linearVelocity = Vector3.Lerp(m_rigidbody.linearVelocity, targetVelocity, m_airSmooth * Time.deltaTime);
    }

    /// <summary>
    /// 跳跃前方条件检测：
    /// 从角色胶囊体底部到顶部发射胶囊投射，检测前方是否有障碍物。
    /// 无障碍物返回 true（可以向前跳跃移动）。
    /// </summary>
    protected virtual bool JumpFwdCondition
    {
        get
        {
            // 计算胶囊体上下两端中心点
            Vector3 p1 = transform.position + m_capsuleCollider.center + Vector3.up * -m_capsuleCollider.height * 0.5F;
            Vector3 p2 = p1 + Vector3.up * m_capsuleCollider.height;
            // 前方 0.6f 范围内无障碍物 → 可以前跳
            return Physics.CapsuleCastAll(p1, p2, m_capsuleCollider.radius * 0.5f, transform.forward, 0.6f, m_groundLayer).Length == 0;
        }
    }

    // ── 地面检测 ─────────────────────────────────────────────

    /// <summary>
    /// 地面检测主逻辑：
    /// 检测地面距离 → 更新物理材质 → 根据距离判定着地/离地状态。
    /// 离地时施加额外重力，接近地面时施加加倍重力以快速着地。
    /// </summary>
    protected virtual void CheckGround()
    {
        CheckGroundDistance();
        ControlMaterialPhysics();

        // 距离 ≤ 最小值 → 判定着地
        if (m_groundDistance <= m_groundMinDistance)
        {
            IsGrounded = true;
            // 略高于地面时施加加倍重力加速着地
            if (!IsJumping && m_groundDistance > 0.05f)
                m_rigidbody.AddForce(transform.up * (m_extraGravity * 2 * Time.deltaTime), ForceMode.VelocityChange);

            m_heightReached = transform.position.y;
        }
        else
        {
            // 距离 ≥ 最大值 → 判定离地
            if (m_groundDistance >= m_groundMaxDistance)
            {
                IsGrounded = false;
                m_verticalVelocity = m_rigidbody.linearVelocity.y;
                // 离地且非跳跃时施加额外重力
                if (!IsJumping)
                {
                    m_rigidbody.AddForce(transform.up * m_extraGravity * Time.deltaTime, ForceMode.VelocityChange);
                }
            }
            // 介于最小和最大距离之间：接近地面，施加加倍重力
            else if (!IsJumping)
            {
                m_rigidbody.AddForce(transform.up * (m_extraGravity * 2 * Time.deltaTime), ForceMode.VelocityChange);
            }
        }
    }

    /// <summary>
    /// 根据状态切换胶囊体碰撞器的物理材质：
    /// - 着地且无输入 → 最大摩擦（防滑）；
    /// - 着地且有输入 → 常规摩擦；
    /// - 空中或陡坡 → 无摩擦（平滑滑动）。
    /// </summary>
    protected virtual void ControlMaterialPhysics()
    {
        m_capsuleCollider.material = (IsGrounded && GroundAngle() <= m_slopeLimit + 1) ? m_frictionPhysics : m_slippyPhysics;

        if (IsGrounded && Input == Vector3.zero)
            m_capsuleCollider.material = m_maxFrictionPhysics;
        else if (IsGrounded && Input != Vector3.zero)
            m_capsuleCollider.material = m_frictionPhysics;
        else
            m_capsuleCollider.material = m_slippyPhysics;
    }

    /// <summary>
    /// 精确计算角色与地面的距离：
    /// 1. 先从角色中心向下射线检测；
    /// 2. 若距离不足，再用球体投射从角色顶部向下检测；
    /// 3. 取两者中的较小值，四舍五入到两位小数。
    /// </summary>
    protected virtual void CheckGroundDistance()
    {
        if (m_capsuleCollider != null)
        {
            float radius = m_capsuleCollider.radius * 0.9f;
            var dist = 10f;

            // 第一次检测：从角色中心向下射线
            Ray ray2 = new Ray(transform.position + new Vector3(0, m_colliderHeight / 2, 0), Vector3.down);
            if (Physics.Raycast(ray2, out m_groundHit, (m_colliderHeight / 2) + dist, m_groundLayer) && !m_groundHit.collider.isTrigger)
                dist = transform.position.y - m_groundHit.point.y;

            // 距离不足时进行第二次检测：球体投射
            if (dist >= m_groundMinDistance)
            {
                Vector3 pos = transform.position + Vector3.up * (m_capsuleCollider.radius);
                Ray ray = new Ray(pos, -Vector3.up);
                if (Physics.SphereCast(ray, radius, out m_groundHit, m_capsuleCollider.radius + m_groundMaxDistance, m_groundLayer) && !m_groundHit.collider.isTrigger)
                {
                    // 精确化检测：从击中点上方再向下短距离射线
                    Physics.Linecast(m_groundHit.point + (Vector3.up * 0.1f), m_groundHit.point + Vector3.down * 0.15f, out m_groundHit, m_groundLayer);
                    float newDist = transform.position.y - m_groundHit.point.y;
                    if (dist > newDist) dist = newDist;
                }
            }
            m_groundDistance = (float)System.Math.Round(dist, 2);
        }
    }

    /// <summary>
    /// 返回当前地面法线与世界上方的夹角（度）。
    /// </summary>
    /// <returns>地面角度</returns>
    public virtual float GroundAngle()
    {
        var groundAngle = Vector3.Angle(m_groundHit.normal, Vector3.up);
        return groundAngle;
    }

    /// <summary>
    /// 返回移动方向相对于地面的角度（度）。
    /// 瞄准模式使用输入方向，自由模式使用角色朝向。
    /// </summary>
    /// <returns>移动方向与地面法线的夹角减 90 度</returns>
    public virtual float GroundAngleFromDirection()
    {
        var dir = IsStrafing && Input.magnitude > 0 ? (transform.right * Input.x + transform.forward * Input.z).normalized : transform.forward;
        var movementAngle = Vector3.Angle(dir, m_groundHit.normal) - 90;
        return movementAngle;
    }

    // ── 序列化配置类 ─────────────────────────────────────────

    /// <summary>
    /// 移动类型枚举。
    /// </summary>
    public enum LocomotionType
    {
        /// <summary>自由+瞄准混合（可切换）</summary>
        FreeWithStrafe,
        /// <summary>仅瞄准模式</summary>
        OnlyStrafe,
        /// <summary>仅自由模式</summary>
        OnlyFree,
    }

    /// <summary>
    /// 移动速度配置类。
    /// 包含移动平滑度、动画平滑度、旋转速度、行走/跑步/冲刺速度等参数。
    /// </summary>
    [System.Serializable]
    public class MovementSpeed
    {
        [Tooltip("移动平滑度（插值速度）")]
        [Range(1f, 20f)]
        public float movementSmooth = 6f;

        [Tooltip("动画参数平滑度")]
        [Range(0f, 1f)]
        public float animationSmooth = 0.2f;

        [Tooltip("角色旋转速度")]
        public float rotationSpeed = 16f;

        [Tooltip("默认行走（关闭则默认跑步）")]
        public bool walkByDefault = false;

        [Tooltip("静止时是否跟随相机朝向旋转（仅自由移动模式生效，strafe 模式固定为 true）")]
        [HideInInspector]
        public bool rotateWithCamera = false;

        [Tooltip("行走速度（刚体驱动，或根位移时的额外速度）")]
        public float walkSpeed = 2f;

        [Tooltip("跑步速度（刚体驱动，或根位移时的额外速度）")]
        public float runningSpeed = 4f;

        [Tooltip("冲刺速度（刚体驱动，或根位移时的额外速度）")]
        public float sprintSpeed = 6f;
    }
}
}
