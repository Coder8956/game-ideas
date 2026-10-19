using UnityEngine;

namespace HutongGames.PlayMaker
{
    public class OnCollisionStayProxyComponent : BaseProxyEventComponent
    {
        public void OnCollisionStay(Collision collision)
        {
            var onCollisionStayEvent = OnCollisionStayEvent.Init(collision);
            SendEvent(onCollisionStayEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.PhysicsRoot)]
    public class OnCollisionStayEvent : 
        BaseSystemProxyEvent<OnCollisionStayEvent, OnCollisionStayProxyComponent>, 
        IHasCollisionData
    {
        public static OnCollisionStayEvent Init(Collision collision)
        {
            Instance.Collision = collision;
            return Instance;
        }
        
        public Collision Collision { get; private set; }

        public override BaseEventDataGetter GetEventDataGetter() => new CollisionDataGetter();
    }
}