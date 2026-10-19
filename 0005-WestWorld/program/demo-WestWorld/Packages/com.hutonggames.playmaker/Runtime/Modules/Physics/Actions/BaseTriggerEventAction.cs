using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public abstract class BaseTriggerEventAction<T> : GameObjectProxyEventAction<T> where T: BaseEvent, IHasColliderData, new()
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
        [Tooltip("Store the collider info.")]
        public ColliderRef StoreColliderInfo;

        [DisplayOrder(1001)]
        [OptionalField, WriteOnly]
        [Tooltip("Store the GameObject hit.")]
        public GameObjectRef StoreGameObject = new();
        
        public override bool OnEvent(BaseEvent baseEvent)
        {
            if (baseEvent is T collisionEvent && collisionEvent.SentByGameObject == GameObject.Value)
            {
                if (!string.IsNullOrEmpty(Tag.Value) && !collisionEvent.Collider.CompareTag(Tag.Value))
                {
                    return false;
                }

                if (StoreColliderInfo.HasValue())
                {
                    StoreColliderInfo.Value = collisionEvent.Collider;
                }

                if (StoreGameObject is { IsAssigned: true })
                {
                    StoreGameObject.Value = collisionEvent.Collider.gameObject;
                }

                if (_sendEvent.IsSet)
                {
                    SendEvent(_sendEvent);
                }

                return true;
            }

            return false;
        }

        public override string ErrorCheck() => !_sendEvent.IsSet && !StoreColliderInfo.HasValue() && StoreGameObject is not { IsAssigned: true }
            ? "Action does not send any events or store the result!"
            : null;
        
        public override string GetSummary()
        {
            var summary = "{GameObject} " + GetType().Name;

            if (Tag.IsNotDefault())
            {
                summary += " tag {Tag}";
            }

            summary += " {_sendEvent} {StoreColliderInfo:output} {StoreGameObject:output}";

            return summary;
        }
    }
}
