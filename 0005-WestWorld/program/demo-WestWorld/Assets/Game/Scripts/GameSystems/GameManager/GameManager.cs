using UGU.Runtime;
using UnityEngine;

public static class GMState
{
    public const string Launch = "GMLaunch";
    public const string Global = "GMGlobal";
    public const string Game = "GMGame";
}

public class GameManager : UGUBaseGameSystem<GameManager>
{
    private UGUFSM m_fsm;
    private GameObject m_posGoldmine;
    private GameObject m_posBank;
    private GameObject m_posHome;
    private GameObject m_posSaloon;

    private GameObject m_roleMiner;
    private GameObject m_roleMinersWife;

    protected override void OnInitialize()
    {
        m_posGoldmine = GameObject.Find("PosGoldmine");
        m_posBank = GameObject.Find("PosBank");
        m_posHome = GameObject.Find("PosHome");
        m_posSaloon = GameObject.Find("PosSaloon");

        m_roleMiner = GameObject.Find("RoleMiner");
        m_roleMinersWife = GameObject.Find("RoleMinersWife");

        m_fsm = gameObject.AddComponent<UGUFSM>();

        m_fsm.Init();

        m_fsm.AddState(GMState.Launch, new GMLaunchState(m_fsm));
        m_fsm.AddState(GMState.Global, new GMGlobalState(m_fsm));
        m_fsm.AddState(GMState.Game, new GMGameState(m_fsm));

        m_fsm.SetGlobalState(GMState.Global);
        m_fsm.ChangeState(GMState.Launch);

        m_roleMiner.GetComponent<Miner>().Init();
    }

    public static Vector3 GetPosGoldmine()
    {
        return Instance.m_posGoldmine.transform.position;
    }

    public static Vector3 GetPosBank()
    {
        return Instance.m_posBank.transform.position;
    }
}