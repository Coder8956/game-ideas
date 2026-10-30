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

    [Header("目标设置")]
    [SerializeField] private string m_targetName = "PlacedSphere"; // 相机点击放置器创建的目标球名称

    [Header("车辆参数（对应 Buckland 的 MaxSpeed / MaxForce / Mass）")]
    [SerializeField] private float m_maxSpeed = 8f;  // 最大速度：Arrive 的期望速度上限
    [SerializeField] private float m_maxForce = 24f; // 最大转向力：截断单帧可施加的力
    [SerializeField] private float m_mass = 1f;     // 质量：决定转向力产生加速度的大小

    [Header("Arrive 减速档位（对应 C++ Deceleration 枚举）")]
    [SerializeField] private Deceleration m_deceleration = Deceleration.Normal; // Slow 更早减速，Fast 更晚减速

    [Header("Debug 设置")]
    [SerializeField] private bool m_debugDrawGizmos = true;  // 是否绘制运行时调试信息
    [SerializeField] private Color m_velocityColor = Color.green; // 当前速度向量颜色
    [SerializeField] private Color m_forceColor = Color.yellow;   // 当前转向力向量颜色
    [SerializeField] private Color m_targetLineColor = Color.red; // 自身到目标的连线颜色

    /// <summary>与 Buckland C++ Deceleration 枚举一致：slow=3、normal=2、fast=1。</summary>
    public enum Deceleration
    {
        Slow = 3,
        Normal = 2,
        Fast = 1
    }

    private Transform m_target;           // 缓存目标球，避免每帧按名称查找
    private Vector3 m_velocity;            // 当前速度（仅 XZ 分量有效）
    private Vector3 m_lastSteeringForce;   // 最近一帧转向力，仅用于 Gizmos 绘制

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
        float deceleration = (float)m_deceleration;

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
