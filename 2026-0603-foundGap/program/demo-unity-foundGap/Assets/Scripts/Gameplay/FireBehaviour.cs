using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 武器发射行为
/// 按下配置按键（默认鼠标左键）发射武器：
/// 1. 武器预制体可在 Inspector 配置
/// 2. 发射方向为相机 Z 轴正方向（相机正前方）
/// 3. 武器出生点可配置：距目标的固定距离（沿目标→相机方向）；
///    目标未设置时回退为沿相机 Z 方向的偏移（相对于相机位置）
/// 4. 发射后武器沿发射方向（自身 Z 轴正方向）以可配置速度匀速飞行
/// 5. 目标与停止距离可配置：武器距目标到达停止距离时停止运动，
///    并成为目标的子物体（保持世界位置与朝向，随目标移动）；目标未设置时武器不停止
/// 6. 开火间隔可配置：两次发射之间的最小间隔（秒），间隔未到时按下发射键不发射
/// </summary>
public class FireBehaviour : MonoBehaviour
{
    // ==================== Inspector 字段 ====================

    [Header("武器设置")]

    [Tooltip("武器预制体；未设置时按下发射键只警告一次并忽略发射")]
    [SerializeField] private GameObject m_weaponPrefab;

    [Tooltip("发射参考相机；未设置时回退使用 Camera.main")]
    [SerializeField] private Camera m_camera;

    [Header("发射设置")]

    [Tooltip("武器沿发射方向的飞行速度（米/秒）")]
    [SerializeField] private float m_speed = 20f;

    [Tooltip("开火间隔（秒）：两次发射之间的最小间隔，0 = 无间隔限制")]
    [SerializeField] private float m_fireInterval = 0.5f;

    [Tooltip("发射按键，默认：鼠标左键")]
    [SerializeField] private InputActionProperty m_fireAction = new InputActionProperty(
        new InputAction("Fire", InputActionType.Button, "<Mouse>/leftButton"));

    [Header("目标设置")]

    [Tooltip("命中目标：武器距目标到达停止距离时停止运动，并成为该目标的子物体；未设置时武器不停止")]
    [SerializeField] private Transform m_target;

    [Tooltip("武器出生点：距目标的距离（米），沿目标→相机方向（生成在相机与目标之间）；目标未设置时回退为沿相机 Z 方向的偏移（距相机）")]
    [SerializeField] private float m_spawnDistanceFromTarget = 1.5f;

    [Tooltip("武器停止运动时距目标的距离（米），0 = 停在目标位置")]
    [SerializeField] private float m_stopDistance = 0.5f;

    // ==================== 私有字段 ====================

    /// <summary>已发射的武器列表（Update 中驱动其飞行）</summary>
    private readonly List<GameObject> m_flyingWeapons = new List<GameObject>();

    /// <summary>开火间隔剩余时间（秒），为 0 时可再次发射</summary>
    private float m_fireCooldownTimer;

    /// <summary>m_weaponPrefab 未赋值的警告是否已输出过（避免每次发射刷屏）</summary>
    private bool m_weaponPrefabMissingWarned;

    /// <summary>发射相机（含 Camera.main 回退）均缺失的警告是否已输出过（避免每次发射刷屏）</summary>
    private bool m_cameraMissingWarned;

    // ==================== 生命周期 ====================

    void OnEnable()
    {
        EnableAction(m_fireAction);
    }

    void OnDisable()
    {
        DisableAction(m_fireAction);
    }

    void Update()
    {
        // 开火间隔计时递减，归零后可再次发射
        if (m_fireCooldownTimer > 0f)
        {
            m_fireCooldownTimer -= Time.deltaTime;
        }

        // 按下发射键：发射一枚武器（Fire 内部处理开火间隔）
        if (WasActionPressedThisFrame(m_fireAction))
        {
            Fire();
        }

        AdvanceFlight();
    }

    // ==================== 逻辑 ====================

    /// <summary>
    /// 发射一枚武器（便于 UI、测试等外部调用）：
    /// 1. 开火间隔未到时忽略本次发射，发射成功后进入间隔计时
    /// 2. 出生点 = 目标位置沿目标→相机方向偏移 m_spawnDistanceFromTarget（与相机距离无关）；
    ///    目标未设置时回退为相机位置沿相机 Z 方向偏移 m_spawnDistanceFromTarget
    /// 3. 武器朝向 = 相机朝向（武器自身 Z 轴正方向即发射方向）
    /// 4. 加入飞行列表，由每帧 AdvanceFlight 推进：沿 Z 轴正方向匀速飞行，到达目标停止距离时停止并挂到目标下；
    /// 相机或武器预制体缺失时只警告一次并忽略本次发射（不消耗开火间隔）。
    /// </summary>
    public void Fire()
    {
        // 开火间隔未到：忽略本次发射
        if (m_fireCooldownTimer > 0f)
        {
            return;
        }

        Camera fireCamera = GetFireCamera();
        if (fireCamera == null)
        {
            return;
        }

        if (m_weaponPrefab == null)
        {
            if (!m_weaponPrefabMissingWarned)
            {
                m_weaponPrefabMissingWarned = true;
                Debug.LogWarning("[FireBehaviour] 未设置武器预制体（m_weaponPrefab），发射已被忽略。", this);
            }
            return;
        }

        Transform cameraTransform = fireCamera.transform;

        Vector3 spawnPosition;
        if (m_target != null)
        {
            // 出生点固定在距目标 m_spawnDistanceFromTarget 处（沿目标→相机方向，始终生成在相机与目标之间）
            Vector3 toCamera = cameraTransform.position - m_target.position;
            spawnPosition = m_target.position + toCamera.normalized * m_spawnDistanceFromTarget;
        }
        else
        {
            // 目标未设置：回退为沿相机 Z 方向的偏移
            spawnPosition = cameraTransform.position + cameraTransform.forward * m_spawnDistanceFromTarget;
        }

        GameObject weapon = Instantiate(m_weaponPrefab, spawnPosition, cameraTransform.rotation);
        m_flyingWeapons.Add(weapon);

        // 发射成功：重置开火间隔计时
        m_fireCooldownTimer = m_fireInterval;
    }

    /// <summary>
    /// 推进所有已发射武器的飞行：沿各自 Z 轴正方向匀速移动，
    /// 到达目标停止距离时停在命中点并成为目标的子物体；同时清理已销毁的武器。
    /// </summary>
    private void AdvanceFlight()
    {
        for (int i = m_flyingWeapons.Count - 1; i >= 0; i--)
        {
            GameObject weapon = m_flyingWeapons[i];
            if (weapon == null)
            {
                // 武器已被销毁：移除引用，避免残留无效项
                m_flyingWeapons.RemoveAt(i);
                continue;
            }

            Vector3 from = weapon.transform.position;
            Vector3 to = from + weapon.transform.forward * (m_speed * Time.deltaTime);

            if (m_target != null && TryGetStopPoint(from, to, out Vector3 stopPoint))
            {
                // 到达停止距离：停在命中点并成为目标的子物体（保持世界位置与朝向，随目标移动）
                weapon.transform.position = stopPoint;
                weapon.transform.SetParent(m_target, true);
                m_flyingWeapons.RemoveAt(i);
                continue;
            }

            weapon.transform.position = to;
        }
    }

    /// <summary>
    /// 判定本步移动是否到达距目标的停止距离，并求出停止点：
    /// 取移动线段上距目标最近的点做连续判定，高速或帧率骤降导致单步跨过目标时也不会漏检；
    /// 未到达时返回 false，武器继续飞行。
    /// </summary>
    private bool TryGetStopPoint(Vector3 from, Vector3 to, out Vector3 stopPoint)
    {
        Vector3 targetPosition = m_target.position;
        Vector3 segment = to - from;

        if (segment.sqrMagnitude < 0.0000001f)
        {
            // 步长近乎为零：按当前位置判定
            stopPoint = from;
            return Vector3.Distance(from, targetPosition) <= m_stopDistance;
        }

        float t = Mathf.Clamp01(Vector3.Dot(targetPosition - from, segment) / segment.sqrMagnitude);
        stopPoint = from + segment * t;
        return Vector3.Distance(stopPoint, targetPosition) <= m_stopDistance;
    }

    /// <summary>获取发射参考相机：优先用 Inspector 配置的相机，未配置时回退 Camera.main（均缺失时只警告一次）</summary>
    private Camera GetFireCamera()
    {
        if (m_camera != null)
        {
            return m_camera;
        }

        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            return mainCamera;
        }

        if (!m_cameraMissingWarned)
        {
            m_cameraMissingWarned = true;
            Debug.LogWarning("[FireBehaviour] 未配置发射相机（m_camera）且找不到 Camera.main，发射已被忽略。", this);
        }
        return null;
    }

    // ==================== 输入 ====================

    /// <summary>启用输入动作</summary>
    private static void EnableAction(InputActionProperty property)
    {
        if (property.action != null)
        {
            property.action.Enable();
        }
    }

    /// <summary>禁用输入动作</summary>
    private static void DisableAction(InputActionProperty property)
    {
        if (property.action != null)
        {
            property.action.Disable();
        }
    }

    /// <summary>动作对应按键是否在本帧被按下</summary>
    private static bool WasActionPressedThisFrame(InputActionProperty property)
    {
        return property.action != null && property.action.WasPressedThisFrame();
    }

    // ==================== 公开接口 ====================

    /// <summary>获取武器预制体</summary>
    public GameObject GetWeaponPrefab() => m_weaponPrefab;

    /// <summary>设置武器预制体</summary>
    public void SetWeaponPrefab(GameObject prefab) => m_weaponPrefab = prefab;

    /// <summary>获取发射参考相机</summary>
    public Camera GetCamera() => m_camera;

    /// <summary>设置发射参考相机</summary>
    public void SetCamera(Camera camera) => m_camera = camera;

    /// <summary>获取武器飞行速度（米/秒）</summary>
    public float GetSpeed() => m_speed;

    /// <summary>设置武器飞行速度（米/秒）</summary>
    public void SetSpeed(float speed) => m_speed = speed;

    /// <summary>获取开火间隔（秒）</summary>
    public float GetFireInterval() => m_fireInterval;

    /// <summary>设置开火间隔（秒）</summary>
    public void SetFireInterval(float interval) => m_fireInterval = interval;

    /// <summary>是否处于开火间隔中（当前无法发射）</summary>
    public bool IsInCooldown() => m_fireCooldownTimer > 0f;

    /// <summary>获取开火间隔剩余时间（秒）</summary>
    public float GetRemainingCooldown() => Mathf.Max(0f, m_fireCooldownTimer);

    /// <summary>获取命中目标</summary>
    public Transform GetTarget() => m_target;

    /// <summary>设置命中目标</summary>
    public void SetTarget(Transform target) => m_target = target;

    /// <summary>获取武器出生点距目标的距离（米）</summary>
    public float GetSpawnDistanceFromTarget() => m_spawnDistanceFromTarget;

    /// <summary>设置武器出生点距目标的距离（米）</summary>
    public void SetSpawnDistanceFromTarget(float distance) => m_spawnDistanceFromTarget = distance;

    /// <summary>获取停止运动时距目标的距离（米）</summary>
    public float GetStopDistance() => m_stopDistance;

    /// <summary>设置停止运动时距目标的距离（米）</summary>
    public void SetStopDistance(float distance) => m_stopDistance = distance;
}
