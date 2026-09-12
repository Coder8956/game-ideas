using UnityEngine;

/// <summary>
/// 掉落物：由DropPoint生成后驱动自身坠落
/// 1. 挂载到DropPoint生成的预制体实例上，坠落速度与销毁高度由DropPoint在生成时配置（无需在Inspector中设置）
/// 2. 每帧按配置速度沿世界Y轴负方向匀速移动（类似坠落运动，非物理模拟，预制体无需自带刚体）
/// 3. 下坠到销毁高度（低于玩家与按键所在的场景区域）后自动销毁，防止物体无限下坠累积
/// </summary>
public class FallingObject : MonoBehaviour
{
    // ==================== 私有字段 ====================

    /// <summary>坠落速度（单位/秒），0表示尚未配置，生成后由DropPoint写入</summary>
    private float m_fallSpeed;

    /// <summary>销毁高度（世界坐标Y），低于该高度自动销毁</summary>
    private float m_destroyY;

    // ==================== 生命周期 ====================

    void Update()
    {
        // 沿Y轴负方向匀速下坠（与GamePlayer的匀速移动语义一致，不使用物理模拟）
        Vector3 position = transform.position;
        position.y -= m_fallSpeed * Time.deltaTime;
        transform.position = position;

        // 低于销毁高度自动销毁，物体已坠出游戏区域，避免无限累积
        if (position.y <= m_destroyY)
        {
            Destroy(gameObject);
        }
    }

    // ==================== 公开接口 ====================

    /// <summary>获取坠落速度（单位/秒）</summary>
    public float GetFallSpeed() => m_fallSpeed;

    /// <summary>设置坠落速度（单位/秒），负值按0处理</summary>
    public void SetFallSpeed(float speed) => m_fallSpeed = Mathf.Max(0f, speed);

    /// <summary>获取销毁高度（世界坐标Y）</summary>
    public float GetDestroyY() => m_destroyY;

    /// <summary>设置销毁高度（世界坐标Y），低于该高度自动销毁</summary>
    public void SetDestroyY(float destroyY) => m_destroyY = destroyY;
}
