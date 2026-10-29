using UnityEngine;

/// <summary>
/// Flee 逃离行为：持续远离鼠标点击放置的目标球（PlacedSphere）。
///
/// 转向计算对应 Buckland《Programming Game AI by Example》第 3 章
/// SteeringBehavior::Flee() 的核心逻辑：期望速度指向“目标到自身”的方向，
/// 转向力为期望速度减去当前速度。车辆运动采用 Seek 示例相同的力积分方式。
/// 本脚本只实现 Flee，不混合其他转向行为；运动限制在 XZ 平面。
/// </summary>
public class Flee : MonoBehaviour
{
    [Header("目标设置")]
    [SerializeField] private string m_targetName = "PlacedSphere"; // 点击放置器创建的唯一目标名称

    [Header("车辆参数（对应 Buckland 的 MaxSpeed / MaxForce / Mass）")]
    [SerializeField] private float m_maxSpeed = 8f;  // 期望速度以及实际速度的最大长度
    [SerializeField] private float m_maxForce = 24f; // 转向力上限，限制每帧可产生的加速度
    [SerializeField] private float m_mass = 1f;      // 质量越大，相同转向力产生的加速度越小

    [Header("恐慌距离")]
    [SerializeField] private bool m_usePanicDistance = true; // 启用后仅在目标进入恐慌距离时逃离
    [SerializeField] private float m_panicDistance = 100f;   // 超出此距离时不产生 Flee 转向力

    [Header("Debug 设置")]
    [SerializeField] private bool m_debugDrawGizmos = true; // 是否显示运行时调试向量
    [SerializeField] private Color m_velocityColor = Color.green; // 当前速度
    [SerializeField] private Color m_forceColor = Color.yellow;   // 最近一帧的转向力
    [SerializeField] private Color m_targetLineColor = Color.red; // 与逃离目标的连线

    private Transform m_target;          // 缓存目标，避免每帧按名称查找
    private Vector3 m_velocity;          // 当前速度，仅 XZ 分量参与运动
    private Vector3 m_lastSteeringForce; // 最近一帧转向力，仅供 Gizmos 绘制

    private void Update()
    {
        // 目标尚未放置或刚被销毁时保持当前位置，并尝试重新查找。
        if (m_target == null)
        {
            GameObject targetObject = GameObject.Find(m_targetName);
            if (targetObject == null)
                return;

            m_target = targetObject.transform;
        }

        float deltaTime = Time.deltaTime;

        // 期望速度朝远离目标的方向；将转向力限制在最大推力范围内。
        Vector3 steeringForce = CalculateFleeSteering(m_target.position);
        steeringForce = Vector3.ClampMagnitude(steeringForce, m_maxForce);
        m_lastSteeringForce = steeringForce;

        // 牛顿第二定律将转向力转换为加速度，再逐帧积分速度。
        Vector3 acceleration = steeringForce / m_mass;
        m_velocity += acceleration * deltaTime;

        // 限制最高速度并推进位置。速度不含 y 分量，因此物体保持原高度。
        m_velocity = Vector3.ClampMagnitude(m_velocity, m_maxSpeed);
        transform.position += m_velocity * deltaTime;

        // 使物体正面朝向当前运动方向，速度为零时保留原朝向。
        if (m_velocity.sqrMagnitude > 0.00000001f)
            transform.rotation = Quaternion.LookRotation(m_velocity.normalized, Vector3.up);
    }

    /// <summary>
    /// 计算逃离目标的转向力：远离目标的最大期望速度减去当前速度。
    /// </summary>
    /// <param name="targetPosition">目标球的世界坐标</param>
    /// <returns>尚未截断到最大力的转向力</returns>
    private Vector3 CalculateFleeSteering(Vector3 targetPosition)
    {
        // 对应参考代码中的 PanicDistanceSq：仅比较平面距离的平方，避免开平方运算。
        // 超出恐慌距离时返回零转向力，车辆保持当前速度，不再主动逃离。
        if (m_usePanicDistance)
        {
            Vector3 toTarget = targetPosition - transform.position;
            toTarget.y = 0f;
            float panicDistanceSq = m_panicDistance * m_panicDistance;
            if (toTarget.sqrMagnitude > panicDistanceSq)
                return Vector3.zero;
        }

        // 从目标指向自身，作为逃离方向；忽略高度差以保持地面运动。
        Vector3 awayFromTarget = transform.position - targetPosition;
        awayFromTarget.y = 0f;

        // 目标与自身重合时方向为零，normalized 返回零向量，车辆不会凭空选方向。
        Vector3 desiredVelocity = awayFromTarget.normalized * m_maxSpeed;

        // 用速度差作为转向力，使车辆逐渐转向逃离方向，而非瞬间改变速度。
        Vector3 steeringForce = desiredVelocity - m_velocity;
        steeringForce.y = 0f;
        return steeringForce;
    }

    private void OnDrawGizmos()
    {
        // 运行时向量数据仅在 Play Mode 有效。
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
}
