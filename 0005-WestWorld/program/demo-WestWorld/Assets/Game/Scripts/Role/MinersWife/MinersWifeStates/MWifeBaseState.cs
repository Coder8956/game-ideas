using UGU.Runtime;
using UnityEngine;

public abstract class MWifeBaseState : RoleBaseState
{
    private MinersWife m_minerWife;
    public MinersWife MinersWife => m_minerWife;

    protected Vector3 m_posOnExit;

    protected MWifeBaseState(UGUFSM fsm) : base(fsm)
    {
        m_minerWife = m_fsm.GetComponent<MinersWife>();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        m_minerWife.UpdateStateTip(GetType().Name);
    }

    public override void OnExit()
    {
        base.OnExit();
        m_posOnExit = m_fsm.transform.position;
    }
}