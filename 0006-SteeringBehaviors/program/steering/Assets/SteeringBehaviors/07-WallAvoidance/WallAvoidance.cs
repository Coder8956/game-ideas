using UnityEngine;

/// <summary>
/// WallAvoidance 墙面躲避行为，按 Buckland SteeringBehavior::WallAvoidance 的
/// feeler 探测与法线推力算法实现。车辆沿 XZ 平面移动，目标来自点击生成的 PlacedSphere。
/// </summary>
public class WallAvoidance : MonoBehaviour
{
    [Header("目标设置")] [SerializeField] private string m_targetName = "PlacedSphere";

    [Header("墙面探测设置")] [SerializeField] private string m_wallTag = "ObstacleWall";
    [SerializeField] private float m_feelerLength = 5f;
    [SerializeField] private float m_sideFeelerLength = 2.5f;
    [SerializeField] private float m_sideFeelerAngle = 45f;

    [Header("车辆参数")] [SerializeField] private float m_maxSpeed = 8f;
    [SerializeField] private float m_maxForce = 24f;
    [SerializeField] private float m_mass = 1f;

    [Header("Debug 设置")] [SerializeField] private bool m_debugDrawGizmos = true;
    [SerializeField] private Color m_feelerColor = Color.gray;
    [SerializeField] private Color m_hitColor = Color.red;
    [SerializeField] private Color m_forceColor = Color.yellow;
    [SerializeField] private Color m_targetColor = Color.cyan;

    private Transform m_target;
    private GameObject[] m_walls = System.Array.Empty<GameObject>();
    private Vector3 m_velocity;
    private Vector3 m_lastSteeringForce;
    private Vector3[] m_feelers = System.Array.Empty<Vector3>();
    private Vector3 m_lastWallHit;
    private bool m_hasWallHit;

    private void Start()
    {
        RefreshWalls();
    }

    private void Update()
    {
        if (m_target == null)
        {
            GameObject targetObject = GameObject.Find(m_targetName);
            if (targetObject == null)
                return;
            m_target = targetObject.transform;
        }

        float deltaTime = Time.deltaTime;

        // WallAvoidance 是唯一避障行为；Seek 仅提供朝点击目标前进的基础期望。
        Vector3 steeringForce = CalculateSeekSteering(m_target.position) + CalculateWallAvoidanceSteering();
        m_lastSteeringForce = Vector3.ClampMagnitude(steeringForce, m_maxForce);

        // 牛顿第二定律 F = ma，故加速度 a = F / m；保护质量避免除零。
        Vector3 acceleration = m_lastSteeringForce / Mathf.Max(m_mass, 0.0001f);
        // 显式欧拉积分：v(t+dt)=v(t)+a*dt，随后将速度限制在 MaxSpeed 内。
        m_velocity += acceleration * deltaTime;
        m_velocity.y = 0f;
        m_velocity = Vector3.ClampMagnitude(m_velocity, m_maxSpeed);
        // 位置积分：p(t+dt)=p(t)+v(t+dt)*dt。
        transform.position += m_velocity * deltaTime;

        if (m_velocity.sqrMagnitude > 0.00000001f)
            transform.rotation = Quaternion.LookRotation(m_velocity.normalized, Vector3.up);
    }

    /// <summary>
    /// 发出前、左前、右前三条 feeler。取最近墙面命中点，并把墙面法线乘以
    /// (探针长度 - 命中距离)，令越近的墙产生越强的推离力。
    /// </summary>
    private Vector3 CalculateWallAvoidanceSteering()
    {
        Vector3 forward = m_velocity.sqrMagnitude > 0.00000001f
            ? m_velocity.normalized
            : transform.forward;
        forward.y = 0f;
        forward = forward.sqrMagnitude > 0.00000001f ? forward.normalized : Vector3.forward;

        Vector3 left = Quaternion.AngleAxis(-m_sideFeelerAngle, Vector3.up) * forward;
        Vector3 right = Quaternion.AngleAxis(m_sideFeelerAngle, Vector3.up) * forward;
        m_feelers = new[] {forward * m_feelerLength, left * m_sideFeelerLength, right * m_sideFeelerLength};

        m_hasWallHit = false;
        float closestDistance = float.MaxValue;
        Vector3 avoidanceForce = Vector3.zero;
        Vector3 origin = transform.position;

        // 与 C++ 的 feeler/wall 线段检测一致：遍历墙面 collider，保留距离最近的相交点。
        foreach (GameObject wall in m_walls)
        {
            if (wall == null || !wall.activeInHierarchy)
                continue;
            Collider wallCollider = wall.GetComponent<Collider>();
            if (wallCollider == null)
                continue;

            for (int i = 0; i < m_feelers.Length; i++)
            {
                Vector3 feeler = m_feelers[i];
                float feelerLength = feeler.magnitude;
                if (feelerLength <= 0f || !wallCollider.Raycast(new Ray(origin, feeler / feelerLength),
                    out RaycastHit hit, feelerLength))
                    continue;
                if (hit.distance >= closestDistance)
                    continue;

                closestDistance = hit.distance;
                m_lastWallHit = hit.point;
                m_hasWallHit = true;
                // 避让推力 = 命中表面法线 × 剩余探针长度（L - d）。
                avoidanceForce = hit.normal * (feelerLength - hit.distance);
            }
        }

        avoidanceForce.y = 0f;
        return avoidanceForce;
    }

    /// <summary>期望速度 = 指向目标的单位向量乘最大速度；Seek 力 = 期望速度减当前速度。</summary>
    private Vector3 CalculateSeekSteering(Vector3 targetPosition)
    {
        Vector3 toTarget = targetPosition - transform.position;
        toTarget.y = 0f;
        return toTarget.normalized * m_maxSpeed - m_velocity;
    }

    /// <summary>缓存场景中 Tag 为 ObstacleWall 且带 Collider 的墙；运行时增删墙后可手动刷新。</summary>
    public void RefreshWalls()
    {
        m_walls = GameObject.FindGameObjectsWithTag(m_wallTag);
        Debug.Log($"Wall Count:{m_walls.Length}");
    }

    private void OnDrawGizmos()
    {
        if (!m_debugDrawGizmos || !Application.isPlaying)
            return;

        Gizmos.color = m_feelerColor;
        for (int i = 0; i < m_feelers.Length; i++)
            Gizmos.DrawRay(transform.position, m_feelers[i]);
        if (m_hasWallHit)
        {
            Gizmos.color = m_hitColor;
            Gizmos.DrawSphere(m_lastWallHit, 0.12f);
        }

        if (m_target != null)
        {
            Gizmos.color = m_targetColor;
            Gizmos.DrawLine(transform.position, m_target.position);
        }

        Gizmos.color = m_forceColor;
        Gizmos.DrawRay(transform.position, m_lastSteeringForce);
    }

    public Vector3 GetVelocity() => m_velocity;
    public float GetMaxSpeed() => m_maxSpeed;
    public void SetMaxSpeed(float speed) => m_maxSpeed = speed;
    public float GetMaxForce() => m_maxForce;
    public void SetMaxForce(float force) => m_maxForce = force;
    public float GetMass() => m_mass;
    public void SetMass(float mass) => m_mass = mass;
}