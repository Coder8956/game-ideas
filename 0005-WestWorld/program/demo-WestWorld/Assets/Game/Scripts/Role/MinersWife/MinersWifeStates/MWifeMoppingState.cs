using UGU.Runtime;

public class MWifeMoppingState : MWifeBaseState
{
    public MWifeMoppingState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerWAniState.Talk);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (m_stateDuration > 3)
        {
            m_fsm.ChangeState(MinerWState.GoThinkJob);
        }
    }

    public override void OnExit()
    {
    }
}