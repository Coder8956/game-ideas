using UGU.Runtime;
using UMiniFramework.Runtime;

public class GMLaunchState : UGUFSMStateBase
{
    public GMLaunchState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        UMLauncher.Work();

        UMOEvent.AddEvent(GMEvent.MinerInHome);
        UMOEvent.AddEvent(GMEvent.DishOKInHome);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (UMLauncher.IsWorked)
        {
            m_fsm.ChangeState(GMState.Game);
        }
    }

    public override void OnExit()
    {
    }
}