using UGU.Runtime;
using UnityEngine;

public class MWifeToCookingState : MWifeBaseState
{
    public MWifeToCookingState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerWAniState.WalkForward);
        NMAgent.destination = GameManager.GetPosHomeToPot();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (GameUtils.IsNavMeshAgentArrived(NMAgent))
        {
            // Debug.Log("11");
            m_fsm.ChangeState(MinerWState.Cooking);
        }
    }

    public override void OnExit()
    {
    }
}