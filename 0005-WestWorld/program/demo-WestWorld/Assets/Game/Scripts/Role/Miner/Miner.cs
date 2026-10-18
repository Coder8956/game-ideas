using UGU.Runtime;
using UMiniFramework.Runtime;
using UnityEngine;
using UnityEngine.UI;

public static class MinerState
{
    public const string Idle = "Miner=Idle";
    public const string EatStew = "Miner=EatStew";
    public const string GoHome = "Miner=GoHome";
    public const string SleepTilRested = "Miner=SleepTilRested";
    public const string DigForNuggetState = "Miner=DigForNuggetState";
    public const string EnterMineState = "Miner=EnterMineState";
    public const string QuenchThirst = "Miner=QuenchThirst";
    public const string VisitBank = "Miner=VisitBank";
    public const string EnterSaloon = "Miner=EnterSaloonState";
    public const string DepositGold = "Miner=DepositGold";
}

public static class MinerAniState
{
    public const string Idle = "Idle";
    public const string WalkForward = "WalkForward";
    public const string Talk = "Talk";
}

public class Miner : MonoBehaviour
{
    // ── 数值常量（设计阈值，与 design.md 一致）──────────────
    public const int MaxNuggets = 3; // 口袋金块上限：口袋满（≥3）就去银行存钱
    public const int ComfortLevel = 5; // 存款目标：达到即心满意足回家休息
    public const int ThirstLevel = 5; // 口渴阈值：Thirsty() 用 ≥ 判断
    public const int TirednessThreshold = 5; // 疲劳阈值：Fatigued() 用 > 判断

    // ── 私有字段（运行时数值，初始 0）────────────────────────
    private UGUFSM m_fsm;
    private int m_goldCarried; // 口袋金块数（原 m_iGoldCarried）
    private int m_moneyInBank; // 银行存款（原 m_iMoneyInBank）
    private int m_thirst; // 口渴值（原 m_iThirst）
    private int m_fatigue; // 疲劳度（原 m_iFatigue）

    // ── 属性（只读）──────────────────────────────────────────
    public int GoldCarried => m_goldCarried;
    public int Wealth => m_moneyInBank;
    public int Thirst => m_thirst;
    public int Fatigue => m_fatigue;

    private UMEventListener m_dishOKListener;

    public void Init()
    {
        m_fsm = gameObject.AddComponent<UGUFSM>();

        m_fsm.Init();

        m_fsm.AddState(MinerState.Idle, new IdleState(m_fsm));
        m_fsm.AddState(MinerState.EatStew, new EatStewState(m_fsm));
        m_fsm.AddState(MinerState.GoHome, new GoHomeState(m_fsm));
        m_fsm.AddState(MinerState.SleepTilRested, new SleepTilRestedState(m_fsm));
        m_fsm.AddState(MinerState.EnterMineState, new EnterMineState(m_fsm));
        m_fsm.AddState(MinerState.DigForNuggetState, new DigForNuggetState(m_fsm));
        m_fsm.AddState(MinerState.QuenchThirst, new QuenchThirstState(m_fsm));
        m_fsm.AddState(MinerState.VisitBank, new VisitBankState(m_fsm));
        m_fsm.AddState(MinerState.DepositGold, new DepositGoldState(m_fsm));
        m_fsm.AddState(MinerState.EnterSaloon, new EnterSaloonState(m_fsm));

        m_fsm.ChangeState(MinerState.Idle);

        m_dishOKListener = new UMEventListener(GMEvent.DishOKInHome, OnDishOK);
        UMOEvent.AddListener(m_dishOKListener);
        // m_fatigue = 4;
    }

    private void OnDishOK(UMEventContentBase content)
    {
        m_fsm.ChangeState(MinerState.EatStew);
    }

    private void Update()
    {
        UpdateUI();
    }

    // ── 公开接口（读写与阈值判断，增减均带防负保护）────────────

    /// <summary>增减口袋金块（挖矿 +1 / 存钱清零），不低于 0。</summary>
    public void AddToGoldCarried(int val)
    {
        m_goldCarried = Mathf.Max(0, m_goldCarried + val);
    }

    /// <summary>清空口袋金块</summary>
    public void ClearGoldCarried()
    {
        m_goldCarried = 0;
    }

    /// <summary>清空疲劳值</summary>
    public void ClearFatigue()
    {
        m_fatigue = 0;
    }

    /// <summary>口袋是否装满（金块数 ≥ MaxNuggets）。</summary>
    public bool PocketsFull()
    {
        return m_goldCarried >= MaxNuggets;
    }

    /// <summary>增减存款（买酒 -2 等），不低于 0。</summary>
    public void AddToWealth(int val)
    {
        m_moneyInBank = Mathf.Max(0, m_moneyInBank + val);
    }

    /// <summary>是否口渴（口渴值 ≥ ThirstLevel）。</summary>
    public bool Thirsty()
    {
        return m_thirst >= ThirstLevel;
    }

    /// <summary>口渴值 +1（设计为每帧 Update 调用）。</summary>
    public void IncreaseThirst()
    {
        m_thirst++;
    }

    /// <summary>买一杯威士忌：口渴清零、存款 -2。</summary>
    public void BuyAndDrinkAWhiskey()
    {
        m_thirst = 0;
        AddToWealth(-2);
    }

    /// <summary>是否疲劳（疲劳度 > TirednessThreshold）。</summary>
    public bool Fatigued()
    {
        return m_fatigue > TirednessThreshold;
    }

    /// <summary>疲劳度 +1（挖矿时调用）。</summary>
    public void IncreaseFatigue()
    {
        m_fatigue++;
    }

    /// <summary>疲劳度 -1（睡觉时调用），不低于 0。</summary>
    public void DecreaseFatigue()
    {
        m_fatigue = Mathf.Max(0, m_fatigue - 1);
    }

    private void UpdateUI()
    {
        GameObject.Find("Text-GoldCarried").GetComponent<Text>().text = $"口袋金块:{m_goldCarried}";
        GameObject.Find("Text-MoneyInBank").GetComponent<Text>().text = $"存款:{m_moneyInBank}";
        GameObject.Find("Text-Thirst").GetComponent<Text>().text = $"口渴:{m_thirst}";
        GameObject.Find("Text-Fatigue").GetComponent<Text>().text = $"疲劳:{m_fatigue}";
    }

    public void UpdateStateTip(string content)
    {
        GameObject.Find("Text-StateTip").GetComponent<Text>().text = $"矿工状态:{content}";
    }
}