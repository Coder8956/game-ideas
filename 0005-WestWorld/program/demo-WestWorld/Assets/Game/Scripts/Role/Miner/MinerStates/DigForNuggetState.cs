using UGU.Runtime;
using UnityEngine.AI;

public class DigForNuggetState : MinerBaseState
{
    public DigForNuggetState(UGUFSM fsm) : base(fsm)
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
        if (m_stateDuration > 5)
        {
            m_fsm.ChangeState(MinerState.VisitBank);
        }
    }

    public override void OnExit()
    {
    }
}