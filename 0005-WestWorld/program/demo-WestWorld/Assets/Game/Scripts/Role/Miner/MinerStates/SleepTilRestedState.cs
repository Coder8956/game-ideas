using UGU.Runtime;

public class SleepTilRestedState : MinerBaseState
{
    public SleepTilRestedState(UGUFSM fsm) : base(fsm)
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
            Miner.ClearFatigue();
            m_fsm.ChangeState(MinerState.EnterMineState);
        }
    }

    public override void OnExit()
    {
    }
}