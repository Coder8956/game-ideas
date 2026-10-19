using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent(SystemEvents.LifeCycleRoot)]
    [Tooltip("Sent when the renderer became visible by any camera. " +
             "<br/>NOTE: This includes the scene view camera in the editor.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnBecameVisible.html")]
    public class OnBecameVisibleEvent : BaseSystemProxyEvent<OnBecameVisibleEvent, OnBecameVisibleProxyComponent>
    {
        public override bool HasData => false;
    }
    
    public class OnBecameVisibleProxyComponent : BaseProxyEventComponent
    {
        public void OnBecameVisible() => SendEvent(OnBecameVisibleEvent.Instance);
        
    }
}