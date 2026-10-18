using UGU.Runtime;
using UnityEngine;
using UnityEngine.UI;

public static class MinerWState
{
    public const string Idle = "MinerW=Idle";
    public const string GoHome = "MinerW=GoHome";
    public const string GoThinkJob = "MinerW=GoThinkJob";
    public const string ThinkJob = "MinerW=ThinkJob";
    public const string GoBed = "MinerW=GoBed";
    public const string MakeBed = "MinerW=MakeBed";
    public const string GoMopping = "MinerW=GoMopping";
    public const string Mopping = "MinerW=Mopping";
    public const string GoWashingDishes = "MinerW=GoWashingDishes";
    public const string WashingDishes = "MinerW=WashingDishes";
}

public static class MinerWAniState
{
    public const string Idle = "Idle";
    public const string WalkForward = "WalkForward";
    public const string Talk = "Talk";
}

public enum WifeJob
{
    MakeBed = 0,
    WashingDishes = 1,
    Mopping = 2
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
        m_fsm.AddState(MinerWState.GoThinkJob, new MWifeGoThinkJobState(m_fsm));
        m_fsm.AddState(MinerWState.ThinkJob, new MWifeThinkJobState(m_fsm));
        m_fsm.AddState(MinerWState.GoBed, new MWifeGoBedState(m_fsm));
        m_fsm.AddState(MinerWState.MakeBed, new MWifeMakeBedState(m_fsm));
        m_fsm.AddState(MinerWState.GoMopping, new MWifeGoMoppingState(m_fsm));
        m_fsm.AddState(MinerWState.Mopping, new MWifeMoppingState(m_fsm));
        m_fsm.AddState(MinerWState.GoWashingDishes, new MWifeGoWashingDishesState(m_fsm));
        m_fsm.AddState(MinerWState.WashingDishes, new MWifeWashingDishesState(m_fsm));

        m_fsm.ChangeState(MinerWState.Idle);
    }

    public void UpdateStateTip(string content)
    {
        GameObject.Find("Text-StateTipW").GetComponent<Text>().text = $"妻子状态:{content}";
    }

    private void UpdateUI()
    {
        // GameObject.Find("Text-GoldCarried").GetComponent<Text>().text = $"口袋金块:{m_goldCarried}";
        // GameObject.Find("Text-MoneyInBank").GetComponent<Text>().text = $"存款:{m_moneyInBank}";
        // GameObject.Find("Text-Thirst").GetComponent<Text>().text = $"口渴:{m_thirst}";
        // GameObject.Find("Text-Fatigue").GetComponent<Text>().text = $"疲劳:{m_fatigue}";
    }
}