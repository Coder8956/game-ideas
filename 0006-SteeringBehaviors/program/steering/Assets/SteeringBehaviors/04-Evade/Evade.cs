using UnityEngine;

/// <summary>
/// Evade 逃避行为：预测追兵的短期位置，并向预测位置的反方向逃离。
/// 算法对应 Buckland《Programming Game AI by Example》第 3 章
/// SteeringBehaviors.cpp 中的 SteeringBehavior::Evade。
/// </summary>
public class Evade : MonoBehaviour
{
    [Header("逃避目标设置")]
    [SerializeField] private string m_targetName = "Tank-Wander"; // 追兵 GameObject 名称，可在 Inspector 配置

    [Header("车辆参数（对应 Buckland 的 MaxSpeed / MaxForce / Mass）")]
    [SerializeField] private float m_maxSpeed = 8f;  // 自身最大速度
    [SerializeField] private float m_maxForce = 24f; // 自身最大转向力
    [SerializeField] private float m_mass = 1f;      // 自身质量

    [Header("Evade 参数")]
    [SerializeField] private float m_threatRange = 100f; // 仅在该范围内响应追兵，对应 C++ ThreatRange

    [Header("Debug 设置")]
    [SerializeField] private bool m_debugDrawGizmos = true;
    [SerializeField] private Color m_velocityColor = Color.green;
    [SerializeField] private Color m_forceColor = Color.yellow;
    [SerializeField] private Color m_targetLineColor = Color.red;
    [SerializeField] private Color m_predictedPositionColor = Color.magenta;

    private Transform m_target;                 // 缓存追兵 Transform，避免每帧全场景查找
    private Vector3 m_targetVelocity;           // 追兵当前速度（XZ 平面）
    private Vector3 m_velocity;                 // 自身当前速度（XZ 平面）
    private Vector3 m_lastSteeringForce;         // 最近一帧转向力，供 Gizmos 使用
    private Vector3 m_predictedTargetPosition;    // 按前瞻时间预测的追兵位置
    private bool m_isThreatInRange;

    private void Update()
    {
        // 目标还未出现时保持原地；目标被销毁后 Unity 的假 null 也会触发重新查找。
        if (m_target == null)
        {
            GameObject targetGo = GameObject.Find(m_targetName);
            if (targetGo == null)
                return;

            m_target = targetGo.transform;
        }

        float deltaTime = Time.deltaTime;

        // 追兵速度通过相邻帧位置差估算：速度 = 位移 / 时间。
        // 首次捕获目标时速度设为零，避免用未知历史位置产生虚假的速度。
        Vector3 targetPosition = m_target.position;
        if (deltaTime > 0f && m_hasPreviousTargetPosition)
        {
            m_targetVelocity = (targetPosition - m_previousTargetPosition) / deltaTime;
            m_targetVelocity.y = 0f;
        }
        else
        {
            m_targetVelocity = Vector3.zero;
        }
        m_previousTargetPosition = targetPosition;
        m_hasPreviousTargetPosition = true;

        // ================== 第 1 步：计算 Evade 转向力 ==================
        Vector3 steeringForce = CalculateEvadeSteering(targetPosition);

        // 对应原工程的力截断：单一行为权重为 1，转向力不超过 MaxForce。
        steeringForce = Vector3.ClampMagnitude(steeringForce, m_maxForce);
        m_lastSteeringForce = steeringForce;

        // ================== 第 2 步：力 -> 加速度 -> 速度 -> 位置 ==================
        // 牛顿第二定律：a = F / m；速度积分：v = v + a * dt。
        Vector3 acceleration = steeringForce / m_mass;
        m_velocity += acceleration * deltaTime;

        // 速度长度限幅到 MaxSpeed，对应 Vehicle 的速度截断。
        m_velocity = Vector3.ClampMagnitude(m_velocity, m_maxSpeed);

        // 位置积分：位置 = 位置 + 速度 * dt。速度仅有 XZ 分量，因此 y 保持不变。
        transform.position += m_velocity * deltaTime;

        // 车辆朝向与行进方向一致；零速度时不调用 LookRotation。
        if (m_velocity.sqrMagnitude > 0.00000001f)
            transform.rotation = Quaternion.LookRotation(m_velocity.normalized, Vector3.up);
    }

    private Vector3 m_previousTargetPosition;
    private bool m_hasPreviousTargetPosition;

    /// <summary>
    /// 计算追兵未来位置并从该处逃离。威胁范围和前瞻时间公式遵循 C++ Evade。
    /// </summary>
    /// <param name="targetPosition">追兵当前世界位置</param>
    /// <returns>逃离预测追兵位置所需的转向力</returns>
    private Vector3 CalculateEvadeSteering(Vector3 targetPosition)
    {
        // 从自身指向追兵的向量；忽略高度差，仅在 XZ 平面计算距离。
        Vector3 toPursuer = targetPosition - transform.position;
        toPursuer.y = 0f;
        float distanceSquared = toPursuer.sqrMagnitude;

        // C++ 参考实现：距离平方超过 ThreatRange² 时返回零力，避免远距离追兵触发逃避。
        float threatRangeSquared = m_threatRange * m_threatRange;
        m_isThreatInRange = distanceSquared <= threatRangeSquared;
        if (!m_isThreatInRange)
        {
            m_predictedTargetPosition = targetPosition;
            return Vector3.zero;
        }

        float distance = Mathf.Sqrt(distanceSquared);

        // LookAheadTime = 双方距离 / (自身最大速度 + 追兵速度)。
        // 量纲为“距离 / 速度 = 时间”，用于估计追兵短时间后的位移。
        float totalSpeed = m_maxSpeed + m_targetVelocity.magnitude;
        float lookAheadTime = totalSpeed > 0.000001f ? distance / totalSpeed : 0f;

        // 追兵预测位置 = 当前追兵位置 + 追兵速度 × 前瞻时间。
        m_predictedTargetPosition = targetPosition + m_targetVelocity * lookAheadTime;
        m_predictedTargetPosition.y = transform.position.y;

        // Flee 等价于 Seek(预测位置) 的反方向：
        // 期望速度 = Normalize(自身位置 - 预测位置) × MaxSpeed；转向力 = 期望速度 - 当前速度。
        Vector3 awayFromPredictedTarget = transform.position - m_predictedTargetPosition;
        awayFromPredictedTarget.y = 0f;
        Vector3 desiredVelocity = awayFromPredictedTarget.normalized * m_maxSpeed;
        Vector3 steeringForce = desiredVelocity - m_velocity;
        steeringForce.y = 0f;
        return steeringForce;
    }

    private void OnDrawGizmos()
    {
        if (!m_debugDrawGizmos || !Application.isPlaying)
            return;

        if (m_target != null)
        {
            Gizmos.color = m_targetLineColor;
            Gizmos.DrawLine(transform.position, m_target.position);

            Gizmos.color = m_predictedPositionColor;
            Gizmos.DrawSphere(m_predictedTargetPosition, 0.2f);
            Gizmos.DrawLine(m_target.position, m_predictedTargetPosition);
        }

        Gizmos.color = m_velocityColor;
        Gizmos.DrawRay(transform.position, m_velocity);

        Gizmos.color = m_forceColor;
        Gizmos.DrawRay(transform.position, m_lastSteeringForce);
    }

    /// <summary>获取当前速度（仅 XZ 分量有效）</summary>
    public Vector3 GetVelocity() => m_velocity;

    /// <summary>获取最大速度</summary>
    public float GetMaxSpeed() => m_maxSpeed;

    /// <summary>设置最大速度</summary>
    public void SetMaxSpeed(float speed) => m_maxSpeed = speed;

    /// <summary>获取最大转向力</summary>
    public float GetMaxForce() => m_maxForce;

    /// <summary>设置最大转向力</summary>
    public void SetMaxForce(float force) => m_maxForce = force;

    /// <summary>获取质量</summary>
    public float GetMass() => m_mass;

    /// <summary>设置质量</summary>
    public void SetMass(float mass) => m_mass = mass;
}
