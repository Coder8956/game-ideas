using UGU.Runtime;

public class IdleState : MinerBaseState
{
    public IdleState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerAniState.Idle);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (m_stateDuration > 5)
        {
            m_fsm.ChangeState(MinerState.EnterMineState);
        }
    }

    public override void OnExit()
    {
    }
}