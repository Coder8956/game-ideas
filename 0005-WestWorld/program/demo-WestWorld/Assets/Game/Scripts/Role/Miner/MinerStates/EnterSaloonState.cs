using UGU.Runtime;

public class EnterSaloonState : MinerBaseState
{
    public EnterSaloonState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerAniState.WalkForward);
        NMAgent.destination = GameManager.GetPosSaloon();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (GameUtils.IsNavMeshAgentArrived(NMAgent))
        {
            m_fsm.ChangeState(MinerState.QuenchThirst);
        }
    }
    
    public override void OnExit()
    {
    }
}