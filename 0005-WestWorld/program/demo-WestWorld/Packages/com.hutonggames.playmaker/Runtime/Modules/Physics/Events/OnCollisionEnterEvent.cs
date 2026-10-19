using UnityEngine;

namespace HutongGames.PlayMaker
{
    // TODO: BaseCollisionEvent or CollisionData class
    
    public class OnCollisionEnterProxyComponent : BaseProxyEventComponent
    {
        public void OnCollisionEnter(Collision collision)
        {
            var onCollisionEnterEvent = OnCollisionEnterEvent.Init(collision);
            SendEvent(onCollisionEnterEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.PhysicsRoot)]
    [Tooltip("Sent when this collider or rigidbody has begun touching another rigidbody or collider.")]
    public class OnCollisionEnterEvent : 
        BaseSystemProxyEvent<OnCollisionEnterEvent, OnCollisionEnterProxyComponent>, 
        IHasCollisionData
    {
        public static OnCollisionEnterEvent Init(Collision collision)
        {
            Instance.Collision = collision;
            return Instance;
        }

        public Collision Collision { get; private set; }

        public override BaseEventDataGetter GetEventDataGetter() => new CollisionDataGetter();
    }
}