using UGU.Runtime;

public class MWifeGoHomeState : MWifeBaseState
{
    public MWifeGoHomeState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerWAniState.WalkForward);
        NMAgent.destination = GameManager.GetPosHomeW();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (GameUtils.IsNavMeshAgentArrived(NMAgent))
        {
            m_fsm.ChangeState(MinerWState.ThinkJob);
        }
    }

    public override void OnExit()
    {
    }
}