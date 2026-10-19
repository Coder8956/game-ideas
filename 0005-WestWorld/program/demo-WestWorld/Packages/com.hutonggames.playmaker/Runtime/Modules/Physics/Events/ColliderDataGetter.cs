using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class ColliderDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The GameObject collided with.<br/>Use Collider to get more information about the collision.")]
        public GameObjectRef GameObjectHit = new();
        
        [OptionalField, WriteOnly]
        [Tooltip("The Collider contains information about the collision.<br/>Use Collider actions to get more information.")]
        public ColliderRef ColliderInfo = new();
        
        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not IHasColliderData colliderEvent)
            {
                Debug.LogWarning($"{baseEvent.Name} Event does not have Collider data!");
                return;
            }
            
            base.GetDataFromEvent(baseEvent);

            if (GameObjectHit.IsAssigned)
            {
                GameObjectHit.Value = colliderEvent.Collider?.gameObject;
            }
            
            if (ColliderInfo.IsAssigned)
            {
                ColliderInfo.Value = colliderEvent.Collider;
            }
        }
    }
}