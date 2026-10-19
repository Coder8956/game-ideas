using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent(SystemEvents.ParticlesRoot)]
    [Tooltip("Sent when all particles in the system have died, and no new particles will be born.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnParticleSystemStopped.html")]
    public class OnParticleSystemStoppedEvent : BaseSystemProxyEvent<OnParticleSystemStoppedEvent, OnParticleSystemStoppedProxyComponent>
    {
        public override bool HasData => false;
    }
    
    public class OnParticleSystemStoppedProxyComponent : BaseProxyEventComponent
    {
        public void OnParticleSystemStopped() => SendEvent(OnParticleSystemStoppedEvent.Instance);
    }
}