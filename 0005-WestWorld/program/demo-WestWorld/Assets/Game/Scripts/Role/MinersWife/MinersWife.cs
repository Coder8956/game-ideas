using UGU.Runtime;
using UMiniFramework.Runtime;
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
    public const string Global = "MinerW=Global";
    public const string ToToilet = "MinerW=ToToilet";
    public const string BackToiletPre = "MinerW=BackToiletPre";
    public const string ToCooking = "MinerW=ToCooking";
    public const string Cooking = "MinerW=Cooking";
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


    private bool m_toToilet = false;
    public bool ToToilet => m_toToilet;

    private int m_toiletCD = 0;

    private const int ToiletTime = 30;

    private UGUFSM m_fsm;

    public Vector3 PreToiletPos;
    public string PreToiletState;

    public UMEventListener m_onMinerInHome;

    // ── 公开接口 ─────────────────────────────────────────────

    /// <summary>设置做饭开关（炖菜开始置 true、炖完置 false）。</summary>
    public void SetCooking(bool cooking)
    {
        m_cooking = cooking;
    }

    public void UpdateToiletCD()
    {
        if (m_cooking) return;
        if (m_toToilet) return;
        m_toiletCD++;
        if (m_toiletCD >= ToiletTime)
        {
            m_toToilet = true;
            PreToiletPos = transform.position;
            PreToiletState = m_fsm.CurrentStateName;
            m_fsm.ChangeState(MinerWState.ToToilet);
        }
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
        m_fsm.AddState(MinerWState.Global, new MWifeGlobalState(m_fsm));
        m_fsm.AddState(MinerWState.ToToilet, new MWifeToToiletState(m_fsm));
        m_fsm.AddState(MinerWState.BackToiletPre, new MWifeBackToiletPrePos(m_fsm));
        m_fsm.AddState(MinerWState.ToCooking, new MWifeToCookingState(m_fsm));
        m_fsm.AddState(MinerWState.Cooking, new MWifeCookingState(m_fsm));

        m_fsm.SetGlobalState(MinerWState.Global);
        m_fsm.ChangeState(MinerWState.Idle);
        m_onMinerInHome = new UMEventListener(GMEvent.MinerInHome, ToCooking);
        UMOEvent.AddListener(m_onMinerInHome);
    }

    public void UpdateStateTip(string content)
    {
        GameObject.Find("Text-StateTipW").GetComponent<Text>().text = $"妻子状态:{content}";
    }

    public void ToCooking(UMEventContentBase content)
    {
        SetCooking(true);
        if (m_toToilet) return;
        m_fsm.ChangeState(MinerWState.ToCooking);
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        GameObject.Find("Text-ToToiletW").GetComponent<Text>().text = $"去厕所CD:{m_toiletCD}/{ToiletTime}";
        GameObject.Find("Text-CookStateW").GetComponent<Text>().text = $"做饭:{m_cooking}";
        GameObject.Find("Text-ThirstW").GetComponent<Text>().text = $"";
        GameObject.Find("Text-FatigueW").GetComponent<Text>().text = $"";
    }

    public void ResetToilet()
    {
        m_toToilet = false;
        m_toiletCD = 0;
    }
}