using UnityEngine;

namespace HutongGames.PlayMaker
{
    // TODO: BaseCollisionEvent or CollisionData class
    
    public class OnCollisionStay2DProxyComponent : BaseProxyEventComponent
    {
        public void OnCollisionStay2D(Collision2D collision)
        {
            var onCollisionStay2dEvent = OnCollisionStay2DEvent.Init(collision);
            SendEvent(onCollisionStay2dEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.Physics2DRoot)]
    [Tooltip("Sent while this collider2d or rigidbody2d is touching another rigidbody2d or collider2d.")]
    public class OnCollisionStay2DEvent : 
        BaseSystemProxyEvent<OnCollisionStay2DEvent, OnCollisionStay2DProxyComponent>, 
        IHasCollision2DData
    {
        public static OnCollisionStay2DEvent Init(Collision2D collision)
        {
            Instance.Collision = collision;
            return Instance;
        }

        public Collision2D Collision { get; private set; }

        public override BaseEventDataGetter GetEventDataGetter() => new Collision2DDataGetter();
    }
}