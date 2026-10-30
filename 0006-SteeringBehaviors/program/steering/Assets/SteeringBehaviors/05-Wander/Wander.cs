using UnityEngine;

/// <summary>
/// Wander 漫游行为：在车辆前方的圆盘上逐步移动一个目标点，形成平滑、持续变化的行进方向。
/// 算法对应 Buckland SteeringBehavior::Wander：在局部坐标中构造圆盘目标，
/// 每帧对目标施加小幅随机偏移，再把它转换到世界坐标并作为转向力。
/// </summary>
public class Wander : MonoBehaviour
{
    // ==================== 私有字段 ====================

    [Header("漫游参数（对应 Buckland 的 Wander 参数）")]
    [SerializeField] private float m_wanderRadius = 2f; // 前方漫游圆盘半径，决定方向偏转幅度
    [SerializeField] private float m_wanderDistance = 3f; // 圆盘中心距车辆的前向距离
    [SerializeField] private float m_wanderJitter = 1f; // 每秒施加到圆盘目标上的随机扰动量

    [Header("车辆参数（对应 Buckland 的 MaxSpeed / MaxForce / Mass）")]
    [SerializeField] private float m_maxSpeed = 8f; // 最大速度
    [SerializeField] private float m_maxForce = 24f; // 最大转向力
    [SerializeField] private float m_mass = 1f; // 质量

    [Header("Debug 设置")]
    [SerializeField] private bool m_debugDrawGizmos = true; // 是否绘制漫游圆盘与方向向量
    [SerializeField] private Color m_circleColor = Color.cyan; // 漫游圆盘颜色
    [SerializeField] private Color m_targetColor = Color.yellow; // 圆盘目标点颜色
    [SerializeField] private Color m_velocityColor = Color.green; // 当前速度颜色
    [SerializeField] private Color m_forceColor = Color.red; // 转向力颜色

    private Vector3 m_velocity; // 当前速度，仅 XZ 平面有效
    private Vector3 m_localWanderTarget; // 漫游圆盘上的目标点，车辆局部坐标
    private Vector3 m_worldWanderTarget; // 漫游目标点，世界坐标，仅供调试显示
    private Vector3 m_lastSteeringForce; // 最近一帧的转向力，仅供调试显示

    // ==================== 生命周期 ====================

    private void Start()
    {
        // 初始目标位于圆盘正前方；之后每帧只做小幅随机偏移以保持连续性。
        m_localWanderTarget = new Vector3(0f, 0f, m_wanderRadius);
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;

        // 1. 计算 Wander 转向力。原算法以车辆当前朝向作为局部前方，
        // 并在圆盘目标上叠加随机扰动；此行为不需要鼠标目标球。
        Vector3 steeringForce = CalculateWanderSteering(deltaTime);

        // 对应原工程合成层的力截断；此脚本只启用 Wander，权重为 1。
        steeringForce = Vector3.ClampMagnitude(steeringForce, m_maxForce);
        m_lastSteeringForce = steeringForce;

        // 2. 按 Vehicle::UpdateMovement 的顺序积分：力/质量、速度、限速、位置。
        Vector3 acceleration = steeringForce / Mathf.Max(m_mass, 0.0001f);
        m_velocity += acceleration * deltaTime;
        m_velocity = Vector3.ClampMagnitude(m_velocity, m_maxSpeed);
        transform.position += m_velocity * deltaTime;

        // 3. 车头始终朝速度方向，速度近零时保留原朝向。
        if (m_velocity.sqrMagnitude > 0.00000001f)
            transform.rotation = Quaternion.LookRotation(m_velocity.normalized, Vector3.up);
    }

    // ==================== Wander 行为 ====================

    /// <summary>
    /// 计算漫游转向力。随机量乘以 deltaTime，使抖动强度不随帧率改变。
    /// </summary>
    private Vector3 CalculateWanderSteering(float deltaTime)
    {
        // WanderJitter 使圆盘上的目标点每帧作小幅随机移动，累积后产生平滑曲线。
        float jitterThisFrame = m_wanderJitter * deltaTime;
        m_localWanderTarget += new Vector3(
            Random.Range(-1f, 1f) * jitterThisFrame,
            0f,
            Random.Range(-1f, 1f) * jitterThisFrame);

        // 将目标限制在圆周上（XZ 平面），确保它始终位于漫游圆盘边缘。
        Vector3 circleTarget = m_localWanderTarget;
        circleTarget.y = 0f;
        if (circleTarget.sqrMagnitude < 0.000001f)
            circleTarget = Vector3.forward * 0.0001f;
        circleTarget = circleTarget.normalized * m_wanderRadius;
        m_localWanderTarget = circleTarget;

        // 在局部空间中，圆盘中心位于车辆前方 WanderDistance，目标点再加圆盘偏移。
        Vector3 localTarget = circleTarget + Vector3.forward * m_wanderDistance;
        Vector3 worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = transform.position.y;
        m_worldWanderTarget = worldTarget;

        // 转向力指向世界空间中的漫游目标，等价于原工程 Wander() 返回的力。
        Vector3 force = worldTarget - transform.position;
        force.y = 0f;
        return force;
    }

    // ==================== Debug 绘制 ====================

    private void OnDrawGizmos()
    {
        if (!m_debugDrawGizmos || !Application.isPlaying)
            return;

        // 绘制前方圆盘、圆盘目标点，以及当前速度和转向力，便于观察漫游计算。
        Vector3 center = transform.position + transform.forward * m_wanderDistance;
        center.y = transform.position.y;
        Gizmos.color = m_circleColor;
        Gizmos.DrawWireSphere(center, m_wanderRadius);
        Gizmos.color = m_targetColor;
        Gizmos.DrawSphere(m_worldWanderTarget, 0.12f);
        Gizmos.color = m_velocityColor;
        Gizmos.DrawRay(transform.position, m_velocity);
        Gizmos.color = m_forceColor;
        Gizmos.DrawRay(transform.position, m_lastSteeringForce);
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
