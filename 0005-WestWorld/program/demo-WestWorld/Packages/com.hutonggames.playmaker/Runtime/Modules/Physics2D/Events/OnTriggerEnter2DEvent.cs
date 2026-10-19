using UnityEngine;

namespace HutongGames.PlayMaker
{
    public class OnTriggerEnter2DProxyComponent : BaseProxyEventComponent
    {
        public void OnTriggerEnter2D(Collider2D collider2D)
        {
            var onTriggerEnter2DEvent = OnTriggerEnter2DEvent.Init(collider2D);
            SendEvent(onTriggerEnter2DEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.Physics2DRoot)]
    [Tooltip("Sent when another object enters a trigger collider attached to this object (2D physics only).")]
    public class OnTriggerEnter2DEvent : 
        BaseSystemProxyEvent<OnTriggerEnter2DEvent, OnTriggerEnter2DProxyComponent>, 
        IHasCollider2DData
    {
        public static OnTriggerEnter2DEvent Init(Collider2D collider)
        {
            Instance.Collider2D = collider;
            return Instance;
        }

        public Collider2D Collider2D { get; private set; }

        public override BaseEventDataGetter GetEventDataGetter() => new Collider2DDataGetter();
    }
}