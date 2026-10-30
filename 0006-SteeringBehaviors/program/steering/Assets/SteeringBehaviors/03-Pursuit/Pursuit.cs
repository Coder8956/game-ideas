using UnityEngine;

/// <summary>
/// Pursuit（预测追击）行为：根据目标的当前位置、朝向和速度计算追击转向力。
/// 算法对应 Buckland SteeringBehaviors.cpp 中 SteeringBehavior::Pursuit。
/// </summary>
public class Pursuit : MonoBehaviour
{
    [Header("目标设置")]
    [SerializeField] private string m_targetName = "Tank-Wander"; // 被追击目标的 GameObject 名称

    [Header("车辆参数（对应 Buckland 的 MaxSpeed / MaxForce / Mass）")]
    [SerializeField] private float m_maxSpeed = 8f;  // 自身最大速度
    [SerializeField] private float m_maxForce = 24f; // 自身最大转向力
    [SerializeField] private float m_mass = 1f;      // 自身质量

    [Header("Debug 设置")]
    [SerializeField] private bool m_debugDrawGizmos = true;       // 是否绘制运行时调试向量
    [SerializeField] private Color m_velocityColor = Color.green; // 当前速度颜色
    [SerializeField] private Color m_forceColor = Color.yellow;   // 转向力颜色
    [SerializeField] private Color m_targetLineColor = Color.red; // 到目标的连线颜色

    private GameObject m_target;           // 被追击对象；目标丢失后会按名称重新查找
    private Vector3 m_velocity;             // 自身当前速度（仅 XZ 平面有效）
    private Vector3 m_lastSteeringForce;    // 最近一次转向力，仅供 Gizmos 使用

    private void Update()
    {
        // Unity 对已销毁对象的 null 判断也成立，因此目标销毁后会重新查找。
        if (m_target == null)
        {
            m_target = GameObject.Find(m_targetName);
            if (m_target == null)
                return;
        }

        float deltaTime = Time.deltaTime;

        // Pursuit 算法仅负责计算这一种行为的转向力；不叠加 Seek/Flee 等其它行为。
        Vector3 steeringForce = CalculatePursuitSteering(m_target);
        steeringForce = Vector3.ClampMagnitude(steeringForce, m_maxForce);
        m_lastSteeringForce = steeringForce;

        // 牛顿第二定律 F = ma，故 a = F / m。
        Vector3 acceleration = steeringForce / m_mass;
        // 欧拉积分：v(t+dt) = v(t) + a*dt，并将速度限制在自身最大速度内。
        m_velocity += acceleration * deltaTime;
        m_velocity = Vector3.ClampMagnitude(m_velocity, m_maxSpeed);
        // 位置积分：p(t+dt) = p(t) + v*dt。
        transform.position += m_velocity * deltaTime;

        // 速度非零时将车头旋转到运动方向，避免零向量 LookRotation。
        if (m_velocity.sqrMagnitude > 0.00000001f)
            transform.rotation = Quaternion.LookRotation(m_velocity.normalized, Vector3.up);
    }

    /// <summary>
    /// 按 Buckland 的 Pursuit 公式计算转向力。
    /// </summary>
    private Vector3 CalculatePursuitSteering(GameObject target)
    {
        // 原算法 ToEvader = 目标位置 - 自身位置；演示场景在 XZ 平面运行。
        Vector3 toTarget = target.transform.position - transform.position;
        toTarget.y = 0f;

        // 用目标物体朝向作为其 Heading，与自身朝向做点积判断是否迎面相遇。
        Vector3 targetHeading = target.transform.forward;
        targetHeading.y = 0f;
        targetHeading.Normalize();
        Vector3 ownHeading = transform.forward;
        ownHeading.y = 0f;
        ownHeading.Normalize();

        // 点积等于夹角余弦：目标在前方且双方朝向近乎相反（< -0.95）时，
        // 原算法直接 Seek 目标当前位置，不做未来位置预测。
        float relativeHeading = Vector3.Dot(ownHeading, targetHeading);
        if (Vector3.Dot(toTarget, ownHeading) > 0f && relativeHeading < -0.95f)
            return CalculateSeekSteering(target.transform.position);

        // 目标速度取自其 Pursuit/Wander 组件提供的运动状态；静止或无该组件时为零。
        Vector3 targetVelocity = GetTargetVelocity(target);
        targetVelocity.y = 0f;

        // 前瞻时间 = 双方距离 / (自身最大速度 + 目标当前速度大小)。
        // 距离越远前瞻越久；双方越快则预计更快相遇，前瞻越短。
        float denominator = m_maxSpeed + targetVelocity.magnitude;
        float lookAheadTime = denominator > 0.000001f ? toTarget.magnitude / denominator : 0f;

        // 预测位置 = 目标当前位置 + 目标速度 × 前瞻时间，再按 Seek 力公式追向该点。
        Vector3 futurePosition = target.transform.position + targetVelocity * lookAheadTime;
        return CalculateSeekSteering(futurePosition);
    }

    /// <summary>对应 Pursuit 内部调用的 Seek：期望速度减去当前速度。</summary>
    private Vector3 CalculateSeekSteering(Vector3 targetPosition)
    {
        Vector3 toTarget = targetPosition - transform.position;
        toTarget.y = 0f;
        Vector3 desiredVelocity = toTarget.normalized * m_maxSpeed;
        Vector3 steeringForce = desiredVelocity - m_velocity;
        steeringForce.y = 0f;
        return steeringForce;
    }

    /// <summary>
    /// 获取目标当前速度。优先读取本项目的 Wander 或 Pursuit 行为；
    /// 普通 GameObject 没有速度组件时视为静止目标。
    /// </summary>
    private Vector3 GetTargetVelocity(GameObject target)
    {
        Wander wander = target.GetComponent<Wander>();
        if (wander != null)
            return wander.GetVelocity();

        Pursuit pursuit = target.GetComponent<Pursuit>();
        if (pursuit != null)
            return pursuit.GetVelocity();

        return Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        if (!m_debugDrawGizmos || !Application.isPlaying)
            return;

        if (m_target != null)
        {
            Gizmos.color = m_targetLineColor;
            Gizmos.DrawLine(transform.position, m_target.transform.position);
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
