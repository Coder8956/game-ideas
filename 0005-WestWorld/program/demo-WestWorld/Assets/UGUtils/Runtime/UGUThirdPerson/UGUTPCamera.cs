using UnityEngine;
using UnityEngine.InputSystem;

namespace UGU.Runtime
{
    /// <summary>
    /// 相机旋转输入模式。
    /// </summary>
    public enum UGUTPCameraRotationMode
    {
        /// <summary>自由旋转：无需按住任何鼠标按键</summary>
        Free,

        /// <summary>按住鼠标左键旋转</summary>
        LeftButton,

        /// <summary>按住鼠标右键旋转</summary>
        RightButton,

        /// <summary>按住鼠标中键旋转</summary>
        MiddleButton,
    }

    /// <summary>
    /// 第三人称相机控制器。
    /// 负责相机的跟随、旋转、碰撞避让（裁剪）等逻辑，
    /// 使相机始终以目标角色为中心进行平滑环绕拍摄。
    /// </summary>
    [ExecuteAlways]
    public class UGUTPCamera : MonoBehaviour
    {
        // ── Inspector 配置 ────────────────────────────────────────

        [Header("Target")] [Tooltip("相机跟随的目标变换（通常是角色根节点）")] [SerializeField]
        private Transform m_target;

        [Header("Position")] [Tooltip("相机相对于目标右侧的偏移量")] [SerializeField]
        private float m_rightOffset = 0f;

        [Tooltip("相机与目标之间的默认距离")] [SerializeField] [Range(0.1f, 20f)]
        private float m_defaultDistance = 2.5f;

        [Tooltip("相机相对于目标的高度偏移")] [SerializeField] [Range(0f, 10f)]
        private float m_height = 1.4f;

        [Header("Smoothing")] [Tooltip("相机状态之间的旋转插值速度，值越大旋转越快")] [SerializeField] [Range(0f, 50f)]
        private float m_smoothCameraRotation = 12f;

        [Tooltip("相机位置跟随目标的平滑速度")] [SerializeField] [Range(0f, 50f)]
        private float m_smoothFollow = 10f;

        [Header("Zoom")] [Tooltip("是否启用鼠标滚轮缩放相机距离")] [SerializeField]
        private bool m_enableZoom = true;

        [Tooltip("滚轮缩放灵敏度")] [SerializeField] [Range(0f, 1f)] private float m_zoomSensitivity = 0.01f;

        [Tooltip("相机距离的最小值")] [SerializeField] [Range(0.1f, 10f)] private float m_minDistance = 1f;

        [Tooltip("相机距离的最大值")] [SerializeField] [Range(1f, 50f)] private float m_maxDistance = 10f;

        [Header("Rotation Input")]
        [Tooltip("相机旋转控制模式：Free=自由旋转，LeftButton=按住左键，RightButton=按住右键，MiddleButton=按住中键")]
        [SerializeField]
        private UGUTPCameraRotationMode m_rotationMode = UGUTPCameraRotationMode.Free;

        [Tooltip("鼠标 X 轴（水平）旋转灵敏度")] [SerializeField] [Range(0f, 10f)]
        private float m_xMouseSensitivity = 3f;

        [Tooltip("鼠标 Y 轴（垂直）旋转灵敏度")] [SerializeField] [Range(0f, 10f)]
        private float m_yMouseSensitivity = 3f;

        [Tooltip("鼠标移动缩放系数，用于将原始像素增量转换为旋转量")] [SerializeField] [Range(0f, 1f)]
        private float m_mouseDeltaScale = 0.1f;

        [Tooltip("垂直方向最小俯角限制（度）")] [SerializeField] [Range(-90f, 0f)]
        private float m_yMinLimit = -40f;

        [Tooltip("垂直方向最大仰角限制（度）")] [SerializeField] [Range(0f, 90f)]
        private float m_yMaxLimit = 80f;

        [Header("Collision")] [Tooltip("是否启用相机碰撞裁剪（避让遮挡物）")] [SerializeField]
        private bool m_enableCulling = true;

        [Tooltip("相机裁剪检测层，这些层上的物体将触发碰撞避让")] [SerializeField]
        private LayerMask m_cullingLayer = 1 << 0;

        [Header("Debug")] [Tooltip("调试用：在运行时锁定相机在角色正后方，便于对齐相机状态")] [SerializeField]
        private bool m_lockOnRun;

        [Tooltip("勾选后在编辑器模式下实时预览相机初始位置与朝向（无需进入 Play Mode）")] [SerializeField]
        private bool m_previewInEditor;

        // ── 运行时状态 ──────────────────────────────────────────

        /// <summary>相机实际注视的虚拟目标点（由鼠标旋转驱动）</summary>
        private Transform m_targetLookAt;

        /// <summary>当前目标位置缓存（已加上 pivot 偏移）</summary>
        private Vector3 m_currentTargetPos;

        /// <summary>当前相机位置（经过高度调整后）</summary>
        private Vector3 m_currentCPos;

        /// <summary>期望的相机位置（未经过碰撞裁剪的理想位置）</summary>
        private Vector3 m_desiredCPos;

        private Camera m_camera;

        /// <summary>当前实际距离（受碰撞裁剪影响，会动态变化）</summary>
        private float m_distance = 5f;

        /// <summary>当前鼠标 Y 轴累积旋转角度</summary>
        private float m_mouseY = 0f;

        /// <summary>当前鼠标 X 轴累积旋转角度</summary>
        private float m_mouseX = 0f;

        /// <summary>当前相机高度（碰撞时会在 cullingHeight 与 m_height 间插值）</summary>
        private float m_currentHeight;

        /// <summary>裁剪检测中记录的最小碰撞距离</summary>
        private float m_cullingDistance;

        /// <summary>碰撞裁剪时相机下压的最低高度</summary>
        private float m_cullingHeight = 0.2f;

        // ── 常量 ─────────────────────────────────────────────────

        /// <summary>高度检测用的球体半径</summary>
        private const float CheckHeightRadius = 0.4f;

        /// <summary>近裁剪面边距，用于扩大碰撞检测范围</summary>
        private const float ClipPlaneMargin = 0f;

        /// <summary>相机前向方向系数（-1 表示在目标后方）</summary>
        private const float ForwardDir = -1f;

        /// <summary>水平旋转最小限制（度）</summary>
        private const float XMinLimit = -360f;

        /// <summary>水平旋转最大限制（度）</summary>
        private const float XMaxLimit = 360f;

        /// <summary>碰撞裁剪最小间距，低于此值会进一步压缩距离</summary>
        private const float CullingMinDist = 0.1f;

        // ── 公共属性（运行时状态，外部只读） ─────────────

        public int IndexList { get; private set; }
        public int IndexLookPoint { get; private set; }
        public float OffSetPlayerPivot { get; private set; }
        public string CurrentStateName { get; private set; }
        public Transform CurrentTarget { get; private set; }
        public Vector2 MovementSpeed { get; private set; }

    /// <summary>虚拟注视点的前方方向（在 Update 中更新，供角色控制器在 LateUpdate 中同帧读取）</summary>
    public Vector3 LookForward => m_targetLookAt != null ? m_targetLookAt.forward : Vector3.forward;

        // ── 生命周期 ─────────────────────────────────────────────

        private void Start()
        {
            if (!Application.isPlaying) return;
            Init();
        }

        private void Update()
        {
            if (Application.isPlaying)
            {
                var mouse = Mouse.current;
                if (mouse == null) return;

                if (CanRotate(mouse))
                {
                    var delta = mouse.delta.ReadValue() * m_mouseDeltaScale;
                    RotateCamera(delta.x, delta.y);
                }

                // 鼠标滚轮缩放相机距离
                if (m_enableZoom)
                {
                    var scroll = mouse.scroll.ReadValue().y;
                    if (!Mathf.Approximately(scroll, 0f))
                    {
                        m_defaultDistance = Mathf.Clamp(m_defaultDistance - scroll * m_zoomSensitivity, m_minDistance,
                            m_maxDistance);
                    }
                }

                // 更新虚拟注视点旋转（前移至 Update，使角色控制器能在同帧 LateUpdate 中读取最新朝向）
                if (m_targetLookAt != null)
                {
                    var newRot = Quaternion.Euler(m_mouseY, m_mouseX, 0);
                    m_targetLookAt.rotation = Quaternion.Slerp(m_targetLookAt.rotation, newRot, m_smoothCameraRotation * Time.deltaTime);
                }
            }
            else if (m_previewInEditor)
            {
                PreviewInitialPosition();
            }
        }

        /// <summary>
        /// 在 LateUpdate 中执行相机移动，确保在所有 Update / FixedUpdate / 动画更新之后才更新相机位置，
        /// 避免相机与目标之间的帧内错位（消除抖动）。
        /// </summary>
        private void LateUpdate()
        {
            if (!Application.isPlaying) return;
            if (m_target == null || m_targetLookAt == null) return;
            if (m_camera == null) m_camera = GetComponent<Camera>();

            CameraMovement();
        }

        private void OnDestroy()
        {
            if (m_targetLookAt == null) return;

            if (Application.isPlaying)
                Destroy(m_targetLookAt.gameObject);
            else
                DestroyImmediate(m_targetLookAt.gameObject);
        }

        // ── 相机逻辑 ─────────────────────────────────────────────

        /// <summary>
        /// 根据当前旋转模式判断是否允许相机旋转。
        /// </summary>
        /// <param name="mouse">当前鼠标输入设备</param>
        /// <returns>是否允许旋转</returns>
        private bool CanRotate(Mouse mouse)
        {
            switch (m_rotationMode)
            {
                case UGUTPCameraRotationMode.LeftButton:
                    return mouse.leftButton.isPressed;
                case UGUTPCameraRotationMode.RightButton:
                    return mouse.rightButton.isPressed;
                case UGUTPCameraRotationMode.MiddleButton:
                    return mouse.middleButton.isPressed;
                default:
                    return true;
            }
        }

        /// <summary>
        /// 编辑器预览：根据当前 Inspector 配置直接计算并应用相机初始位置与朝向。
        /// 不依赖运行时状态（虚拟注视点、Time.deltaTime 等），
        /// 仅使用目标朝向、距离、高度等参数做一次性定位。
        /// </summary>
        private void PreviewInitialPosition()
        {
            if (m_target == null) return;

            if (m_camera == null)
                m_camera = GetComponent<Camera>();
            if (m_camera == null) return;

            // 初始角度取自目标朝向
            var mouseY = m_target.eulerAngles.x;
            var mouseX = m_target.eulerAngles.y;

            // 计算相机方向：后向 + 右侧偏移（与运行时 CameraMovement 一致）
            var rotation = Quaternion.Euler(mouseY, mouseX, 0);
            var lookForward = rotation * Vector3.forward;
            var lookRight = rotation * Vector3.right;
            var camDir = (ForwardDir * lookForward + m_rightOffset * lookRight).normalized;

            // 目标位置 + 高度偏移
            var targetPos = m_target.position;
            var heightOffset = new Vector3(0, m_height, 0);
            var pivotPos = targetPos + heightOffset;
            var cameraPos = pivotPos + camDir * m_defaultDistance;

            transform.position = cameraPos;

            // 注视点：与运行时一致，包含前向偏移和右侧偏移分量
            var lookPoint = pivotPos + lookForward * 2f;
            lookPoint += lookRight * Vector3.Dot(camDir * m_defaultDistance, lookRight);
            transform.rotation = Quaternion.LookRotation(lookPoint - cameraPos);
        }

        /// <summary>
        /// 相机移动核心逻辑：
        /// 1. 根据鼠标角度旋转虚拟注视点；
        /// 2. 基于注视点前方方向计算相机期望位置；
        /// 3. 通过近裁剪面四角射线检测碰撞并压缩距离；
        /// 4. 最终设置相机位置与朝向。
        /// </summary>
        private void CameraMovement()
        {
            if (CurrentTarget == null)
                return;

            var dt = Time.deltaTime;
            var tr = transform;

            // 缓存注视点方向，避免多次访问 Transform 属性
            var lookForward = m_targetLookAt.forward;
            var lookRight = m_targetLookAt.right;

            // 计算相机相对注视点的方向：后向 + 右侧偏移
            var camDir = (ForwardDir * lookForward + m_rightOffset * lookRight).normalized;

            // 计算目标位置（含 pivot 偏移）
            var targetPos = CurrentTarget.position;
            targetPos.y += OffSetPlayerPivot;
            m_currentTargetPos = targetPos;

            // 期望位置 = 目标位置 + 高度偏移
            var heightOffset = new Vector3(0, m_height, 0);
            m_desiredCPos = targetPos + heightOffset;

            // 本帧期望距离（碰撞裁剪前的目标距离）
            // 用局部变量承载裁剪结果，最后统一平滑 m_distance，避免先拉远再裁剪的来回抖动
            var desiredDistance = m_defaultDistance;

            if (m_enableCulling && m_camera != null)
            {
                // 当前位置 = 目标位置 + 当前高度（碰撞时可能更低）
                m_currentCPos = m_currentTargetPos + new Vector3(0, m_currentHeight, 0);

                // 头顶高度检测：如果上方有遮挡物，逐步降低相机高度
                if (Physics.SphereCast(targetPos, CheckHeightRadius, Vector3.up, out var hitInfo,
                    m_cullingHeight + 0.2f, m_cullingLayer))
                {
                    var t = hitInfo.distance - 0.2f;
                    t -= m_height;
                    t /= (m_cullingHeight - m_height);
                    m_cullingHeight = Mathf.Lerp(m_height, m_cullingHeight, Mathf.Clamp(t, 0.0f, 1.0f));
                }

                // 期望位置的裁剪检测：如果有遮挡则压缩期望距离
                var camOffset = camDir * desiredDistance;
                ClipPlanePoints oldPoints = NearClipPlanePoints(m_camera, m_desiredCPos + camOffset);

                if (CullingRayCast(m_desiredCPos, oldPoints, out hitInfo, desiredDistance + 0.2f, m_cullingLayer))
                {
                    desiredDistance = hitInfo.distance - 0.2f;
                    if (desiredDistance < m_defaultDistance)
                    {
                        // 距离过近时进一步降低相机高度
                        var t = hitInfo.distance;
                        t -= CullingMinDist;
                        t /= CullingMinDist;
                        m_currentHeight = Mathf.Lerp(m_cullingHeight, m_height, Mathf.Clamp(t, 0.0f, 1.0f));
                        m_currentCPos = m_currentTargetPos + new Vector3(0, m_currentHeight, 0);
                    }
                }
                else
                {
                    // 无遮挡时恢复默认高度
                    m_currentHeight = m_height;
                }

                // 当前位置的裁剪检测：进一步限制期望距离
                ClipPlanePoints planePoints = NearClipPlanePoints(m_camera, m_currentCPos + camDir * desiredDistance);
                if (CullingRayCast(m_currentCPos, planePoints, out hitInfo, desiredDistance, m_cullingLayer))
                    desiredDistance = Mathf.Min(desiredDistance, hitInfo.distance);
            }
            else
            {
                // 未启用裁剪时直接使用默认高度与期望位置
                m_currentHeight = m_height;
                m_currentCPos = m_desiredCPos;
            }

            // 平滑回弹：无遮挡时缓慢拉远到默认距离
            m_distance = Mathf.Lerp(m_distance, desiredDistance, m_smoothFollow * dt);
            // 碰撞收紧：不允许相机超过碰撞安全距离，防止穿模
            m_distance = Mathf.Min(m_distance, desiredDistance);

            // 计算注视点：当前位置前方 + 右侧偏移分量
            var lookPoint = m_currentCPos + lookForward * 2f;
            lookPoint += lookRight * Vector3.Dot(camDir * m_distance, lookRight);

            // 更新虚拟注视点位置
            m_targetLookAt.position = m_currentCPos;

            // 设置相机最终位置
            var finalPos = m_currentCPos + camDir * m_distance;
            tr.position = finalPos;

            // 相机朝向注视点
            tr.rotation = Quaternion.LookRotation(lookPoint - finalPos);

            MovementSpeed = Vector2.zero;
        }

        // ── 工具方法 ─────────────────────────────────────────────

        /// <summary>
        /// 从起点向近裁剪面四个角发射射线进行碰撞检测，
        /// 取最近碰撞距离作为裁剪距离。
        /// </summary>
        /// <param name="from">射线起点</param>
        /// <param name="to">近裁剪面四角坐标结构</param>
        /// <param name="hitInfo">输出最近碰撞信息</param>
        /// <param name="distance">最大检测距离</param>
        /// <param name="cullingLayer">裁剪检测层</param>
        /// <returns>是否发生碰撞</returns>
        private bool CullingRayCast(Vector3 from, ClipPlanePoints to, out RaycastHit hitInfo, float distance,
            LayerMask cullingLayer)
        {
            bool value = false;
            float minDist = float.MaxValue;
            hitInfo = default;

            // 左下角射线检测
            if (Physics.Raycast(from, to.LowerLeft - from, out var hit, distance, cullingLayer))
            {
                value = true;
                minDist = hit.distance;
                hitInfo = hit;
            }

            // 右下角射线检测
            if (Physics.Raycast(from, to.LowerRight - from, out hit, distance, cullingLayer))
            {
                value = true;
                if (minDist > hit.distance)
                {
                    minDist = hit.distance;
                    hitInfo = hit;
                }
            }

            // 左上角射线检测
            if (Physics.Raycast(from, to.UpperLeft - from, out hit, distance, cullingLayer))
            {
                value = true;
                if (minDist > hit.distance)
                {
                    minDist = hit.distance;
                    hitInfo = hit;
                }
            }

            // 右上角射线检测
            if (Physics.Raycast(from, to.UpperRight - from, out hit, distance, cullingLayer))
            {
                value = true;
                if (minDist > hit.distance)
                {
                    minDist = hit.distance;
                    hitInfo = hit;
                }
            }

            if (value)
                m_cullingDistance = minDist;

            return value;
        }

        /// <summary>
        /// 将角度限制在 [-360, 360] 范围内，再做 [min, max] 区间裁剪。
        /// </summary>
        /// <param name="angle">输入角度</param>
        /// <param name="min">最小限制</param>
        /// <param name="max">最大限制</param>
        /// <returns>限制后的角度</returns>
        private static float ClampAngle(float angle, float min, float max)
        {
            while (angle < -360f)
                angle += 360f;
            while (angle > 360f)
                angle -= 360f;

            return Mathf.Clamp(angle, min, max);
        }

        /// <summary>
        /// 计算相机近裁剪面在世界空间的四个角坐标。
        /// 基于 FOV、宽高比、近裁剪面距离推算四个顶点位置。
        /// </summary>
        /// <param name="camera">目标相机</param>
        /// <param name="pos">裁剪面中心位置</param>
        /// <returns>包含四个角坐标的结构体</returns>
        private static ClipPlanePoints NearClipPlanePoints(Camera camera, Vector3 pos)
        {
            var t = camera.transform;
            var halfFOV = (camera.fieldOfView * 0.5f) * Mathf.Deg2Rad;
            var distance = camera.nearClipPlane;
            // 根据半 FOV 和近裁剪面距离计算裁剪面半高/半宽（含边距）
            var height = distance * Mathf.Tan(halfFOV) * (1f + ClipPlaneMargin);
            var width = height * camera.aspect;

            // 预计算三个基向量，避免每个角重复乘法
            var right = t.right * width;
            var up = t.up * height;
            var fwd = t.forward * distance;

            return new ClipPlanePoints
            {
                LowerRight = pos + right - up + fwd,
                LowerLeft = pos - right - up + fwd,
                UpperRight = pos + right + up + fwd,
                UpperLeft = pos - right + up + fwd,
            };
        }

        /// <summary>
        /// 近裁剪面四个角的世界坐标结构体。
        /// </summary>
        private struct ClipPlanePoints
        {
            public Vector3 UpperLeft;
            public Vector3 UpperRight;
            public Vector3 LowerLeft;
            public Vector3 LowerRight;
        }

        // ── 公共接口 ──────────────────────────────────────────────

        /// <summary>
        /// 初始化相机：创建虚拟注视点并设置初始角度与距离。
        /// </summary>
        public void Init()
        {
            if (m_target == null)
                return;

            m_camera = GetComponent<Camera>();
            CurrentTarget = m_target;
            m_currentTargetPos = new Vector3(CurrentTarget.position.x, CurrentTarget.position.y + OffSetPlayerPivot,
                CurrentTarget.position.z);

            // 复用已有虚拟注视点，避免重复调用 Init 时 GameObject 泄漏
            if (m_targetLookAt == null)
            {
                m_targetLookAt = new GameObject("targetLookAt").transform;
                m_targetLookAt.hideFlags = HideFlags.HideInHierarchy;
            }

            m_targetLookAt.position = CurrentTarget.position;
            m_targetLookAt.rotation = CurrentTarget.rotation;

            // 初始化鼠标角度为目标朝向
            m_mouseY = CurrentTarget.eulerAngles.x;
            m_mouseX = CurrentTarget.eulerAngles.y;

            m_defaultDistance = Mathf.Clamp(m_defaultDistance, m_minDistance, m_maxDistance);
            m_distance = m_defaultDistance;
            m_currentHeight = m_height;
        }

        /// <summary>
        /// 设置相机注视目标（不会重新初始化）。
        /// </summary>
        /// <param name="newTarget">新的目标变换；为 null 则回退到默认目标</param>
        public void SetTarget(Transform newTarget)
        {
            CurrentTarget = newTarget ? newTarget : m_target;
        }

        /// <summary>
        /// 设置主目标并重新初始化相机。
        /// </summary>
        /// <param name="newTarget">新的主目标变换</param>
        public void SetMainTarget(Transform newTarget)
        {
            m_target = newTarget;
            CurrentTarget = newTarget;
            m_mouseY = CurrentTarget.rotation.eulerAngles.x;
            m_mouseX = CurrentTarget.rotation.eulerAngles.y;
            Init();
        }

        /// <summary>
        /// 将屏幕坐标点转换为世界空间射线。
        /// </summary>
        /// <param name="point">屏幕坐标点</param>
        /// <returns>从相机发出的射线</returns>
        public Ray ScreenPointToRay(Vector3 point)
        {
            return m_camera.ScreenPointToRay(point);
        }

        /// <summary>
        /// 根据鼠标输入旋转相机。
        /// 鼠标 X 控制水平旋转，Y 控制垂直俯仰；
        /// 非锁定模式下会限制角度范围。
        /// </summary>
        /// <param name="x">鼠标 X 轴增量</param>
        /// <param name="y">鼠标 Y 轴增量</param>
        public void RotateCamera(float x, float y)
        {
            // 累积鼠标输入并应用灵敏度
            m_mouseX += x * m_xMouseSensitivity;
            m_mouseY -= y * m_yMouseSensitivity;

            // 记录移动速度供外部使用
            MovementSpeed = new Vector2(x, -y);
            if (!m_lockOnRun)
            {
                // 非锁定模式：限制角度范围
                m_mouseY = ClampAngle(m_mouseY, m_yMinLimit, m_yMaxLimit);
                m_mouseX = ClampAngle(m_mouseX, XMinLimit, XMaxLimit);
            }
            else
            {
                // 锁定模式：角度与角色根节点朝向一致
                m_mouseY = CurrentTarget.root.localEulerAngles.x;
                m_mouseX = CurrentTarget.root.localEulerAngles.y;
            }
        }
    }
}
