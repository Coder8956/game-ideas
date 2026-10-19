using UnityEngine;

namespace HutongGames.PlayMaker
{
    // TODO: BaseCollisionEvent or CollisionData class
    
    public class OnCollisionExitProxyComponent : BaseProxyEventComponent
    {
        public void OnCollisionExit(Collision collision)
        {
            var onCollisionExitEvent = OnCollisionExitEvent.Init(collision);
            SendEvent(onCollisionExitEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.PhysicsRoot)]
    [Tooltip("Sent when this collider or rigidbody has stopped touching another rigidbody or collider.")]
    public class OnCollisionExitEvent : 
        BaseSystemProxyEvent<OnCollisionExitEvent, OnCollisionExitProxyComponent>, 
        IHasCollisionData
    {
        public static OnCollisionExitEvent Init(Collision collision)
        {
            Instance.Collision = collision;
            return Instance;
        }

        public Collision Collision { get; private set; }
        
        public override BaseEventDataGetter GetEventDataGetter() => new CollisionDataGetter();
    }
}