using UGU.Runtime;

public abstract class MinerBaseState : RoleBaseState
{
    private Miner m_miner;
    public Miner Miner => m_miner;

    protected MinerBaseState(UGUFSM fsm) : base(fsm)
    {
        m_miner = m_fsm.GetComponent<Miner>();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        m_miner.UpdateStateTip(GetType().Name);
    }
}