using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent(SystemEvents.ParticlesRoot)]
    [Tooltip("Sent when any particles in a Particle System meet the conditions in the trigger module.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnParticleTrigger.html")]
    public class OnParticleTriggerEvent : BaseSystemProxyEvent<OnParticleTriggerEvent, OnParticleTriggerProxyComponent>
    {
        public override bool HasData => false;
    }
    
    public class OnParticleTriggerProxyComponent : BaseProxyEventComponent
    {
        public void OnParticleTrigger() => SendEvent(OnParticleTriggerEvent.Instance);
    }
}