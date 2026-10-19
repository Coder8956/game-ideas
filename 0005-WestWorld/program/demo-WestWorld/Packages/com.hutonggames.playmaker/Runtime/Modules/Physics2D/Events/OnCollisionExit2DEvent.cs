using UnityEngine;

namespace HutongGames.PlayMaker
{
    // TODO: BaseCollisionEvent or CollisionData class
    
    public class OnCollisionExit2DProxyComponent : BaseProxyEventComponent
    {
        public void OnCollisionExit2D(Collision2D collision)
        {
            var onCollisionExit2dEvent = OnCollisionExit2DEvent.Init(collision);
            SendEvent(onCollisionExit2dEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.Physics2DRoot)]
    [Tooltip("Sent when this collider2d or rigidbody2d stops touching another rigidbody2d or collider2d.")]
    public class OnCollisionExit2DEvent : 
        BaseSystemProxyEvent<OnCollisionExit2DEvent, OnCollisionExit2DProxyComponent>, 
        IHasCollision2DData
    {
        public static OnCollisionExit2DEvent Init(Collision2D collision)
        {
            Instance.Collision = collision;
            return Instance;
        }

        public Collision2D Collision { get; private set; }

        public override BaseEventDataGetter GetEventDataGetter() => new Collision2DDataGetter();
    }
}