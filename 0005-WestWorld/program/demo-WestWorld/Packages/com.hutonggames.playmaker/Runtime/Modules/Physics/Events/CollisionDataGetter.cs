using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [EventData(typeof(OnCollisionEnterEvent))] // TODO: multiple
    public class CollisionDataGetter : BaseEventDataGetter
    {
                
        [OptionalField, WriteOnly]
        [Tooltip("The GameObject collided with.<br/>Use CollisionInfo to get more information about the collision.")]
        public GameObjectRef GameObjectHit = new();
        
        [OptionalField, WriteOnly]
        [Tooltip("Complete information about the collision.<br/>Use Collision actions to get details.")]
        public CollisionRef CollisionInfo = new();
        
        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not IHasCollisionData collisionEvent)
            {
                Debug.LogWarning($"{baseEvent.Name} Event does not have Collision data!");
                return;
            }
            
            base.GetDataFromEvent(baseEvent);

            if (CollisionInfo.IsAssigned)
            {
                CollisionInfo.Value = collisionEvent.Collision;
            }
            
            if (GameObjectHit.IsAssigned)
            {
                GameObjectHit.Value = collisionEvent.Collision?.gameObject;
            }

        }
    }
}