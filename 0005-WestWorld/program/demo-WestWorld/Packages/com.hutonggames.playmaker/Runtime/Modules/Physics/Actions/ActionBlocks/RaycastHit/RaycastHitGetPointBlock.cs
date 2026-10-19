using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Point")]
    public class RaycastHitGetPointBlock : RaycastHitBlock
    {
        [WriteOnly]
        [Tooltip("Get the impact point in world space where the ray hit the collider.")]
        public Vector3Ref Point;

        public override void GetInfo(RaycastHit hit) => Point.Value = hit.point;
    }
}