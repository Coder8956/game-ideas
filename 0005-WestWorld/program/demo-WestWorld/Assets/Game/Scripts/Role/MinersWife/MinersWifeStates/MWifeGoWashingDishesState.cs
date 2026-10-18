using UGU.Runtime;

public class MWifeGoWashingDishesState : MWifeBaseState
{
    public MWifeGoWashingDishesState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerWAniState.WalkForward);
        NMAgent.destination = GameManager.GetPosHomeWashingDishes();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (GameUtils.IsNavMeshAgentArrived(NMAgent))
        {
            m_fsm.ChangeState(MinerWState.WashingDishes);
        }
    }

    public override void OnExit()
    {
    }
}