using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent(SystemEvents.LifeCycleRoot)]
    [Tooltip("Sent when a direct or indirect parent of the transform of the GameObject has changed.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTransformParentChanged.html")]
    public class OnTransformParentChangedEvent : BaseSystemProxyEvent<OnTransformParentChangedEvent, OnTransformParentChangedProxyComponent>
    {
        public override bool HasData => false;
    }
    
    public class OnTransformParentChangedProxyComponent : BaseProxyEventComponent
    {
        public void OnTransformParentChanged() => SendEvent(OnTransformParentChangedEvent.Instance);
        
    }
}