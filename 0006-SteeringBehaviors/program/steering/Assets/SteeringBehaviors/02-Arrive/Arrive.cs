using UnityEngine;

/// <summary>
/// Arrive 到达行为：驶向鼠标点击放置的目标球（PlacedSphere），并以接近零速度停在目标处。
///
/// Arrive 转向计算直接依据 Buckland《Programming Game AI by Example》第 3 章
/// SteeringBehaviors.cpp 中的 SteeringBehavior::Arrive：
///   1. 计算到目标的距离；
///   2. 用 distance / (deceleration × 0.3) 得到到达所需速度，并限制到 MaxSpeed；
///   3. 期望速度 = 指向目标的向量 × 所需速度 / 距离；
///   4. 转向力 = 期望速度 - 当前速度；目标距离为零时返回零转向力。
///
/// 此 Unity 示例只实现 Arrive 行为；力到运动的积分、目标查找及调试绘制
/// 按本项目 Seek 脚本的结构实现。运动限制在 XZ 平面，保留物体原有高度。
/// </summary>
public class Arrive : MonoBehaviour
{
    // ==================== 私有字段 ====================

    [Header("目标设置")] [SerializeField] private string m_targetName = "PlacedSphere"; // 相机点击放置器创建的目标球名称

    [Header("车辆参数（对应 Buckland 的 MaxSpeed / MaxForce / Mass）")] [SerializeField]
    private float m_maxSpeed = 8f; // 最大速度：Arrive 的期望速度上限

    [SerializeField] private float m_maxForce = 24f; // 最大转向力：截断单帧可施加的力
    [SerializeField] private float m_mass = 1f; // 质量：决定转向力产生加速度的大小

    [Header("Arrive 减速档位（对应 C++ Deceleration 枚举）")] [SerializeField]
    private Deceleration m_deceleration = Deceleration.Normal; // Slow 更早减速，Fast 更晚减速

    [Header("Debug 设置")] [SerializeField] private bool m_debugDrawGizmos = true; // 是否绘制运行时调试信息
    [SerializeField] private Color m_velocityColor = Color.green; // 当前速度向量颜色
    [SerializeField] private Color m_forceColor = Color.yellow; // 当前转向力向量颜色
    [SerializeField] private Color m_targetLineColor = Color.red; // 自身到目标的连线颜色

    /// <summary>与 Buckland C++ Deceleration 枚举一致：slow=3、normal=2、fast=1。</summary>
    public enum Deceleration
    {
        Slow = 3,
        Normal = 2,
        Fast = 1
    }

    private Transform m_target; // 缓存目标球，避免每帧按名称查找
    private Vector3 m_velocity; // 当前速度（仅 XZ 分量有效）
    private Vector3 m_lastSteeringForce; // 最近一帧转向力，仅用于 Gizmos 绘制

    // ==================== 生命周期 ====================

    private void Update()
    {
        // 目标尚未生成（还没点击）或已销毁时先尝试按名称重新查找；找不到就原地等待。
        if (m_target == null)
        {
            GameObject targetObject = GameObject.Find(m_targetName);
            if (targetObject == null)
                return;

            m_target = targetObject.transform;
        }

        float deltaTime = Time.deltaTime;

        // 计算 Arrive 转向力，并按 Buckland 的最大转向力限制截断。
        Vector3 steeringForce = CalculateArriveSteering(m_target.position);
        steeringForce = Vector3.ClampMagnitude(steeringForce, m_maxForce);
        m_lastSteeringForce = steeringForce;

        // 按 F = ma 将力换算为加速度，再依时间积分速度。
        Vector3 acceleration = steeringForce / m_mass;
        m_velocity += acceleration * deltaTime;

        // 限制实际速度并积分位置；速度的 y 分量保持为零，因此物体不改变高度。
        m_velocity = Vector3.ClampMagnitude(m_velocity, m_maxSpeed);
        transform.position += m_velocity * deltaTime;

        // Debug.Log($"m_velocity: {m_velocity.magnitude}");

        // 车辆朝向运动方向；速度为零时保留当前朝向。
        if (m_velocity.sqrMagnitude > 0.00000001f)
            transform.rotation = Quaternion.LookRotation(m_velocity.normalized, Vector3.up);
    }

    // ==================== Arrive 行为 ====================

    /// <summary>
    /// 依据 C++ SteeringBehavior::Arrive 计算期望速度与转向力。
    /// </summary>
    /// <param name="targetPosition">鼠标点击放置的目标球世界坐标</param>
    /// <returns>未经过 MaxForce 截断的转向力</returns>
    private Vector3 CalculateArriveSteering(Vector3 targetPosition)
    {
        // 目标方向仅在 XZ 平面计算，避免高度差影响平面移动行为。
        Vector3 toTarget = targetPosition - transform.position;
        toTarget.y = 0f;
        float distance = toTarget.magnitude;

        // C++ 在 dist == 0 时直接返回 Vector2D(0, 0)，此处保持相同语义。
        if (distance <= 0f)
            // if (distance <= 2f)
            return Vector3.zero;

        // 原实现的微调常数：配合减速档位控制减速强弱。
        // 慢档值为 3，要求速度较低、较早减速；快档值为 1，减速较晚。
        const float decelerationTweaker = 0.3f;
        float deceleration = (float) m_deceleration;

        // 期望速度大小 = 距离 / (减速档位 × 微调常数)，再限制到最大速度。
        float desiredSpeed = distance / (deceleration * decelerationTweaker);
        desiredSpeed = Mathf.Min(desiredSpeed, m_maxSpeed);

        // C++ 用 ToTarget * speed / dist 构造期望速度，再减去当前速度得到转向力。
        Vector3 desiredVelocity = toTarget * desiredSpeed / distance;
        Vector3 steeringForce = desiredVelocity - m_velocity;
        steeringForce.y = 0f;
        return steeringForce;
    }

    // ==================== Debug 绘制 ====================

    private void OnDrawGizmos()
    {
        // 运行时速度和转向力只在 Play Mode 中有效。
        if (!m_debugDrawGizmos || !Application.isPlaying)
            return;

        if (m_target != null)
        {
            Gizmos.color = m_targetLineColor;
            Gizmos.DrawLine(transform.position, m_target.position);
        }

        Gizmos.color = m_velocityColor;
        Gizmos.DrawRay(transform.position, m_velocity);

        Gizmos.color = m_forceColor;
        Gizmos.DrawRay(transform.position, m_lastSteeringForce);
    }

    // ==================== 公开接口 ====================

    /// <summary>获取当前速度（仅 XZ 分量有效）。</summary>
    public Vector3 GetVelocity() => m_velocity;

    /// <summary>获取最大速度。</summary>
    public float GetMaxSpeed() => m_maxSpeed;

    /// <summary>设置最大速度。</summary>
    public void SetMaxSpeed(float speed) => m_maxSpeed = speed;

    /// <summary>获取最大转向力。</summary>
    public float GetMaxForce() => m_maxForce;

    /// <summary>设置最大转向力。</summary>
    public void SetMaxForce(float force) => m_maxForce = force;

    /// <summary>获取质量。</summary>
    public float GetMass() => m_mass;

    /// <summary>设置质量。</summary>
    public void SetMass(float mass) => m_mass = mass;

    /// <summary>获取 Arrive 减速档位。</summary>
    public Deceleration GetDeceleration() => m_deceleration;

    /// <summary>设置 Arrive 减速档位。</summary>
    public void SetDeceleration(Deceleration deceleration) => m_deceleration = deceleration;
}
/* 数学注释 *
 
using UnityEngine;

/// <summary>
/// Arrive 到达行为。
///
/// 核心目标：
/// 1. 远离目标时，以最大速度移动。
/// 2. 接近目标时，降低期望速度。
/// 3. 通过转向力逐渐改变当前速度。
/// 4. 最终以接近零的速度停在目标附近。
///
/// 数学基础：
/// 期望速度、速度差、牛顿第二定律、速度积分、位置积分。
/// </summary>
public class Arrive : MonoBehaviour
{
    // ==================== 私有字段 ====================

    [Header("目标设置")]

    [SerializeField]
    private string m_targetName = "PlacedSphere";


    [Header("车辆参数")]

    [SerializeField]
    private float m_maxSpeed = 8f;

    [SerializeField]
    private float m_maxForce = 24f;

    [SerializeField]
    private float m_mass = 1f;


    [Header("Arrive 减速档位")]

    [SerializeField]
    private Deceleration m_deceleration = Deceleration.Normal;


    [Header("Debug 设置")]

    [SerializeField]
    private bool m_debugDrawGizmos = true;

    [SerializeField]
    private Color m_velocityColor = Color.green;

    [SerializeField]
    private Color m_forceColor = Color.yellow;

    [SerializeField]
    private Color m_targetLineColor = Color.red;


    /// <summary>
    /// 减速档位。
    ///
    /// Slow   = 3
    /// Normal = 2
    /// Fast   = 1
    ///
    /// 数值越大，期望速度下降得越快，
    /// 因此物体会更早减速。
    /// </summary>
    public enum Deceleration
    {
        Slow = 3,
        Normal = 2,
        Fast = 1
    }


    // 缓存目标，避免每帧重复查找。
    private Transform m_target;

    // 当前速度向量，单位：m/s。
    // 只使用 XZ 平面分量。
    private Vector3 m_velocity;

    // 最近一帧计算得到的转向力。
    private Vector3 m_lastSteeringForce;


    // ==================== 生命周期 ====================

    private void Update()
    {
        // ------------------------------------------
        // 1. 查找目标
        // ------------------------------------------

        if (m_target == null)
        {
            GameObject targetObject = GameObject.Find(m_targetName);

            if (targetObject == null)
                return;

            m_target = targetObject.transform;
        }


        float deltaTime = Time.deltaTime;


        // ------------------------------------------
        // 2. 计算 Arrive 转向力
        // ------------------------------------------

        // CalculateArriveSteering 返回：
        //
        // F = V_desired - V_current
        //
        // 注意：这里的 F 是速度差形式的转向量，
        // 在此示例中将它作为力来使用。

        Vector3 steeringForce =
            CalculateArriveSteering(m_target.position);


        // 数学作用：
        //
        // |F| > MaxForce 时，将 F 缩放到 MaxForce。
        //
        // F_limited = F / |F| * MaxForce
        //
        // 防止单帧产生过大的转向力，
        // 使速度变化保持在合理范围。

        steeringForce =
            Vector3.ClampMagnitude(steeringForce, m_maxForce);

        m_lastSteeringForce = steeringForce;


        // ------------------------------------------
        // 3. 牛顿第二定律：力转换成加速度
        // ------------------------------------------

        // 公式：
        //
        // F = m * a
        //
        // 两边同时除以质量 m：
        //
        // a = F / m
        //
        // 例如：
        // F = 24 N
        // m = 2 kg
        //
        // a = 24 / 2 = 12 m/s²
        //
        // 质量越大，同样的力产生的加速度越小。

        Vector3 acceleration = steeringForce / m_mass;


        // ------------------------------------------
        // 4. 速度积分：加速度转换成速度
        // ------------------------------------------

        // 加速度定义：
        //
        // a = Δv / Δt
        //
        // 两边乘以 Δt：
        //
        // Δv = a * Δt
        //
        // 因此：
        //
        // V_new = V_old + a * Δt
        //
        // 例如：
        // 当前速度 = 2 m/s
        // 加速度 = 4 m/s²
        // 时间 = 0.5 s
        //
        // 新速度 = 2 + 4 * 0.5
        //        = 4 m/s
        //
        // 这里使用的是显式欧拉积分。

        m_velocity += acceleration * deltaTime;


        // ------------------------------------------
        // 5. 限制最大速度
        // ------------------------------------------

        // 公式：
        //
        // |V| <= MaxSpeed
        //
        // 如果速度超过最大速度，
        // 就沿原方向缩放到 MaxSpeed。
        //
        // 例如：
        // 当前速度大小 = 10 m/s
        // 最大速度 = 8 m/s
        //
        // 最终速度大小 = 8 m/s
        //
        // 不改变速度方向，只限制速度大小。

        m_velocity =
            Vector3.ClampMagnitude(m_velocity, m_maxSpeed);


        // ------------------------------------------
        // 6. 位置积分：速度转换成位置
        // ------------------------------------------

        // 速度定义：
        //
        // v = Δx / Δt
        //
        // 两边乘以 Δt：
        //
        // Δx = v * Δt
        //
        // 因此：
        //
        // P_new = P_old + V * Δt
        //
        // 例如：
        // 当前速度 = 4 m/s
        // 时间 = 0.5 s
        //
        // 位移 = 4 * 0.5
        //      = 2 m
        //
        // 速度越大，同样时间内移动距离越远。

        transform.position += m_velocity * deltaTime;


        // ------------------------------------------
        // 7. 根据速度更新物体朝向
        // ------------------------------------------

        // 速度向量的方向就是物体的运动方向。
        //
        // Normalize 将速度转换为单位方向向量：
        //
        // Direction = V / |V|
        //
        // LookRotation 根据方向生成旋转。
        //
        // 速度为零时不改变物体当前朝向。

        if (m_velocity.sqrMagnitude > 0.00000001f)
        {
            transform.rotation =
                Quaternion.LookRotation(
                    m_velocity.normalized,
                    Vector3.up
                );
        }
    }


    // ==================== Arrive 行为 ====================

    /// <summary>
    /// 计算 Arrive 转向力。
    ///
    /// 计算过程：
    ///
    /// 1. 计算目标方向。
    /// 2. 计算目标距离。
    /// 3. 根据距离计算期望速度。
    /// 4. 根据目标方向构造期望速度向量。
    /// 5. 期望速度减去当前速度，得到转向量。
    ///
    /// 返回值：
    /// 未经过 MaxForce 限制的转向量。
    /// </summary>
    private Vector3 CalculateArriveSteering(Vector3 targetPosition)
    {
        // ------------------------------------------
        // 1. 计算目标方向向量
        // ------------------------------------------

        // 公式：
        //
        // D = P_target - P_current
        //
        // 例如：
        // 当前坐标 = (2, 0, 3)
        // 目标坐标 = (8, 0, 9)
        //
        // D = (8, 0, 9) - (2, 0, 3)
        //   = (6, 0, 6)
        //
        // 结果表示从当前位置指向目标位置的向量。

        Vector3 toTarget = targetPosition - transform.position;


        // 只保留 XZ 平面运动。
        //
        // 将 Y 设置为零：
        //
        // D = (Dx, 0, Dz)
        //
        // 这样高度差不会影响移动方向。

        toTarget.y = 0f;


        // ------------------------------------------
        // 2. 计算目标距离
        // ------------------------------------------

        // 向量长度公式：
        //
        // d = |D|
        //
        // d = √(Dx² + Dy² + Dz²)
        //
        // 因为 Dy = 0：
        //
        // d = √(Dx² + Dz²)
        //
        // 例如：
        // D = (6, 0, 6)
        //
        // d = √(6² + 6²)
        //   = √72
        //   ≈ 8.485
        //
        // magnitude 用于获取向量的实际长度。

        float distance = toTarget.magnitude;


        // ------------------------------------------
        // 3. 判断是否已经到达目标
        // ------------------------------------------

        // 当 distance = 0 时：
        //
        // 当前坐标与目标坐标相同。
        //
        // 此时无法使用 D / distance 计算方向，
        // 因为分母不能为零。
        //
        // 因此直接返回零转向量。

        if (distance <= 0f)
            return Vector3.zero;


        // ------------------------------------------
        // 4. 计算期望速度大小
        // ------------------------------------------

        // Buckland 原始算法使用：
        //
        // DesiredSpeed = Distance / (Deceleration * Tweaker)
        //
        // 其中：
        //
        // Distance：
        // 当前物体到目标的距离。
        //
        // Deceleration：
        // 减速档位。
        //
        // Tweaker：
        // 减速调整系数，原始算法为 0.3。
        //
        // 公式：
        //
        // V_desired = d / (T * 0.3)
        //
        // 例如：
        // distance = 6
        // Deceleration = Normal = 2
        //
        // V_desired = 6 / (2 * 0.3)
        //           = 10 m/s
        //
        // 但最大速度只有 8 m/s，
        // 因此还需要进行最大速度限制。

        const float decelerationTweaker = 0.3f;

        float deceleration = (float)m_deceleration;

        float desiredSpeed =
            distance / (deceleration * decelerationTweaker);


        // ------------------------------------------
        // 5. 限制期望速度
        // ------------------------------------------

        // 公式：
        //
        // V_desired = Min(V_desired, MaxSpeed)
        //
        // 例如：
        // 计算得到期望速度 = 10 m/s
        // 最大速度 = 8 m/s
        //
        // 最终期望速度 = 8 m/s
        //
        // 作用：
        // 远距离移动时保持最大速度，
        // 接近目标时逐渐降低速度。

        desiredSpeed = Mathf.Min(desiredSpeed, m_maxSpeed);


        // ------------------------------------------
        // 6. 计算期望速度向量
        // ------------------------------------------

        // 首先计算目标方向的单位向量：
        //
        // Direction = D / |D|
        //
        // 例如：
        // D = (6, 0, 6)
        // distance = 8.485
        //
        // Direction ≈ (0.707, 0, 0.707)
        //
        // 然后乘以期望速度：
        //
        // V_desired = Direction * desiredSpeed
        //
        // 等价于：
        //
        // V_desired = D * desiredSpeed / distance
        //
        // 作用：
        // 让期望速度同时具备：
        // 1. 正确的运动方向。
        // 2. 根据目标距离计算出的速度大小。

        Vector3 desiredVelocity =
            toTarget * desiredSpeed / distance;


        // ------------------------------------------
        // 7. 计算转向量
        // ------------------------------------------

        // 公式：
        //
        // Steering = V_desired - V_current
        //
        // 例如：
        // 期望速度 = (4, 0, 0)
        // 当前速度 = (2, 0, 0)
        //
        // Steering = (4, 0, 0) - (2, 0, 0)
        //          = (2, 0, 0)
        //
        // 说明需要增加 X 方向的速度。
        //
        // 如果：
        // 期望速度 = (0, 0, 0)
        // 当前速度 = (2, 0, 0)
        //
        // Steering = (-2, 0, 0)
        //
        // 说明需要产生反方向的转向量，
        // 让物体逐渐减速。

        Vector3 steeringForce =
            desiredVelocity - m_velocity;


        // 保证转向量只作用于 XZ 平面。

        steeringForce.y = 0f;


        // 返回转向量。
        // 外部 Update 会限制最大转向力。

        return steeringForce;
    }


    // ==================== Debug 绘制 ====================

    private void OnDrawGizmos()
    {
        if (!m_debugDrawGizmos || !Application.isPlaying)
            return;


        // 红色：自身到目标的连线。
        if (m_target != null)
        {
            Gizmos.color = m_targetLineColor;

            Gizmos.DrawLine(
                transform.position,
                m_target.position
            );
        }


        // 绿色：当前速度向量。
        //
        // 方向代表运动方向。
        // 长度代表当前速度大小。

        Gizmos.color = m_velocityColor;

        Gizmos.DrawRay(
            transform.position,
            m_velocity
        );


        // 黄色：当前转向量。
        //
        // 方向代表速度需要改变的方向。
        // 长度代表速度差的大小。

        Gizmos.color = m_forceColor;

        Gizmos.DrawRay(
            transform.position,
            m_lastSteeringForce
        );
    }


    // ==================== 公开接口 ====================

    public Vector3 GetVelocity() => m_velocity;

    public float GetMaxSpeed() => m_maxSpeed;

    public void SetMaxSpeed(float speed) =>
        m_maxSpeed = speed;

    public float GetMaxForce() => m_maxForce;

    public void SetMaxForce(float force) =>
        m_maxForce = force;

    public float GetMass() => m_mass;

    public void SetMass(float mass) =>
        m_mass = mass;

    public Deceleration GetDeceleration() =>
        m_deceleration;

    public void SetDeceleration(Deceleration deceleration) =>
        m_deceleration = deceleration;
}

 */