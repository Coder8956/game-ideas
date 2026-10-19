using UnityEngine;

namespace HutongGames.PlayMaker
{
    public class OnTriggerStay2DProxyComponent : BaseProxyEventComponent
    {
        public void OnTriggerStay2D(Collider2D collider2D)
        {
            var onTriggerStay2DEvent = OnTriggerStay2DEvent.Init(collider2D);
            SendEvent(onTriggerStay2DEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.Physics2DRoot)]
    [Tooltip("Sent each frame where another object is within a trigger collider attached to this object (2D physics only).")]
    public class OnTriggerStay2DEvent : 
        BaseSystemProxyEvent<OnTriggerStay2DEvent, OnTriggerStay2DProxyComponent>, 
        IHasCollider2DData
    {
        public static OnTriggerStay2DEvent Init(Collider2D collider)
        {
            Instance.Collider2D = collider;
            return Instance;
        }

        public Collider2D Collider2D { get; private set; }

        public override BaseEventDataGetter GetEventDataGetter() => new Collider2DDataGetter();
    }
}