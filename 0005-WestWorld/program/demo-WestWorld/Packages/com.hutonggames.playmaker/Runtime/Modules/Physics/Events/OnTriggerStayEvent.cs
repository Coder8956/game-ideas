using UnityEngine;

namespace HutongGames.PlayMaker
{
    public class OnTriggerStayProxyComponent : BaseProxyEventComponent
    {
        public void OnTriggerStay(Collider collider)
        {
            var onTriggerStayEvent = OnTriggerStayEvent.Init(collider);
            SendEvent(onTriggerStayEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.PhysicsRoot)]
    [Tooltip("Sent when this collider or rigidbody has begun touching another rigidbody or collider.")]
    public class OnTriggerStayEvent : 
        BaseSystemProxyEvent<OnTriggerStayEvent, OnTriggerStayProxyComponent>, 
        IHasColliderData
    {
        public static OnTriggerStayEvent Init(Collider collider)
        {
            Instance.Collider = collider;
            return Instance;
        }

        public Collider Collider { get; private set; }

        public override BaseEventDataGetter GetEventDataGetter() => new ColliderDataGetter();
    }
}