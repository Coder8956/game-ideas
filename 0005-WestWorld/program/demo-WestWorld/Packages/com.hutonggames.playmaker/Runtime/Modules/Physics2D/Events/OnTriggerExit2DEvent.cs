using UnityEngine;

namespace HutongGames.PlayMaker
{
    public class OnTriggerExit2DProxyComponent : BaseProxyEventComponent
    {
        public void OnTriggerExit2D(Collider2D collider2D)
        {
            var onTriggerExit2DEvent = OnTriggerExit2DEvent.Init(collider2D);
            SendEvent(onTriggerExit2DEvent);
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.Physics2DRoot)]
    [Tooltip("Sent when another object leaves a trigger collider attached to this object (2D physics only).")]
    public class OnTriggerExit2DEvent : 
        BaseSystemProxyEvent<OnTriggerExit2DEvent, OnTriggerExit2DProxyComponent>, 
        IHasCollider2DData
    {
        public static OnTriggerExit2DEvent Init(Collider2D collider)
        {
            Instance.Collider2D = collider;
            return Instance;
        }

        public Collider2D Collider2D { get; private set; }

        public override BaseEventDataGetter GetEventDataGetter() => new Collider2DDataGetter();
    }
}