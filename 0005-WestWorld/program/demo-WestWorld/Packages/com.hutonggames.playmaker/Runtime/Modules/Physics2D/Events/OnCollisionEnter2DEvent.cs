using UnityEngine;

namespace HutongGames.PlayMaker
{
    // TODO: BaseCollisionEvent or CollisionData class
    
    public class OnCollisionEnter2DProxyComponent : BaseProxyEventComponent
    {
        public void OnCollisionEnter2D(Collision2D collision)
        {
            var onCollisionEnter2dEvent = OnCollisionEnter2DEvent.Init(collision);
            SendEvent(onCollisionEnter2dEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.Physics2DRoot)]
    [Tooltip("Sent when this collider or rigidbody has begun touching another rigidbody or collider.")]
    public class OnCollisionEnter2DEvent : 
        BaseSystemProxyEvent<OnCollisionEnter2DEvent, OnCollisionEnter2DProxyComponent>, 
        IHasCollision2DData
    {
        public static OnCollisionEnter2DEvent Init(Collision2D collision)
        {
            Instance.Collision = collision;
            return Instance;
        }

        public Collision2D Collision { get; private set; }

        public override BaseEventDataGetter GetEventDataGetter() => new Collision2DDataGetter();
    }
}