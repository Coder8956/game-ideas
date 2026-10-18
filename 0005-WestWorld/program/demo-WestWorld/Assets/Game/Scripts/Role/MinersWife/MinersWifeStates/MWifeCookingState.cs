using UGU.Runtime;
using UMiniFramework.Runtime;

public class MWifeCookingState : MWifeBaseState
{
    public MWifeCookingState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerWAniState.Talk);
        GameManager.ShowDish(true);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (m_stateDuration > 3)
        {
            MinersWife.SetCooking(false);
            m_fsm.ChangeState(MinerWState.GoThinkJob);
            UMOEvent.Dispatch(GMEvent.DishOKInHome);
        }
    }

    public override void OnExit()
    {
    }
}