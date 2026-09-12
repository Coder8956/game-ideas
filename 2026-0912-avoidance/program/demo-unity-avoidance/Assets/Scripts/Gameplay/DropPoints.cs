using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 掉落点控制器：
/// 1. 维护一个掉落表（Inspector可配置），启用后按表顺序逐个生成掉落物
/// 2. 掉落表每项可配置：掉落物预制体、掉落间隔（基于上一个掉落点分段计时）、出生位置Transform、Y轴负方向移动速度
/// 3. 生成的掉落物沿世界Y轴负方向匀速移动（类似掉落），世界Y坐标到达销毁Y值后自动销毁
/// 4. 掉落功能可由外部（如GameController）在游戏流程中启停：未启用时不生成也不驱动已生成掉落物；
///    禁用时销毁已生成的掉落物并停止掉落序列，再次启用后从头开始掉落
/// 5. 掉落表所有物体都完成（全部生成完毕且已全部销毁）后通知GameController结束游戏
/// </summary>
public class DropPoints : MonoBehaviour
{
    // ==================== 私有字段 ====================

    /// <summary>掉落表项配置（Inspector可配置；类为私有嵌套类，字段公开仅为便于DropPoints内部访问，不对外暴露）</summary>
    [Serializable]
    private class DropItemConfig
    {
        /// <summary>掉落物预制体</summary>
        public GameObject Prefab;

        /// <summary>掉落间隔（秒），基于上一个掉落点分段计时：首项从掉落启用时刻起算，其后各项从上一项生成时刻起算</summary>
        [Min(0f)] public float Interval = 1f;

        /// <summary>出生位置Transform，掉落物将在此Transform的世界位置与朝向生成</summary>
        public Transform SpawnTransform;

        /// <summary>Y轴负方向移动速度（单位/秒），类似掉落</summary>
        [Min(0f)] public float FallSpeed = 3f;
    }

    /// <summary>已生成的单个掉落物运行时数据</summary>
    private class ActiveDrop
    {
        /// <summary>掉落物Transform缓存</summary>
        public Transform Transform;

        /// <summary>该项掉落表配置的Y轴负方向移动速度</summary>
        public float FallSpeed;
    }

    /// <summary>掉落表（Inspector配置，按顺序依次生成）</summary>
    [SerializeField] private List<DropItemConfig> m_dropTable = new List<DropItemConfig>();

    /// <summary>销毁Y值：掉落物世界Y坐标到达该值后销毁</summary>
    [SerializeField] private float m_destroyY = -6f;

    /// <summary>掉落功能是否启用，未启用时不生成也不驱动已生成掉落物（由GameController在游戏流程中控制）</summary>
    private bool m_functionalityEnabled = true;

    /// <summary>掉落序列是否已开始（启用后开始，禁用时停止，保证再次启用后从头开始掉落）</summary>
    private bool m_started;

    /// <summary>掉落表中下一个待生成项的索引，达到掉落表项数表示已全部生成完毕</summary>
    private int m_nextIndex;

    /// <summary>距下一个掉落物生成的剩余间隔（秒），分段计时：每生成一项后重置为下一项配置的间隔</summary>
    private float m_intervalTimer;

    /// <summary>掉落表是否已全部完成（全部生成完毕且已全部销毁）</summary>
    private bool m_sequenceCompleted;

    /// <summary>已生成未销毁的掉落物列表</summary>
    private readonly List<ActiveDrop> m_activeDrops = new List<ActiveDrop>();

    /// <summary>GameController缓存，掉落表全部完成后通知其结束游戏</summary>
    private GameController m_gameController;

    // ==================== 生命周期 ====================

    void Awake()
    {
        // 缓存场景中的GameController（含未激活对象，与GameController收集口径一致），掉落表完成后通知其结束游戏
        GameController[] controllers = FindObjectsByType<GameController>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        m_gameController = controllers.Length > 0 ? controllers[0] : null;
        if (m_gameController == null)
        {
            Debug.LogWarning("[DropPoints] 场景中未找到GameController，掉落表完成后将无法通知游戏结束。", this);
        }
    }

    void Update()
    {
        // 功能未启用时不参与游戏逻辑（不生成掉落物、不驱动已生成掉落物下落）
        if (!m_functionalityEnabled)
            return;

        if (!m_started)
        {
            StartSequence();
        }

        UpdateSpawning();
        UpdateFalling();
        CheckCompletion();
    }

    // ==================== 掉落表生成 ====================

    /// <summary>
    /// 开始掉落序列：重置进度并从掉落表首项起算分段计时；
    /// 掉落表为空时仅告警（不生成任何物体，也不触发游戏结束，避免空表开局即结束）
    /// </summary>
    private void StartSequence()
    {
        m_started = true;
        m_nextIndex = 0;
        m_sequenceCompleted = false;

        if (m_dropTable.Count == 0)
        {
            Debug.LogWarning("[DropPoints] 掉落表为空，不会生成任何物体，也不会触发游戏结束。", this);
            return;
        }

        m_intervalTimer = Mathf.Max(0f, m_dropTable[0].Interval);
    }

    /// <summary>
    /// 掉落表分段计时：剩余间隔递减，归零后生成当前项，
    /// 下一项的间隔从本次生成时刻重新起算（掉落间隔基于上一个掉落点分段计时）
    /// </summary>
    private void UpdateSpawning()
    {
        if (m_nextIndex >= m_dropTable.Count)
            return;

        m_intervalTimer -= Time.deltaTime;
        if (m_intervalTimer > 0f)
            return;

        SpawnItem(m_nextIndex);
        m_nextIndex++;

        if (m_nextIndex < m_dropTable.Count)
        {
            m_intervalTimer = Mathf.Max(0f, m_dropTable[m_nextIndex].Interval);
        }
    }

    /// <summary>生成指定掉落表项：在出生位置实例化预制体并纳入下落驱动；预制体或出生位置未配置时跳过该项</summary>
    private void SpawnItem(int index)
    {
        DropItemConfig item = m_dropTable[index];

        if (item.Prefab == null)
        {
            Debug.LogWarning($"[DropPoints] 掉落表第{index + 1}项未配置预制体，跳过该项。", this);
            return;
        }

        if (item.SpawnTransform == null)
        {
            Debug.LogWarning($"[DropPoints] 掉落表第{index + 1}项未配置出生位置，跳过该项。", this);
            return;
        }

        GameObject instance = Instantiate(item.Prefab, item.SpawnTransform.position, item.SpawnTransform.rotation);
        m_activeDrops.Add(new ActiveDrop
        {
            Transform = instance.transform,
            FallSpeed = Mathf.Max(0f, item.FallSpeed),
        });

        Debug.Log($"[DropPoints] 生成掉落物：第{index + 1}/{m_dropTable.Count}项。", this);
    }

    // ==================== 下落与销毁 ====================

    /// <summary>
    /// 驱动所有已生成掉落物沿世界Y轴负方向匀速移动，世界Y坐标到达销毁Y值后销毁并移出列表；
    /// 掉落物被外部销毁时仅移出记录
    /// </summary>
    private void UpdateFalling()
    {
        for (int i = m_activeDrops.Count - 1; i >= 0; i--)
        {
            ActiveDrop drop = m_activeDrops[i];

            if (drop.Transform == null)
            {
                m_activeDrops.RemoveAt(i);
                continue;
            }

            drop.Transform.position += Vector3.down * (drop.FallSpeed * Time.deltaTime);

            if (drop.Transform.position.y <= m_destroyY)
            {
                Destroy(drop.Transform.gameObject);
                m_activeDrops.RemoveAt(i);
            }
        }
    }

    // ==================== 完成检测 ====================

    /// <summary>掉落表全部完成（全部生成完毕且已全部销毁）后通知GameController结束游戏；掉落表为空不触发</summary>
    private void CheckCompletion()
    {
        if (m_sequenceCompleted || m_dropTable.Count == 0)
            return;

        if (m_nextIndex < m_dropTable.Count || m_activeDrops.Count > 0)
            return;

        m_sequenceCompleted = true;
        Debug.Log("[DropPoints] 掉落表所有物体已完成。", this);

        if (m_gameController == null)
        {
            Debug.LogWarning("[DropPoints] 未找到GameController，无法通知游戏结束。", this);
            return;
        }

        m_gameController.EndGame();
    }

    // ==================== 公开接口 ====================

    /// <summary>获取销毁Y值（掉落物世界Y坐标到达该值后销毁）</summary>
    public float GetDestroyY() => m_destroyY;

    /// <summary>设置销毁Y值（掉落物世界Y坐标到达该值后销毁）</summary>
    public void SetDestroyY(float y) => m_destroyY = y;

    /// <summary>获取掉落表项数</summary>
    public int GetDropTableCount() => m_dropTable.Count;

    /// <summary>获取已处理的掉落表项数（含因配置缺失而跳过的项）</summary>
    public int GetProcessedCount() => m_nextIndex;

    /// <summary>获取当前已生成未销毁的掉落物数量</summary>
    public int GetActiveDropCount() => m_activeDrops.Count;

    /// <summary>获取距下一个掉落物生成的剩余间隔（秒）</summary>
    public float GetRemainingInterval() => Mathf.Max(0f, m_intervalTimer);

    /// <summary>掉落表是否已全部完成（全部生成完毕且已全部销毁）</summary>
    public bool IsCompleted() => m_sequenceCompleted;

    /// <summary>当前掉落功能是否启用</summary>
    public bool IsFunctionalityEnabled() => m_functionalityEnabled;

    /// <summary>
    /// 设置掉落功能是否启用（由GameController在游戏流程中控制）；
    /// 禁用时销毁已生成的掉落物并停止掉落序列（不残留上一轮的掉落物与待生成计时），
    /// 再次启用后从头开始掉落；启用时不重置，进行中的掉落不受影响
    /// </summary>
    public void SetFunctionalityEnabled(bool enabled)
    {
        m_functionalityEnabled = enabled;

        if (!enabled)
        {
            foreach (ActiveDrop drop in m_activeDrops)
            {
                if (drop.Transform != null)
                {
                    Destroy(drop.Transform.gameObject);
                }
            }

            m_activeDrops.Clear();
            m_started = false;
            m_intervalTimer = 0f;
        }
    }
}
