using UnityEngine;

/// <summary>
/// Seek 靠近行为 —— 转向行为（Steering Behaviors）中最基础的一种。
/// 移植自 Buckland《Programming Game AI by Example》第 3 章参考工程：
///   - SteeringBehaviors.cpp 的 SteeringBehavior::Seek()：计算转向力；
///   - Vehicle.cpp 的 Vehicle::UpdateMovement()：把力积分成运动。
///
/// 【算法原理】
///   1. 想要的速度 DesiredVelocity = Normalize(目标位置 - 自身位置) × MaxSpeed
///      —— "以最大速度直冲目标"的理想速度；
///   2. 转向力 SteeringForce = DesiredVelocity - 当前速度
///      —— 速度差就是"该补/该减"的力：方向朝目标，大小随当前速度偏差变化；
///   3. 转向力截断到 MaxForce（引擎极限，对应原工程的 Truncate）；
///   4. 牛顿第二定律积分运动：加速度 = 力 ÷ 质量 → 速度 += 加速度 × dt
///      → 速度限幅到 MaxSpeed → 位置 += 速度 × dt → 车头对齐速度方向。
///
/// 【本脚本的设定】
///   - 只实现 Seek 这一种行为，不混合其它转向行为；
///   - 目标是鼠标点击生成的占位球（PlacedSphere，见 Assets/Common/CameraRayClickPlacer.cs）；
///   - 相机俯视 + 平坦地形，故只在 XZ 平面上移动（y 保持不变）；
///   - Seek 的特征是"永不减速停靠"：冲过目标后会绕回来反复穿过目标点
///     （需要停靠请用 Arrive，本脚本刻意保留该特征以演示 Seek 本质）。
/// </summary>
public class Seek : MonoBehaviour
{
    // ==================== 私有字段 ====================

    [Header("目标设置")]
    [SerializeField] private string m_targetName = "PlacedSphere"; // 目标占位球名称（CameraRayClickPlacer 点击生成）

    [Header("车辆参数（对应 Buckland 的 MaxSpeed / MaxForce / Mass）")]
    [SerializeField] private float m_maxSpeed = 8f;  // 最大速度：期望速度与实际速度的长度上限
    [SerializeField] private float m_maxForce = 24f; // 最大转向力：单帧可施加的力的上限（决定转向/加速能力）
    [SerializeField] private float m_mass = 1f;     // 质量：越大同样大小的力产生的加速度越小（F = ma）

    [Header("Debug 设置")]
    [SerializeField] private bool m_debugDrawGizmos = true;  // 是否用 Gizmos 绘制调试信息
    [SerializeField] private Color m_velocityColor = Color.green; // 当前速度向量颜色
    [SerializeField] private Color m_forceColor = Color.yellow;   // 当前转向力向量颜色
    [SerializeField] private Color m_targetLineColor = Color.red; // 自身到目标的连线颜色

    private Transform m_target;           // 缓存目标占位球的 Transform，避免每帧全场景查找
    private Vector3 m_velocity;            // 当前速度（仅 XZ 分量有效，对应原工程 m_vVelocity）
    private Vector3 m_lastSteeringForce;   // 本帧转向力缓存，仅供 Gizmos 绘制

    // ==================== 生命周期 ====================

    private void Update()
    {
        // 目标尚未生成（还没点击过）：不施加任何力，原地待命
        // （Unity 的假 null 让"被销毁的目标"也能走这里重新查找）
        if (m_target == null)
        {
            GameObject targetGo = GameObject.Find(m_targetName);
            if (targetGo == null)
                return;

            m_target = targetGo.transform;
        }

        float deltaTime = Time.deltaTime;

        // ================== 第 1 步：计算 Seek 转向力 ==================
        // 对应 SteeringBehavior::Seek()：力 = 期望速度 - 当前速度
        Vector3 steeringForce = CalculateSeekSteering(m_target.position);

        // ================== 第 2 步：力截断到 MaxForce ==================
        // 对应 Calculate 合成层的 Truncate(MaxForce)：再理想的力也受"引擎推力极限"约束。
        // 单一行为时权重恒为 1，等价于原工程加权合成后再截断的结果。
        steeringForce = Vector3.ClampMagnitude(steeringForce, m_maxForce);
        m_lastSteeringForce = steeringForce;

        // ================== 第 3 步：力 -> 加速度 -> 速度 -> 位置 ==================
        // 对应 Vehicle::UpdateMovement() 的欧拉积分，四步顺序不可颠倒：

        // 牛顿第二定律：加速度 = 力 ÷ 质量（质量为 1 时加速度 = 力本身）
        Vector3 acceleration = steeringForce / m_mass;

        // 速度累加：速度 += 加速度 × 时间（初速为 0，每帧被推进一点）
        m_velocity += acceleration * deltaTime;

        // 限速：速度向量超过 MaxSpeed 就把长度截断到 MaxSpeed
        //（对应 m_vVelocity.Truncate(m_dMaxSpeed)，模拟引擎极限）
        m_velocity = Vector3.ClampMagnitude(m_velocity, m_maxSpeed);

        // 位置更新：新位置 = 旧位置 + 速度 × 时间
        //（速度只有 XZ 分量，y 自然保持不变，坦克贴地行驶）
        transform.position += m_velocity * deltaTime;

        // ================== 第 4 步：车头对齐速度方向 ==================
        // 对应 Vehicle 里的朝向更新：只要速度非零，朝向 = 速度的单位向量。
        // 原工程阈值 0.00000001 用于避免对零向量归一化；3D 里直接用四元数朝向速度。
        if (m_velocity.sqrMagnitude > 0.00000001f)
        {
            transform.rotation = Quaternion.LookRotation(m_velocity.normalized, Vector3.up);
        }
    }

    // ==================== Seek 行为 ====================

    /// <summary>
    /// 计算 Seek 转向力（完整移植 SteeringBehavior::Seek）
    /// </summary>
    /// <param name="targetPos">目标位置</param>
    /// <returns>转向力 = 期望速度 - 当前速度</returns>
    private Vector3 CalculateSeekSteering(Vector3 targetPos)
    {
        // 指向目标的向量：目标位置 - 自身位置。
        // 屏蔽 y 分量：俯视 2D 演示只在 XZ 平面决策，防止坦克"抬头"飞行。
        Vector3 toTarget = targetPos - transform.position;
        toTarget.y = 0f;

        // 期望速度：指向目标的单位向量 × 最大速度
        //（对应 Vec2DNormalize(TargetPos - Pos) * MaxSpeed()）
        Vector3 desiredVelocity = toTarget.normalized * m_maxSpeed;

        // 转向力 = 期望速度 - 当前速度：
        // 当前速度越偏离理想值，纠正力越大；完全对准目标全速前进时力为零。
        //（目标正好在脚下时 toTarget 为零向量，归一化结果也是零向量，
        //  期望速度为零，转向力 = -当前速度 —— 正好把车刹住，符合原工程语义）
        Vector3 steeringForce = desiredVelocity - m_velocity;
        steeringForce.y = 0f;
        return steeringForce;
    }

    // ==================== Debug 绘制 ====================

    private void OnDrawGizmos()
    {
        // Gizmos 依赖运行时数据，仅在 Play Mode 下绘制
        if (!m_debugDrawGizmos || !Application.isPlaying)
            return;

        // 到目标的连线（红）：直观展示"正在朝谁寻的"
        if (m_target != null)
        {
            Gizmos.color = m_targetLineColor;
            Gizmos.DrawLine(transform.position, m_target.position);
        }

        // 当前速度向量（绿）：多长跑多快
        Gizmos.color = m_velocityColor;
        Gizmos.DrawRay(transform.position, m_velocity);

        // 当前转向力向量（黄）：本帧"想使劲"的方向和大小
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
