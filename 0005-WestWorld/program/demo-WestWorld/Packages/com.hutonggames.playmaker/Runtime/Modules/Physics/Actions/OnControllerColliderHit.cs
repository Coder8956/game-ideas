using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.CollisionEvents)]
    [ConvertibleGroup("PhysicsEvents")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController.OnControllerColliderHit.html")]
    public class OnControllerColliderHit : GameObjectProxyEventAction<OnControllerColliderHitEvent>
    {
        [Tooltip("Event to send.")]
        [SerializeField, OptionalField]
        private EventRef _sendEvent;
        
        [DisplayOrder(1000)]
        [Tooltip("Store the ControllerColliderHit info. Use ControllerColliderHit actions to get info on the collision.")]
        [SerializeField, OptionalField, WriteOnly]
        private ControllerColliderHitRef _storeControllerColliderHitInfo;
        
        public override bool OnEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not OnControllerColliderHitEvent collisionEvent ||
                collisionEvent.SentByGameObject != GameObject.Value) return false;
            
            if (_storeControllerColliderHitInfo.HasValue())
            {
                _storeControllerColliderHitInfo.Value = collisionEvent.ControllerColliderHit;
            }

            if (_sendEvent.IsSet)
            {
                SendEvent(_sendEvent);
            }

            return true;

        }
        
        public override string GetSummary()
        {
            var summary = "{GameObject} " + GetType().Name;
            
            if (_sendEvent.IsSet)
            {
                summary += " {_sendEvent}";
            }
            
            if (_storeControllerColliderHitInfo.HasValue())
            {
                summary += " -> {_storeControllerColliderHitInfo}";
            }

            return summary;
        }
    }
}