using UGU.Runtime;

public class EnterMineState : MinerBaseState
{
    public EnterMineState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerAniState.WalkForward);
        NMAgent.destination = GameManager.GetPosGoldmine();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (GameUtils.IsNavMeshAgentArrived(NMAgent))
        {
            m_fsm.ChangeState(MinerState.DigForNuggetState);
        }
    }

    public override void OnExit()
    {
    }
}