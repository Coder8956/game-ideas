using UGU.Runtime;

public class MWifeGoMoppingState : MWifeBaseState
{
    public MWifeGoMoppingState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerWAniState.WalkForward);
        NMAgent.destination = GameManager.GetPosHomeMopping();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (GameUtils.IsNavMeshAgentArrived(NMAgent))
        {
            m_fsm.ChangeState(MinerWState.Mopping);
        }
    }

    public override void OnExit()
    {
    }
}