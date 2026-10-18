using UGU.Runtime;

public class MWifeBackToiletPrePos : MWifeBaseState
{
    public MWifeBackToiletPrePos(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerWAniState.WalkForward);
        NMAgent.destination = MinersWife.PreToiletPos;
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (GameUtils.IsNavMeshAgentArrived(NMAgent))
        {
            m_fsm.ChangeState(MinersWife.PreToiletState);
        }
    }
}