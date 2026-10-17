using UGU.Runtime;

public class DepositGoldState : MinerBaseState
{
    public DepositGoldState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerAniState.Talk);
    }

    public override void OnExit()
    {
    }
}