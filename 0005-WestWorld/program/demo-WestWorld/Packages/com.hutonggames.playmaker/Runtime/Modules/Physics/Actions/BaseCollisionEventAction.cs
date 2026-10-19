using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public abstract class BaseCollisionEventAction<T> : GameObjectProxyEventAction<T> where T: BaseEvent, IHasCollisionData, new()
    {
        [TagValue, OptionalField]
        [Tooltip("Only send the event if the other collider has this tag.")]
        public StringVar Tag;
        
        [OptionalField]
        [Tooltip("Event to send.")]
        [SerializeField]
        protected EventRef _sendEvent;
        
        [DisplayOrder(1000)]
        [OptionalField, WriteOnly]
        [Tooltip("Store the collision info.")]
        public CollisionRef StoreCollisionInfo;

        [DisplayOrder(1001)]
        [OptionalField, WriteOnly]
        [Tooltip("Store the GameObject hit.")]
        public GameObjectRef StoreGameObject = new();
        
        public override bool OnEvent(BaseEvent baseEvent)
        {
            if (baseEvent is T collisionEvent && collisionEvent.SentByGameObject == GameObject.Value)
            {
                if (!string.IsNullOrEmpty(Tag.Value) && !collisionEvent.Collision.collider.CompareTag(Tag.Value))
                {
                    return false;
                }

                if (StoreCollisionInfo.HasValue())
                {
                    StoreCollisionInfo.Value = collisionEvent.Collision;
                }

                if (StoreGameObject is { IsAssigned: true })
                {
                    StoreGameObject.Value = collisionEvent.Collision.gameObject;
                }

                if (_sendEvent.IsSet)
                {
                    SendEvent(_sendEvent);
                }

                return true;
            }

            return false;
        }

        public override string ErrorCheck() => !_sendEvent.IsSet && !StoreCollisionInfo.HasValue() && StoreGameObject is not { IsAssigned: true }
            ? "Action does not send any events or store the result!"
            : null;
        
        public override string GetSummary()
        {
            var summary = "{GameObject} " + GetType().Name;

            if (Tag.IsNotDefault())
            {
                summary += " tag {Tag}";
            }

            summary += " {_sendEvent} {StoreCollisionInfo:output} {StoreGameObject:output}";

            return summary;
        }
    }
}
