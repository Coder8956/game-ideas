using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [SystemEvent(SystemEvents.LifeCycleRoot)]
    [Tooltip("Sent to all GameObjects when the player gets focus.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnApplicationFocus.html")]
    public class OnApplicationFocusEvent : BaseSystemProxyEvent<OnApplicationFocusEvent, OnApplicationFocusProxyComponent>
    {
        public override bool HasData => false;
    }
    
    [Serializable]
    [SystemEvent(SystemEvents.LifeCycleRoot)]
    [Tooltip("Sent to all GameObjects when the player loses focus.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnApplicationFocus.html")]
    public class OnApplicationLostFocusEvent : BaseSystemProxyEvent<OnApplicationLostFocusEvent, OnApplicationFocusProxyComponent>
    {
        public override bool HasData => false;
    }
    
    public class OnApplicationFocusProxyComponent : BaseProxyEventComponent
    {
        public void OnApplicationFocus(bool hasFocus) => SendEvent(hasFocus 
                ? OnApplicationFocusEvent.Instance 
                : OnApplicationLostFocusEvent.Instance);
        
    }
}