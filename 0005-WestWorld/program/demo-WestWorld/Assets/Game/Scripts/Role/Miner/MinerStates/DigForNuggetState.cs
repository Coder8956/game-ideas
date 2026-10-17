using UGU.Runtime;

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
        if (Miner.PocketsFull())
        {
            m_fsm.ChangeState(MinerState.VisitBank);
        }
        else if (Miner.Fatigued())
        {
            m_fsm.ChangeState(MinerState.GoHome);
        }
        else if (Miner.Thirsty())
        {
            m_fsm.ChangeState(MinerState.EnterSaloon);
        }
    }

    protected override void DoPerSecond()
    {
        base.DoPerSecond();
        Miner.AddToGoldCarried(1);
        Miner.IncreaseThirst();
        Miner.IncreaseFatigue();
    }

    public override void OnExit()
    {
    }
}