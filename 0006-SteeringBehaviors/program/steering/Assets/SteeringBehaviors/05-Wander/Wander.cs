using UnityEngine;

/// <summary>
/// Wander 漫游行为：持续扰动车辆前方圆盘上的目标点，并产生朝向该点的转向力。
/// 算法对应 Buckland SteeringBehavior::Wander；车辆在 Unity 的 XZ 平面运动。
/// </summary>
public class Wander : MonoBehaviour
{
    // ==================== 私有字段 ====================

    // [Header("目标设置")]
    // [SerializeField] private string m_targetName = "PlacedSphere"; // 鼠标点击放置的目标球名称

    [Header("漫游参数（对应 Buckland 的 Wander 参数）")]
    [SerializeField] private float m_wanderRadius = 2f; // 前方漫游圆盘半径
    [SerializeField] private float m_wanderDistance = 3f; // 圆盘中心距车辆的前向距离
    [SerializeField] private float m_wanderJitter = 1f; // 每秒扰动强度

    [Header("车辆参数（对应 Buckland 的 MaxSpeed / MaxForce / Mass）")]
    [SerializeField] private float m_maxSpeed = 8f; // 最大速度
    [SerializeField] private float m_maxForce = 24f; // 最大转向力
    [SerializeField] private float m_mass = 1f; // 质量

    [Header("Debug 设置")]
    [SerializeField] private bool m_debugDrawGizmos = true; // 是否绘制调试信息
    [SerializeField] private Color m_circleColor = Color.cyan; // 漫游圆盘颜色
    [SerializeField] private Color m_targetColor = Color.yellow; // 目标点颜色
    [SerializeField] private Color m_velocityColor = Color.green; // 速度向量颜色
    [SerializeField] private Color m_forceColor = Color.red; // 转向力颜色

    private Transform m_target; // 缓存 PlacedSphere，目标未创建时保持空引用
    private Vector3 m_velocity; // 当前速度，仅 XZ 分量有效
    private Vector3 m_localWanderTarget; // 圆盘上的目标偏移，车辆局部坐标
    private Vector3 m_worldWanderTarget; // 漫游目标点，世界坐标，仅供调试
    private Vector3 m_lastSteeringForce; // 最近一帧转向力，仅供调试

    // ==================== 生命周期 ====================

    private void Start()
    {
        // Buckland 构造时以随机角度初始化圆上目标：(半径*cosθ, 半径*sinθ)。
        float theta = Random.Range(0f, Mathf.PI * 2f);
        m_localWanderTarget = new Vector3(Mathf.Cos(theta), 0f, Mathf.Sin(theta)) * m_wanderRadius;
    }

    private void Update()
    {
        // 按名称寻找鼠标点击产生的目标；尚未点击或目标被销毁时不移动。
        // if (m_target == null)
        // {
        //     GameObject targetObject = GameObject.Find(m_targetName);
        //     if (targetObject == null)
        //         return;
        //     m_target = targetObject.transform;
        // }

        float deltaTime = Time.deltaTime;

        // Wander 只计算漫游力；目标球是行为启用条件和演示目标，不替代随机圆盘目标。
        Vector3 steeringForce = CalculateWanderSteering(deltaTime);
        steeringForce = Vector3.ClampMagnitude(steeringForce, m_maxForce);
        m_lastSteeringForce = steeringForce;

        // 牛顿第二定律：a = F / m；质量越大，同样转向力产生的加速度越小。
        Vector3 acceleration = steeringForce / Mathf.Max(m_mass, 0.0001f);
        // 速度积分：v(t+dt) = v(t) + a*dt，再把速度限制在最大速度内。
        m_velocity += acceleration * deltaTime;
        m_velocity = Vector3.ClampMagnitude(m_velocity, m_maxSpeed);
        // 位置积分：x(t+dt) = x(t) + v*dt；只更新 XZ，保持车辆高度。
        m_velocity.y = 0f;
        transform.position += m_velocity * deltaTime;

        // 车辆前向与速度方向对齐；速度近零时保留现有朝向以避免零向量旋转。
        if (m_velocity.sqrMagnitude > 0.00000001f)
            transform.rotation = Quaternion.LookRotation(m_velocity.normalized, Vector3.up);
    }

    // ==================== Wander 行为 ====================

    /// <summary>按 Buckland Wander 计算漫游转向力。</summary>
    private Vector3 CalculateWanderSteering(float deltaTime)
    {
        // 本帧扰动 = 每秒扰动强度 × 帧间隔，避免行为强度随帧率变化。
        float jitterThisFrame = m_wanderJitter * deltaTime;
        m_localWanderTarget += new Vector3(
            Random.Range(-1f, 1f) * jitterThisFrame,
            0f,
            Random.Range(-1f, 1f) * jitterThisFrame);

        // 归一化把扰动后的向量投影回单位圆；再乘半径，得到圆周上的偏移点。
        // 零向量没有方向，使用局部前方作为安全方向，避免归一化后丢失圆盘目标。
        m_localWanderTarget.y = 0f;
        if (m_localWanderTarget.sqrMagnitude < 0.000001f)
            m_localWanderTarget = Vector3.forward;
        m_localWanderTarget = m_localWanderTarget.normalized * m_wanderRadius;

        // 局部目标 = 圆周偏移 + 前向距离；TransformPoint 完成朝向旋转和平移。
        Vector3 localTarget = m_localWanderTarget + Vector3.forward * m_wanderDistance;
        m_worldWanderTarget = transform.TransformPoint(localTarget);
        m_worldWanderTarget.y = transform.position.y;

        // 转向力 = 世界目标位置 - 自身位置，方向指向漫游目标。
        Vector3 steeringForce = m_worldWanderTarget - transform.position;
        steeringForce.y = 0f;
        return steeringForce;
    }

    // ==================== Debug 绘制 ====================

    private void OnDrawGizmos()
    {
        if (!m_debugDrawGizmos || !Application.isPlaying)
            return;

        // 圆盘中心在车辆前方；圆盘半径显示可选漫游方向范围。
        Vector3 circleCenter = transform.position + transform.forward * m_wanderDistance;
        circleCenter.y = transform.position.y;
        Gizmos.color = m_circleColor;
        Gizmos.DrawWireSphere(circleCenter, m_wanderRadius);
        Gizmos.color = m_targetColor;
        Gizmos.DrawSphere(m_worldWanderTarget, 0.12f);
        Gizmos.color = m_velocityColor;
        Gizmos.DrawRay(transform.position, m_velocity);
        Gizmos.color = m_forceColor;
        Gizmos.DrawRay(transform.position, m_lastSteeringForce);

        // 点击目标连线用于显示目标球位置；它不参与 Wander 转向力计算。
        if (m_target != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, m_target.position);
        }
    }

    // ==================== 公开接口 ====================

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
