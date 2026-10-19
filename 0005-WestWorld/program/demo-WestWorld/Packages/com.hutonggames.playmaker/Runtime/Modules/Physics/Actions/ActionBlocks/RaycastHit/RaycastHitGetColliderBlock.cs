using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Collider")]
    public class RaycastHitGetColliderBlock : RaycastHitBlock
    {
        [WriteOnly]
        [Tooltip("Get the Collider hit by the raycast.")]
        public ColliderRef Collider;

        public override void GetInfo(RaycastHit hit) => Collider.Value = hit.collider;
    }
}