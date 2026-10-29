using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 相机射线点击放置器（挂在 Main Camera 上）
/// 功能：
/// 1. 每帧从相机向鼠标位置发射射线，获取碰撞位置
/// 2. 点击鼠标左键时将全局唯一的占位球（PlacedSphere）移动到碰撞位置，首次点击时创建
/// 3. Debug 开启时使用 Gizmos 绘制射线和碰撞位置（Scene 视图可见，Game 视图需开启 Gizmos 开关）
/// </summary>
public class CameraRayClickPlacer : MonoBehaviour
{
    // ==================== 私有字段 ====================

    [Header("射线设置")]
    [SerializeField] private float m_maxRayDistance = 100f;  // 射线最大检测距离
    [SerializeField] private LayerMask m_rayLayerMask = ~0;  // 射线可命中的层级，默认全部

    [Header("球体设置")]
    [SerializeField] private float m_sphereRadius = 0.5f;    // 放置球体的半径，Unity 原始球体直径为 1

    [Header("Debug 设置")]
    [SerializeField] private bool m_debugDrawGizmos = true;  // 是否用 Gizmos 绘制射线与碰撞位置
    [SerializeField] private Color m_rayColor = Color.yellow; // 射线绘制颜色
    [SerializeField] private Color m_hitColor = Color.red;   // 碰撞位置绘制颜色

    private Camera m_camera;     // 缓存相机组件，避免每帧查找
    private GameObject m_sphere;  // 全局唯一的占位球缓存，创建后一直复用
    private Ray m_currentRay;    // 当前帧从相机发出的射线，供 Gizmos 绘制
    private Vector3 m_hitPoint;  // 当前帧射线的碰撞位置
    private Vector3 m_hitNormal; // 当前帧射线的碰撞法线
    private bool m_hasHit;       // 当前帧射线是否命中

    // ==================== 生命周期 ====================

    private void Awake()
    {
        m_camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (m_camera == null || Mouse.current == null)
            return;

        // 1. 从相机向鼠标位置发射射线
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        m_currentRay = m_camera.ScreenPointToRay(mousePosition);

        // 检测射线碰撞，记录碰撞位置
        m_hasHit = Physics.Raycast(m_currentRay, out RaycastHit hitInfo, m_maxRayDistance, m_rayLayerMask);
        if (!m_hasHit)
            return;

        m_hitPoint = hitInfo.point;
        m_hitNormal = hitInfo.normal;

        // 2. 点击鼠标左键：将占位球移动到碰撞位置
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            PlaceSphereAt(m_hitPoint);
        }
    }

    // ==================== 放置逻辑 ====================

    /// <summary>
    /// 将全局唯一的占位球放到指定碰撞位置：首次调用时创建，之后仅移动位置
    /// </summary>
    private void PlaceSphereAt(Vector3 position)
    {
        // 缓存引用缺失时才创建（含占位球被外部销毁后的 Unity 假 null），保证全局仅此一个
        if (m_sphere == null)
        {
            m_sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            m_sphere.name = "PlacedSphere";
            // Unity 原始球体直径为 1，按目标半径换算缩放
            m_sphere.transform.localScale = Vector3.one * (m_sphereRadius * 2f);
        }

        m_sphere.transform.position = position;
    }

    // ==================== Debug 绘制 ====================

    private void OnDrawGizmos()
    {
        // Gizmos 依赖运行时的射线数据，仅在 Play Mode 下绘制
        if (!m_debugDrawGizmos || !Application.isPlaying)
            return;

        // 绘制射线：命中时画到碰撞位置，未命中画到最大检测距离
        Gizmos.color = m_rayColor;
        float rayLength = m_hasHit ? Vector3.Distance(m_currentRay.origin, m_hitPoint) : m_maxRayDistance;
        Gizmos.DrawRay(m_currentRay.origin, m_currentRay.direction * rayLength);

        if (!m_hasHit)
            return;

        // 绘制碰撞位置（红色小球标记）与碰撞法线
        Gizmos.color = m_hitColor;
        Gizmos.DrawSphere(m_hitPoint, 0.1f);
        Gizmos.DrawRay(m_hitPoint, m_hitNormal);
    }

    // ==================== 公开接口 ====================

    /// <summary>获取当前帧射线是否命中</summary>
    public bool HasHit() => m_hasHit;

    /// <summary>获取当前帧射线的碰撞位置（未命中时无意义）</summary>
    public Vector3 GetHitPoint() => m_hitPoint;
}
