using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [EventData(typeof(OnCollisionEnter2DEvent))] // TODO: multiple
    public class Collision2DDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The GameObject collided with.<br/>Use Collision2D to get more information about the collision.")]
        public GameObjectRef GameObjectHit = new();

        [OptionalField, WriteOnly]
        [Tooltip("Complete information about the collision.<br/>Use Collision2D actions to get more information.")]
        public Collision2DRef Collision2DInfo = new();
        
        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not IHasCollision2DData collisionEvent)
            {
                Debug.LogWarning($"{baseEvent.Name} Event does not have Collision2D data!");
                return;
            }
            
            base.GetDataFromEvent(baseEvent);

            if (GameObjectHit.IsAssigned)
            {
                GameObjectHit.Value = collisionEvent.Collision?.gameObject;
            }

            if (Collision2DInfo.IsAssigned)
            {
                Collision2DInfo.Value = collisionEvent.Collision;
            }
        }
    }
}