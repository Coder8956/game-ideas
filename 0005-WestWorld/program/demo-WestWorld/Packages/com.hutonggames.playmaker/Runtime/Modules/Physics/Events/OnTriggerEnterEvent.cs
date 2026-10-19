using UnityEngine;

namespace HutongGames.PlayMaker
{
    public class OnTriggerEnterProxyComponent : BaseProxyEventComponent
    {
        public void OnTriggerEnter(Collider collider)
        {
            var onTriggerEnterEvent = OnTriggerEnterEvent.Init(collider);
            SendEvent(onTriggerEnterEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.PhysicsRoot)]
    [Tooltip("Sent when this collider or rigidbody has begun touching another rigidbody or collider.")]
    public class OnTriggerEnterEvent : 
        BaseSystemProxyEvent<OnTriggerEnterEvent, OnTriggerEnterProxyComponent>, 
        IHasColliderData
    {
        public static OnTriggerEnterEvent Init(Collider collider)
        {
            Instance.Collider = collider;
            return Instance;
        }

        public Collider Collider { get; private set; }

        public override BaseEventDataGetter GetEventDataGetter() => new ColliderDataGetter();
    }
}