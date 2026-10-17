using UGU.Runtime;

public class GoHomeState : MinerBaseState
{
    public GoHomeState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerAniState.WalkForward);
        NMAgent.destination = GameManager.GetPosHome();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (GameUtils.IsNavMeshAgentArrived(NMAgent))
        {
            m_fsm.ChangeState(MinerState.SleepTilRested);
        }
    }

    public override void OnExit()
    {
    }
}