using UGU.Runtime;
using UnityEngine;

public static class MinerState
{
    public const string Idle = "Miner=Idle";
    public const string EatStew = "Miner=EatStew";
    public const string GoHomeAndSleepTilRested = "Miner=GoHomeAndSleepTilRested";
    public const string DigForNuggetState = "Miner=DigForNuggetState";
    public const string EnterMineState = "Miner=EnterMineState";
    public const string QuenchThirst = "Miner=QuenchThirst";
    public const string VisitBank = "Miner=VisitBank";
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
    private UGUFSM m_fsm;

    public void Init()
    {
        m_fsm = gameObject.AddComponent<UGUFSM>();

        m_fsm.Init();

        m_fsm.AddState(MinerState.Idle, new IdleState(m_fsm));
        m_fsm.AddState(MinerState.EatStew, new EatStewState(m_fsm));
        m_fsm.AddState(MinerState.GoHomeAndSleepTilRested, new GoHomeAndSleepTilRested(m_fsm));
        m_fsm.AddState(MinerState.EnterMineState, new EnterMineState(m_fsm));
        m_fsm.AddState(MinerState.DigForNuggetState, new DigForNuggetState(m_fsm));
        m_fsm.AddState(MinerState.QuenchThirst, new QuenchThirst(m_fsm));
        m_fsm.AddState(MinerState.VisitBank, new VisitBankState(m_fsm));
        m_fsm.AddState(MinerState.DepositGold, new DepositGoldState(m_fsm));

        m_fsm.ChangeState(MinerState.Idle);
    }
}