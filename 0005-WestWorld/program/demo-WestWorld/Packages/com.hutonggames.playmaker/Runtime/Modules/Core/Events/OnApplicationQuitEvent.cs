using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent(SystemEvents.LifeCycleRoot)]
    [Tooltip("Sent to all GameObjects before the application quits.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnApplicationQuit.html")]
    public class OnApplicationQuitEvent : BaseSystemProxyEvent<OnApplicationQuitEvent, OnApplicationQuitProxyComponent>
    {
        public override bool HasData => false;
    }
    
    public class OnApplicationQuitProxyComponent : BaseProxyEventComponent
    {
        public void OnApplicationQuit() => SendEvent(OnApplicationQuitEvent.Instance);
        
    }
}