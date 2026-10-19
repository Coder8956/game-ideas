using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class Collider2DDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The GameObject collided with.<br/>Use Collider2D to get more information about the collision.")]
        public GameObjectRef GameObjectHit = new();
        
        [OptionalField, WriteOnly]
        [Tooltip("The Collider2D.<br/>Use Collider2D actions to get more information.")]
        public Collider2DRef Collider2DInfo = new();
        
        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not IHasCollider2DData colliderEvent)
            {
                Debug.LogWarning($"{baseEvent.Name} Event does not have Collider2D data!");
                return;
            }
            
            base.GetDataFromEvent(baseEvent);

            if (GameObjectHit.IsAssigned)
            {
                GameObjectHit.Value = colliderEvent.Collider2D?.gameObject;
            }
            
            if (Collider2DInfo.IsAssigned)
            {
                Collider2DInfo.Value = colliderEvent.Collider2D;
            }
        }
    }
}