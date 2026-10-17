using UGU.Runtime;
using UnityEngine;
using UnityEngine.AI;

public abstract class MinerBaseState : UGUFSMStateBase
{
    protected float m_stateDuration;
    private NavMeshAgent m_navMeshAgent;
    private Animator m_animator;

    public NavMeshAgent NMAgent => m_navMeshAgent;
    public Animator Ani => m_animator;

    protected MinerBaseState(UGUFSM fsm) : base(fsm)
    {
        m_navMeshAgent = m_fsm.GetComponent<NavMeshAgent>();
        m_animator = m_fsm.GetComponentInChildren<Animator>();
    }

    public override void OnEnter()
    {
        m_stateDuration = 0;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        m_stateDuration += Time.deltaTime;
    }
}