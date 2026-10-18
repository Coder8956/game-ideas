using UGU.Runtime;

public class MWifeCookingState : MWifeBaseState
{
    public MWifeCookingState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerWAniState.Talk);
    }

    public override void OnExit()
    {
    }
}