using UGU.Runtime;
using UnityEngine;
using UnityEngine.AI;

public abstract class MinerBaseState : UGUFSMStateBase
{
    protected float m_stateDuration;
    private NavMeshAgent m_navMeshAgent;
    private Animator m_animator;
    private float m_secondCD;
    private Miner m_miner;

    public NavMeshAgent NMAgent => m_navMeshAgent;
    public Animator Ani => m_animator;
    public Miner Miner => m_miner;


    protected MinerBaseState(UGUFSM fsm) : base(fsm)
    {
        m_navMeshAgent = m_fsm.GetComponent<NavMeshAgent>();
        m_animator = m_fsm.GetComponentInChildren<Animator>();
        m_miner = m_fsm.GetComponent<Miner>();
    }

    public override void OnEnter()
    {
        m_miner.UpdateStateTip(GetType().Name);

        m_stateDuration = 0;
        m_secondCD = 0;
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