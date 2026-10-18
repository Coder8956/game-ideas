using UGU.Runtime;

public class MWifeGoBedState : MWifeBaseState
{
    public MWifeGoBedState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerWAniState.WalkForward);
        NMAgent.destination = GameManager.GetPosHomeBed();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (GameUtils.IsNavMeshAgentArrived(NMAgent))
        {
            m_fsm.ChangeState(MinerWState.MakeBed);
        }
    }

    public override void OnExit()
    {
    }
}