using UGU.Runtime;
using UnityEngine;

public static class MinerWState
{
    public const string Idle = "MinerW=Idle";
    public const string GoHome = "MinerW=GoHome";
    public const string ThinkJob = "MinerW=ThinkJob";
}

public static class MinerWAniState
{
    public const string Idle = "Idle";
    public const string WalkForward = "WalkForward";
    public const string Talk = "Talk";
}

public class MinersWife : MonoBehaviour
{
    // ── 私有字段（运行时状态）────────────────────────────────
    private bool m_cooking; // 在做饭吗（原 m_bCooking），初始 false

    // ── 属性（只读）──────────────────────────────────────────
    public bool Cooking => m_cooking;

    private UGUFSM m_fsm;

    // ── 公开接口 ─────────────────────────────────────────────

    /// <summary>设置做饭开关（炖菜开始置 true、炖完置 false）。</summary>
    public void SetCooking(bool cooking)
    {
        m_cooking = cooking;
    }

    public void Init()
    {
        m_fsm = gameObject.AddComponent<UGUFSM>();
        
        m_fsm.Init();
        m_fsm.AddState(MinerWState.Idle, new MWifeIdleState(m_fsm));
        m_fsm.AddState(MinerWState.GoHome, new MWifeGoHomeState(m_fsm));
        m_fsm.AddState(MinerWState.ThinkJob, new MWifetThinkJobState(m_fsm));

        m_fsm.ChangeState(MinerWState.Idle);
    }

    public void UpdateStateTip(string content)
    {
    }
}