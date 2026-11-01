using UnityEngine;

/// <summary>
/// ObstacleAvoidance 障碍物规避行为。
///
/// 主要算法移植自 Buckland《Programming Game AI by Example》第 3 章的
/// SteeringBehavior::ObstacleAvoidance：在车辆前方建立随速度变长的检测盒，
/// 将障碍物变换到车辆局部坐标，找出最先相交的障碍，并施加横向推力与制动力。
///
/// 本示例将避障力与朝鼠标点击球（PlacedSphere）的 Seek 力相加：Seek 负责前进，
/// ObstacleAvoidance 只在路径受阻时修正前进轨迹。车辆始终只在 XZ 平面移动。
/// </summary>
public class ObstacleAvoidance : MonoBehaviour
{
    // ==================== 私有字段 ====================

    [Header("目标设置")]
    [SerializeField] private string m_targetName = "PlacedSphere"; // CameraRayClickPlacer 创建的目标球名称

    [Header("避障参数（对应 Buckland 的检测盒与 BrakingWeight）")]
    [SerializeField] private string m_obstacleTag = "Obstacle"; // 所有障碍物必须使用此 Tag
    [SerializeField] private float m_minDetectionBoxLength = 5f; // 静止时的检测盒长度
    [SerializeField] private float m_vehicleRadius = 0.75f; // 车辆没有 Collider 时使用的碰撞半径
    [SerializeField] private float m_brakingWeight = 0.2f; // 原算法的前向制动力权重

    [Header("车辆参数（对应 Buckland 的 MaxSpeed / MaxForce / Mass）")]
    [SerializeField] private float m_maxSpeed = 8f;
    [SerializeField] private float m_maxForce = 24f;
    [SerializeField] private float m_mass = 1f;

    [Header("Debug 设置")]
    [SerializeField] private bool m_debugDrawGizmos = true;
    [SerializeField] private Color m_detectionBoxColor = Color.gray;
    [SerializeField] private Color m_threatColor = Color.red;
    [SerializeField] private Color m_velocityColor = Color.green;
    [SerializeField] private Color m_forceColor = Color.yellow;
    [SerializeField] private Color m_targetLineColor = Color.cyan;

    private Transform m_target;
    private GameObject[] m_obstacles = System.Array.Empty<GameObject>();
    private Vector3 m_velocity;
    private Vector3 m_lastSteeringForce;
    private float m_detectionBoxLength;
    private GameObject m_closestIntersectingObstacle;

    // ==================== 生命周期 ====================

    private void Start()
    {
        // 场景障碍物通常是静态对象；缓存引用可避免每帧按 Tag 搜索整个场景。
        RefreshObstacles();
        m_detectionBoxLength = m_minDetectionBoxLength;
    }

    private void Update()
    {
        // 点击前目标球不存在，车辆保持待命；被删除后同样会重新查找。
        if (m_target == null)
        {
            GameObject targetObject = GameObject.Find(m_targetName);
            if (targetObject == null)
                return;

            m_target = targetObject.transform;
        }

        float deltaTime = Time.deltaTime;

        // C++ 的行为合成器以避障为更高优先级，再叠加其它行为。
        // 此处的其它行为只保留到点击目标的 Seek，避免混入无关转向行为。
        Vector3 seekForce = CalculateSeekSteering(m_target.position);
        Vector3 avoidanceForce = CalculateObstacleAvoidanceSteering();
        Vector3 steeringForce = seekForce + avoidanceForce;
        steeringForce = Vector3.ClampMagnitude(steeringForce, m_maxForce);
        m_lastSteeringForce = steeringForce;

        // 牛顿第二定律：F = ma，因此 a = F / m。
        // Mathf.Max 防止 Inspector 中意外把质量设为零而产生无穷大的加速度。
        Vector3 acceleration = steeringForce / Mathf.Max(m_mass, 0.0001f);

        // 显式欧拉积分：v(t + dt) = v(t) + a × dt。
        m_velocity += acceleration * deltaTime;
        m_velocity.y = 0f;
        m_velocity = Vector3.ClampMagnitude(m_velocity, m_maxSpeed);

        // 位置积分：p(t + dt) = p(t) + v(t + dt) × dt。
        transform.position += m_velocity * deltaTime;

        // 速度方向就是车辆前向；静止时保留现有朝向，避免零向量旋转。
        if (m_velocity.sqrMagnitude > 0.00000001f)
            transform.rotation = Quaternion.LookRotation(m_velocity.normalized, Vector3.up);
    }

    // ==================== ObstacleAvoidance 行为 ====================

    /// <summary>
    /// 完整移植 SteeringBehavior::ObstacleAvoidance 的检测与局部转向计算。
    /// </summary>
    private Vector3 CalculateObstacleAvoidanceSteering()
    {
        // 检测盒长度 = 最小长度 + (当前速度 / 最大速度) × 最小长度。
        // 速度为零时看 m_minDetectionBoxLength；满速时看两倍距离，给高速车辆更早的反应时间。
        float speedRatio = m_maxSpeed > 0f ? m_velocity.magnitude / m_maxSpeed : 0f;
        m_detectionBoxLength = m_minDetectionBoxLength * (1f + Mathf.Clamp01(speedRatio));

        GameObject closestObstacle = null;
        Vector3 closestLocalPosition = Vector3.zero;
        float closestIntersectionDistance = float.MaxValue;
        float vehicleRadius = GetHorizontalRadius(gameObject, m_vehicleRadius);

        foreach (GameObject obstacle in m_obstacles)
        {
            if (obstacle == null || !obstacle.activeInHierarchy)
                continue;

            // InverseTransformPoint 完成世界坐标到车辆局部坐标的变换：
            // 局部 z 为前方距离，局部 x 为横向偏移，正好对应 C++ 中的 local x / local y。
            Vector3 localPosition = transform.InverseTransformPoint(obstacle.transform.position);
            localPosition.y = 0f;

            // z < 0 表示障碍在车后，C++ 会直接忽略。
            if (localPosition.z < 0f)
                continue;

            float expandedRadius = GetHorizontalRadius(obstacle, 0.5f) + vehicleRadius;

            // |横向偏移| < 扩张半径：障碍圆与车辆沿前向的中心线可能相交。
            if (Mathf.Abs(localPosition.x) >= expandedRadius)
                continue;

            // 解圆 x² + y² = r² 的前向交点：
            // intersectionZ = centerZ - sqrt(expandedRadius² - centerX²)。
            // 取最小正交点，即车辆最先可能碰到的障碍。
            float squareRootPart = Mathf.Sqrt(expandedRadius * expandedRadius - localPosition.x * localPosition.x);
            float intersectionDistance = localPosition.z - squareRootPart;
            if (intersectionDistance <= 0f)
                intersectionDistance = localPosition.z + squareRootPart;

            if (intersectionDistance < closestIntersectionDistance && intersectionDistance <= m_detectionBoxLength)
            {
                closestIntersectionDistance = intersectionDistance;
                closestObstacle = obstacle;
                closestLocalPosition = localPosition;
            }
        }

        m_closestIntersectingObstacle = closestObstacle;
        if (closestObstacle == null)
            return Vector3.zero;

        float obstacleRadius = GetHorizontalRadius(closestObstacle, 0.5f);

        // multiplier = 1 + (检测盒长度 - 障碍前向距离) / 检测盒长度。
        // 障碍越接近车头，该值越大，避让也越强。
        float multiplier = 1f + (m_detectionBoxLength - closestLocalPosition.z) / m_detectionBoxLength;

        // C++ 局部坐标把车头定义为 +x、横向定义为 +y；Unity 这里改为 +z 前向、+x 横向。
        // 横向力 = (障碍半径 - 横向偏移) × multiplier；这是参考实现的原始公式，
        // 用于把车辆推出当前的预测碰撞轨迹。
        float lateralForce = (obstacleRadius - closestLocalPosition.x) * multiplier;

        // 前向制动力 = (障碍半径 - 前向距离) × BrakingWeight。
        // 障碍靠近时结果为负，抵消前进速度，让车辆不会贴着障碍高速转弯。
        float brakingForce = (obstacleRadius - closestLocalPosition.z) * m_brakingWeight;

        // TransformDirection 只应用车辆旋转、不叠加位置，相当于 C++ 的 VectorToWorldSpace。
        Vector3 localSteeringForce = new Vector3(lateralForce, 0f, brakingForce);
        return transform.TransformDirection(localSteeringForce);
    }

    /// <summary>计算前往鼠标点击目标的 Seek 力，供避障行为维持前进方向。</summary>
    private Vector3 CalculateSeekSteering(Vector3 targetPosition)
    {
        Vector3 toTarget = targetPosition - transform.position;
        toTarget.y = 0f;

        // 期望速度 = Normalize(目标 - 自身) × MaxSpeed；转向力 = 期望速度 - 当前速度。
        Vector3 desiredVelocity = toTarget.normalized * m_maxSpeed;
        return desiredVelocity - m_velocity;
    }

    /// <summary>取得物体在 XZ 平面的近似圆形碰撞半径。</summary>
    private static float GetHorizontalRadius(GameObject targetObject, float fallbackRadius)
    {
        Collider targetCollider = targetObject.GetComponent<Collider>();
        if (targetCollider == null)
            return fallbackRadius;

        // AABB 的 x/z 半尺寸取较大者，确保圆形近似完整包住 Collider 的水平投影。
        Vector3 extents = targetCollider.bounds.extents;
        return Mathf.Max(extents.x, extents.z);
    }

    /// <summary>重新读取 Tag 为 Obstacle 的场景对象；供运行时增删障碍后调用。</summary>
    public void RefreshObstacles()
    {
        m_obstacles = GameObject.FindGameObjectsWithTag(m_obstacleTag);
    }

    // ==================== Debug 绘制 ====================

    private void OnDrawGizmos()
    {
        if (!m_debugDrawGizmos || !Application.isPlaying)
            return;

        // 检测盒在车辆局部坐标中从 z=0 延伸至 z=长度，半宽为车辆半径。
        float radius = GetHorizontalRadius(gameObject, m_vehicleRadius);
        Vector3 leftNear = transform.TransformPoint(new Vector3(-radius, 0f, 0f));
        Vector3 rightNear = transform.TransformPoint(new Vector3(radius, 0f, 0f));
        Vector3 leftFar = transform.TransformPoint(new Vector3(-radius, 0f, m_detectionBoxLength));
        Vector3 rightFar = transform.TransformPoint(new Vector3(radius, 0f, m_detectionBoxLength));
        Gizmos.color = m_detectionBoxColor;
        Gizmos.DrawLine(leftNear, leftFar);
        Gizmos.DrawLine(leftFar, rightFar);
        Gizmos.DrawLine(rightFar, rightNear);

        if (m_closestIntersectingObstacle != null)
        {
            Gizmos.color = m_threatColor;
            Gizmos.DrawWireSphere(m_closestIntersectingObstacle.transform.position,
                GetHorizontalRadius(m_closestIntersectingObstacle, 0.5f));
        }

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
}
