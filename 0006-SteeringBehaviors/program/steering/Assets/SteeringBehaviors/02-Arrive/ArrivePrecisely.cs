using UnityEngine;

/// <summary>
/// Arrive 到达行为。
/// 参考 Buckland《Programming Game AI by Example》中的 Arrive 算法。
///
/// 功能：
/// 1. 自动查找 PlacedSphere 目标。
/// 2. 根据距离计算期望速度，并提前减速。
/// 3. 使用转向力、质量和时间积分计算运动。
/// 4. 进入到达半径后精确对齐目标的 XZ 坐标。
/// 5. 到达后清零速度，防止残余移动。
/// 6. 仅在 XZ 平面运动，保留物体原有高度。
/// </summary>
public class ArrivePrecisely : MonoBehaviour
{
    // ==================== 目标设置 ====================

    [Header("目标设置")] [SerializeField] private string m_targetName = "PlacedSphere";

    private Transform m_target;

    // ==================== 运动参数 ====================

    [Header("车辆参数")] [SerializeField, Min(0f)]
    private float m_maxSpeed = 8f;

    [SerializeField, Min(0f)] private float m_maxForce = 24f;

    [SerializeField, Min(0.001f)] private float m_mass = 1f;

    // ==================== Arrive 参数 ====================
    
    public enum Deceleration
    {
        Slow = 3,
        Normal = 2,
        Fast = 1
    }

    [Header("Arrive 减速设置")] [SerializeField]
    private Deceleration m_deceleration = Deceleration.Normal;

    [SerializeField, Min(0.001f)] private float m_decelerationTweaker = 0.3f;

    [Header("精准到达设置")] [Tooltip("进入该距离后，将位置校准到目标的 XZ 坐标")] [SerializeField, Min(0.001f)]
    private float m_arriveRadius = 0.05f;

    // ==================== 调试设置 ====================

    [Header("Debug 设置")] [SerializeField] private bool m_debugDrawGizmos = true;

    [SerializeField] private Color m_velocityColor = Color.green;

    [SerializeField] private Color m_forceColor = Color.yellow;

    [SerializeField] private Color m_targetLineColor = Color.red;

    // ==================== 运动状态 ====================

    private Vector3 m_velocity;
    private Vector3 m_lastSteeringForce;

    // ==================== Unity 生命周期 ====================

    private void Update()
    {
        // 目标尚未生成或已被销毁时，重新查找。
        if (m_target == null)
        {
            GameObject targetObject = GameObject.Find(m_targetName);

            if (targetObject == null)
            {
                return;
            }

            m_target = targetObject.transform;
        }

        float deltaTime = Time.deltaTime;

        if (deltaTime <= 0f)
        {
            return;
        }

        // 只考虑 XZ 平面的目标距离。
        Vector3 toTarget = m_target.position - transform.position;
        toTarget.y = 0f;

        float distance = toTarget.magnitude;

        // 到达最终判定范围，精确校准位置并停止。
        if (distance <= m_arriveRadius)
        {
            StopAtTarget();
            return;
        }

        // 计算 Arrive 转向力。
        Vector3 steeringForce =
            CalculateArriveSteering(toTarget, distance);

        // 限制最大转向力。
        steeringForce =
            Vector3.ClampMagnitude(steeringForce, m_maxForce);

        m_lastSteeringForce = steeringForce;

        // F = ma，计算加速度。
        Vector3 acceleration = steeringForce / m_mass;

        // 积分速度。
        m_velocity += acceleration * deltaTime;

        // 限制最大速度。
        m_velocity = Vector3.ClampMagnitude(
            m_velocity,
            m_maxSpeed
        );

        // 只允许在 XZ 平面移动。
        m_velocity.y = 0f;

        // 积分位置。
        transform.position += m_velocity * deltaTime;

        // 朝向当前运动方向。
        if (m_velocity.sqrMagnitude > 0.00000001f)
        {
            transform.rotation = Quaternion.LookRotation(
                m_velocity.normalized,
                Vector3.up
            );
        }
    }

    // ==================== Arrive 核心算法 ====================

    /// <summary>
    /// 计算 Arrive 转向力。
    /// 增加基于最大减速度的刹车速度限制，
    /// 使物体能够根据剩余距离提前减速。
    /// </summary>
    private Vector3 CalculateArriveSteering(
        Vector3 toTarget,
        float distance)
    {
        if (distance <= 0f)
        {
            return Vector3.zero;
        }

        // Buckland 原始 Arrive 的减速计算。
        float deceleration = Mathf.Max(
            1f,
            (float) m_deceleration
        );

        float desiredSpeed = distance /
                             (deceleration * m_decelerationTweaker);

        desiredSpeed = Mathf.Min(
            desiredSpeed,
            m_maxSpeed
        );

        // 最大理论减速度 a = F / m。
        float maxDeceleration = m_maxForce / m_mass;

        // 根据 v² = 2ad，计算当前距离允许的刹车速度。
        float brakingSpeed = Mathf.Sqrt(
            2f * maxDeceleration * distance
        );

        // 采用更保守的速度，避免高速冲过目标。
        desiredSpeed = Mathf.Min(
            desiredSpeed,
            brakingSpeed
        );

        // 构造期望速度。
        Vector3 desiredVelocity =
            toTarget.normalized * desiredSpeed;

        // 转向力 = 期望速度 - 当前速度。
        Vector3 steeringForce = desiredVelocity - m_velocity;

        steeringForce.y = 0f;

        return steeringForce;
    }

    // ==================== 精准停止 ====================

    /// <summary>
    /// 将物体精确对齐目标的 XZ 坐标，并清零速度。
    /// 保留物体原有高度。
    /// </summary>
    private void StopAtTarget()
    {
        Vector3 position = transform.position;

        position.x = m_target.position.x;
        position.z = m_target.position.z;

        transform.position = position;

        m_velocity = Vector3.zero;
        m_lastSteeringForce = Vector3.zero;
    }

    // ==================== Debug 绘制 ====================

    private void OnDrawGizmos()
    {
        if (!m_debugDrawGizmos || !Application.isPlaying)
        {
            return;
        }

        if (m_target != null)
        {
            Gizmos.color = m_targetLineColor;
            Gizmos.DrawLine(
                transform.position,
                m_target.position
            );

            // 绘制到达半径。
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(
                new Vector3(
                    m_target.position.x,
                    transform.position.y,
                    m_target.position.z
                ),
                m_arriveRadius
            );
        }

        Gizmos.color = m_velocityColor;
        Gizmos.DrawRay(transform.position, m_velocity);

        Gizmos.color = m_forceColor;
        Gizmos.DrawRay(
            transform.position,
            m_lastSteeringForce
        );
    }

    // ==================== 公开接口 ====================

    public Vector3 GetVelocity() => m_velocity;

    public float GetMaxSpeed() => m_maxSpeed;

    public void SetMaxSpeed(float speed)
    {
        m_maxSpeed = Mathf.Max(0f, speed);
    }

    public float GetMaxForce() => m_maxForce;

    public void SetMaxForce(float force)
    {
        m_maxForce = Mathf.Max(0f, force);
    }

    public float GetMass() => m_mass;

    public void SetMass(float mass)
    {
        m_mass = Mathf.Max(0.001f, mass);
    }

    public Deceleration GetDeceleration() => m_deceleration;

    public void SetDeceleration(Deceleration deceleration)
    {
        m_deceleration = deceleration;
    }

    public bool HasArrived()
    {
        if (m_target == null)
        {
            return false;
        }

        Vector3 offset = m_target.position - transform.position;
        offset.y = 0f;

        return offset.sqrMagnitude <=
               m_arriveRadius * m_arriveRadius;
    }

    public void SetTarget(Transform target)
    {
        m_target = target;
    }
}