using UGU.Runtime;

public class QuenchThirstState : MinerBaseState
{
    public QuenchThirstState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerAniState.Talk);
        Miner.BuyAndDrinkAWhiskey();
    }
    
    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (m_stateDuration > 2)
        {
            m_fsm.ChangeState(MinerState.EnterMineState);
        }
    }

    public override void OnExit()
    {
    }
}