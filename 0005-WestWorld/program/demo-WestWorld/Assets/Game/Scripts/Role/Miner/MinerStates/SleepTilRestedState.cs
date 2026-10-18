using UGU.Runtime;
using UMiniFramework.Runtime;

public class SleepTilRestedState : MinerBaseState
{
    public SleepTilRestedState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        Ani.Play(MinerAniState.Talk);
        UMOEvent.Dispatch(GMEvent.MinerInHome);
        Miner.ClearFatigue();
    }

    public override void OnExit()
    {
    }
}