using UnityEngine;

namespace HutongGames.PlayMaker
{
    public class OnTriggerExitProxyComponent : BaseProxyEventComponent
    {
        public void OnTriggerExit(Collider collider)
        {
            var onTriggerExitEvent = OnTriggerExitEvent.Init(collider);
            SendEvent(onTriggerExitEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.PhysicsRoot)]
    [Tooltip("Sent when this collider or rigidbody has begun touching another rigidbody or collider.")]
    public class OnTriggerExitEvent : 
        BaseSystemProxyEvent<OnTriggerExitEvent, OnTriggerExitProxyComponent>, 
        IHasColliderData
    {
        public static OnTriggerExitEvent Init(Collider collider)
        {
            Instance.Collider = collider;
            return Instance;
        }

        public Collider Collider { get; private set; }

        public override BaseEventDataGetter GetEventDataGetter() => new ColliderDataGetter();
    }
}