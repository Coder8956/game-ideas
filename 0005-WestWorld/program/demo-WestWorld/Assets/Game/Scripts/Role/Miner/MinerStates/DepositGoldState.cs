using UGU.Runtime;

public class DepositGoldState : MinerBaseState
{
    public DepositGoldState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerAniState.Talk);
        Miner.AddToWealth(Miner.GoldCarried);
        Miner.ClearGoldCarried();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (m_stateDuration > 2)
        {
            m_fsm.ChangeState(MinerState.EnterMineState);
        }
    }

    public override void OnExit()
    {
    }
}