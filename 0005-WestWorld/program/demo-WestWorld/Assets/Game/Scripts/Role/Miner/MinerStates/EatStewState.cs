using UGU.Runtime;

public class EatStewState : MinerBaseState
{
    public EatStewState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerAniState.Talk);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (m_stateDuration > 2)
        {
            GameManager.ShowDish(false);
            m_fsm.ChangeState(MinerState.EnterMineState);
        }
    }

    public override void OnExit()
    {
    }
}