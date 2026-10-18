using UGU.Runtime;

public class MWifeIdleState : MWifeBaseState
{
    public MWifeIdleState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerWAniState.Idle);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (m_stateDuration > 2)
        {
            m_fsm.ChangeState(MinerWState.GoHome);
        }
    }

    public override void OnExit()
    {
    }
}