using System.Collections.Generic;
using UGU.Runtime;
using UnityEngine;

public class MWifeThinkJobState : MWifeBaseState
{
    private static Queue<WifeJob> m_toJobQue = new();

    public MWifeThinkJobState(UGUFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Ani.Play(MinerWAniState.Talk);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (m_stateDuration > 2)
        {
            m_fsm.ChangeState(ToJob());
        }
    }

    public override void OnExit()
    {
    }

    public string ToJob()
    {
        if (m_toJobQue.Count < 1)
        {
            List<WifeJob> jobs = new List<WifeJob>()
            {
                WifeJob.Mopping,
                WifeJob.MakeBed,
                WifeJob.WashingDishes
            };

            // Fisher–Yates 洗牌算法
            for (int i = jobs.Count - 1; i > 0; i--)
            {
                int randomIndex = Random.Range(0, i + 1);
                (jobs[i], jobs[randomIndex]) = (jobs[randomIndex], jobs[i]);
            }

            // 按洗牌后的顺序依次入队
            foreach (WifeJob job in jobs)
            {
                m_toJobQue.Enqueue(job);
            }
        }

        WifeJob toJob = m_toJobQue.Dequeue();
        // Debug.Log($"job:{toJob.ToString()}");

        string jobState = string.Empty;
        
        switch (toJob)
        {
            case WifeJob.MakeBed:
                jobState = MinerWState.GoBed;
                break;
            case WifeJob.Mopping:
                jobState = MinerWState.GoMopping;
                break;
            case WifeJob.WashingDishes:
                jobState = MinerWState.GoWashingDishes;
                break;
        }

        return jobState;
        // return MinerWState.GoWashingDishes;
    }
}