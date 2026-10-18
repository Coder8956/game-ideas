using UGU.Runtime;

public class MWifeGoThinkJobState : MWifeBaseState
{
    public MWifeGoThinkJobState(UGUFSM fsm) : base(fsm)
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