using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Normal")]
    public class RaycastHitGetNormalBlock : RaycastHitBlock
    {        
        [WriteOnly]
        [Tooltip("Get The normal of the surface the ray hit.")]
        public Vector3Ref Normal;

        public override void GetInfo(RaycastHit hit) => Normal.Value = hit.normal;
    }
}