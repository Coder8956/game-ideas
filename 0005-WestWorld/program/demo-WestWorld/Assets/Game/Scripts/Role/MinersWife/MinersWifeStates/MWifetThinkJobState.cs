using UGU.Runtime;

public class MWifetThinkJobState : MWifeBaseState
{
    public MWifetThinkJobState(UGUFSM fsm) : base(fsm)
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