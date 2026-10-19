using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public class CollisionGetGameObjectBlock : CollisionBlock
    {
        [Tooltip("Get the GameObject collided with.")]
        [WriteOnly]
        public GameObjectRef GameObject;

        public override void GetInfo(Collision collision)
        {
            GameObject.Value = collision.collider ? collision.collider.gameObject : null;
        }
        
        public override string GetSummary()
        {
            return "{GameObject}";
        }
    }
}
