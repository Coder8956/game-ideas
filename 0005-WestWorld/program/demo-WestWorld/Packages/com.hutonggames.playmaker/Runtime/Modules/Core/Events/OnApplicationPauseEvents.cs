using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [SystemEvent(SystemEvents.LifeCycleRoot)]
    [Tooltip("Sent to all GameObjects when the player pauses.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnApplicationPause.html")]
    public class OnApplicationPauseEvent : BaseSystemProxyEvent<OnApplicationPauseEvent, OnApplicationPauseProxyComponent>
    {
        public override bool HasData => false;
    }
    
    [Serializable]
    [SystemEvent(SystemEvents.LifeCycleRoot)]
    [Tooltip("Sent to all GameObjects when the player unpauses.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnApplicationPause.html")]
    public class OnApplicationUnPauseEvent : BaseSystemProxyEvent<OnApplicationUnPauseEvent, OnApplicationPauseProxyComponent>
    {
        public override bool HasData => false;
    }
    
    public class OnApplicationPauseProxyComponent : BaseProxyEventComponent
    {
        public void OnApplicationPause(bool isPaused) => SendEvent(isPaused 
                ? OnApplicationPauseEvent.Instance 
                : OnApplicationUnPauseEvent.Instance);
        
    }
}