using UGU.Runtime;
using UnityEngine;

public class MWifeGlobalState : MWifeBaseState
{
    public MWifeGlobalState(UGUFSM fsm) : base(fsm)
    {
    }

    protected override void DoPerSecond()
    {
        base.DoPerSecond();
        MinersWife.UpdateToiletCD();
    }

    public override void OnExit()
    {
    }
}