
using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [EventData(typeof(OnParticleCollisionEvent))] 
    public class ParticleCollisionDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The other GameObject.")]
        public GameObjectRef GameObjectHit = new();

        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not OnParticleCollisionEvent onParticleCollisionEvent)
            {
                Debug.LogWarning($"{baseEvent.Name} Event is not OnParticleCollisionEvent!");
                return;
            }
            
            base.GetDataFromEvent(baseEvent);

            if (GameObjectHit.IsAssigned)
            {
                GameObjectHit.Value = onParticleCollisionEvent.GameObjectHit;
            }
        }
    }

    [System.Serializable]
    [SystemEvent(SystemEvents.ParticlesRoot)]
    [Tooltip("Sent when a particle hits a Collider.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnParticleCollision.html")]
    public class OnParticleCollisionEvent : BaseSystemProxyEvent<OnParticleCollisionEvent, OnParticleCollisionProxyComponent>
    {
        public GameObject GameObjectHit { get; private set; }
        
        public static OnParticleCollisionEvent Init(GameObject other)
        {
            Instance.GameObjectHit = other;
            return Instance;
        }
        
        public override BaseEventDataGetter GetEventDataGetter() => new ParticleCollisionDataGetter();
    }
    
    public class OnParticleCollisionProxyComponent : BaseProxyEventComponent
    {
        public void OnParticleCollision(GameObject other)
        {
            var evt = OnParticleCollisionEvent.Init(other);
            SendEvent(evt);
        }
    }
}
