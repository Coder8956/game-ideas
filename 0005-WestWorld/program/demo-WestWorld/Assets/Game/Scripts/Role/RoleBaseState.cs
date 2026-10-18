using UGU.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class RoleBaseState : UGUFSMStateBase
{
    protected float m_stateDuration;
    private NavMeshAgent m_navMeshAgent;
    private Animator m_animator;
    private float m_secondCD;
    
    public NavMeshAgent NMAgent => m_navMeshAgent;
    public Animator Ani => m_animator;
    protected RoleBaseState(UGUFSM fsm) : base(fsm)
    {
        m_navMeshAgent = m_fsm.GetComponent<NavMeshAgent>();
        m_animator = m_fsm.GetComponentInChildren<Animator>();
    }
    
    public override void OnEnter()
    {
        m_stateDuration = 0;
        m_secondCD = 0;
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        m_stateDuration += Time.deltaTime;
        m_secondCD += Time.deltaTime;
        if (m_secondCD > 1)
        {
            m_secondCD = 0;
            DoPerSecond();
        }
    }

    protected virtual void DoPerSecond()
    {
    }
}