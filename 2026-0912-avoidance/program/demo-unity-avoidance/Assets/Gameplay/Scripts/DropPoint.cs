using UnityEngine;

/// <summary>
/// 掉落点：在自身位置生成Inspector中配置的预制体并驱动其坠落
/// 1. 在Inspector中配置要生成的预制体、坠落速度与下坠深度
/// 2. Spawn()由GameController在游戏流程中按随机顺序调用：在掉落点位置实例化预制体，
///    并挂载FallingObject组件驱动其沿Y轴负方向以配置速度坠落（预制体无需自带脚本或刚体）
/// 3. 生成物坠到生成位置下方"下坠深度"处自动销毁（略低于玩家与按键所在区域），防止无限累积
/// 4. 未配置预制体时调用Spawn()仅告警并跳过本次生成，不阻断游戏流程
/// </summary>
public class DropPoint : MonoBehaviour
{
    // ==================== 私有字段 ====================

    /// <summary>要生成的预制体</summary>
    [SerializeField] private GameObject m_prefab;

    /// <summary>坠落速度（单位/秒），生成物沿Y轴负方向匀速下坠</summary>
    [SerializeField, Min(0f)] private float m_fallSpeed = 5f;

    /// <summary>下坠深度：生成位置下方多少距离（世界坐标）时生成物自动销毁</summary>
    [SerializeField, Min(1f)] private float m_fallDepth = 10f;

    // ==================== 生成逻辑 ====================

    /// <summary>
    /// 在掉落点位置生成配置的预制体并驱动其坠落：
    /// 实例化预制体后挂载FallingObject并写入坠落速度与销毁高度；
    /// 未配置预制体时仅告警并返回null，不阻断游戏流程
    /// </summary>
    public GameObject Spawn()
    {
        if (m_prefab == null)
        {
            Debug.LogWarning($"[DropPoint] {name} 未配置要生成的预制体，本次跳过生成。", this);
            return null;
        }

        // 在掉落点位置实例化预制体（世界位置对齐掉落点，旋转取无旋转保证生成姿态稳定）
        GameObject instance = Instantiate(m_prefab, transform.position, Quaternion.identity);

        // 预制体可能自带FallingObject，无则挂载，统一由本方法配置坠落参数
        if (!instance.TryGetComponent<FallingObject>(out FallingObject fallingObject))
        {
            fallingObject = instance.AddComponent<FallingObject>();
        }
        fallingObject.SetFallSpeed(m_fallSpeed);
        fallingObject.SetDestroyY(transform.position.y - m_fallDepth);

        return instance;
    }

    // ==================== 公开接口 ====================

    /// <summary>获取配置的生成预制体</summary>
    public GameObject GetPrefab() => m_prefab;

    /// <summary>设置生成预制体</summary>
    public void SetPrefab(GameObject prefab) => m_prefab = prefab;

    /// <summary>获取坠落速度（单位/秒）</summary>
    public float GetFallSpeed() => m_fallSpeed;

    /// <summary>设置坠落速度（单位/秒），负值按0处理</summary>
    public void SetFallSpeed(float speed) => m_fallSpeed = Mathf.Max(0f, speed);

    /// <summary>获取下坠深度（生成位置下方的自动销毁距离）</summary>
    public float GetFallDepth() => m_fallDepth;

    /// <summary>设置下坠深度（生成位置下方的自动销毁距离），小于1按1处理</summary>
    public void SetFallDepth(float depth) => m_fallDepth = Mathf.Max(1f, depth);
}
