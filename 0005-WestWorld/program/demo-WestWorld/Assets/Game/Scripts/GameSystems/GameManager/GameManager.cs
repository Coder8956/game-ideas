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
    private GameObject m_posSaloon;
    private GameObject m_posHome;
    private GameObject m_posHomeW;
    private GameObject m_posHomeBed;
    private GameObject m_posHomeToilet;
    private GameObject m_posHomeDishwaster;
    private GameObject m_posHomePot;
    private GameObject m_posHomeMopping;

    private GameObject m_roleMiner;
    private GameObject m_roleMinersWife;

    protected override void OnInitialize()
    {
        m_posGoldmine = GameObject.Find("PosGoldmine");
        m_posBank = GameObject.Find("PosBank");
        m_posSaloon = GameObject.Find("PosSaloon");
        m_posHomeW = GameObject.Find("PosHomeW");
        m_posHome = GameObject.Find("PosHome");
        m_posHomeBed = GameObject.Find("PosHomeBed");
        m_posHomeToilet = GameObject.Find("PosHomeToilet");
        m_posHomeDishwaster = GameObject.Find("PosHomeDishwaster");
        m_posHomePot = GameObject.Find("PosHomePot");
        m_posHomeMopping = GameObject.Find("PosHomeMopping");

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
        m_roleMinersWife.GetComponent<MinersWife>().Init();
    }

    public static Vector3 GetPosGoldmine()
    {
        return Instance.m_posGoldmine.transform.position;
    }

    public static Vector3 GetPosBank()
    {
        return Instance.m_posBank.transform.position;
    }

    public static Vector3 GetPosHome()
    {
        return Instance.m_posHome.transform.position;
    }

    public static Vector3 GetPosHomeW()
    {
        return Instance.m_posHomeW.transform.position;
    }

    public static Vector3 GetPosSaloon()
    {
        return Instance.m_posSaloon.transform.position;
    }

    public static Vector3 GetPosHomeBed()
    {
        return Instance.m_posHomeBed.transform.position;
    }

    public static Vector3 GetPosHomeMopping()
    {
        return Instance.m_posHomeMopping.transform.position;
    }

    public static Vector3 GetPosHomeWashingDishes()
    {
        return Instance.m_posHomeDishwaster.transform.position;
    }
}