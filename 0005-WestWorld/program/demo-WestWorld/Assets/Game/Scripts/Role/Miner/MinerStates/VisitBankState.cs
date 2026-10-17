using UGU.Runtime;

public class VisitBankState : MinerBaseState
{
    public VisitBankState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerAniState.WalkForward);
        NMAgent.destination = GameManager.GetPosBank();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (GameUtils.IsNavMeshAgentArrived(NMAgent))
        {
            m_fsm.ChangeState(MinerState.DepositGold);
        }
    }

    public override void OnExit()
    {
    }
}