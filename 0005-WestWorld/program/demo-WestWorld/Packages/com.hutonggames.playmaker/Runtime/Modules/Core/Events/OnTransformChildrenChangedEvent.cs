using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent(SystemEvents.LifeCycleRoot)]
    [Tooltip("Sent when the list of children of the transform of the GameObject has changed.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTransformChildrenChanged.html")]
    public class OnTransformChildrenChangedEvent : BaseSystemProxyEvent<OnTransformChildrenChangedEvent, OnTransformChildrenChangedProxyComponent>
    {
        public override bool HasData => false;
    }
    
    public class OnTransformChildrenChangedProxyComponent : BaseProxyEventComponent
    {
        public void OnTransformChildrenChanged() => SendEvent(OnTransformChildrenChangedEvent.Instance);
        
    }
}