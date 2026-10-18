using UGU.Runtime;

public abstract class MWifeBaseState : RoleBaseState
{
    private MinersWife m_minerWife;
    public MinersWife MinersWife => m_minerWife;

    protected MWifeBaseState(UGUFSM fsm) : base(fsm)
    {
        m_minerWife = m_fsm.GetComponent<MinersWife>();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        m_minerWife.UpdateStateTip(GetType().Name);
    }
}