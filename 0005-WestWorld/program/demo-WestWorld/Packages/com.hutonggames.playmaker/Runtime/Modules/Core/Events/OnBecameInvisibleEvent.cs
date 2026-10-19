using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent(SystemEvents.LifeCycleRoot)]
    [Tooltip("Sent when the renderer is no longer visible by any camera. " +
             "<br/>NOTE: This includes the scene view camera in the editor.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnBecameInvisible.html")]
    public class OnBecameInvisibleEvent : BaseSystemProxyEvent<OnBecameInvisibleEvent, OnBecameInvisibleProxyComponent>
    {
        public override bool HasData => false;
    }
    
    public class OnBecameInvisibleProxyComponent : BaseProxyEventComponent
    {
        public void OnBecameInvisible() => SendEvent(OnBecameInvisibleEvent.Instance);
        
    }
}
