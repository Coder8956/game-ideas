using UnityEngine;

public class MinersWife : MonoBehaviour
{
    // ── 私有字段（运行时状态）────────────────────────────────
    private bool m_cooking;   // 在做饭吗（原 m_bCooking），初始 false

    // ── 属性（只读）──────────────────────────────────────────
    public bool Cooking => m_cooking;

    // ── 公开接口 ─────────────────────────────────────────────

    /// <summary>设置做饭开关（炖菜开始置 true、炖完置 false）。</summary>
    public void SetCooking(bool cooking)
    {
        m_cooking = cooking;
    }
}
