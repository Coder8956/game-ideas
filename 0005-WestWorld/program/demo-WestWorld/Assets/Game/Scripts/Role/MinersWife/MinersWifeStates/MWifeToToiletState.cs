using UGU.Runtime;

public class MWifeToToiletState : MWifeBaseState
{
    private bool m_arrived = false;
    private int m_toiletTimer = 0;

    public MWifeToToiletState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        m_arrived = false;
        m_toiletTimer = 0;
        Ani.Play(MinerWAniState.WalkForward);
        NMAgent.destination = GameManager.GetPosHomeToilet();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (GameUtils.IsNavMeshAgentArrived(NMAgent) && !m_arrived)
        {
            m_arrived = true;
            Ani.Play(MinerWAniState.Talk);
        }
    }

    protected override void DoPerSecond()
    {
        base.DoPerSecond();
        if (!m_arrived) return;
        m_toiletTimer++;
        if (m_toiletTimer > 5)
        {
            m_fsm.RevertToPreviousState();
            MinersWife.ResetToilet();
        }
    }

    public override void OnExit()
    {
    }
}