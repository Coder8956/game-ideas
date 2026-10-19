using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("ArticulationBody")]
    public class RaycastHitGetArticulationBodyBlock : RaycastHitBlock
    {
        [WriteOnly]
        [Tooltip("Get the ArticulationBody of the collider that was hit. " +
                 "If the collider is not attached to an articulation body then it is null.")]
        public ArticulationBodyRef ArticulationBody;

        public override void GetInfo(RaycastHit hit) => ArticulationBody.Value = hit.articulationBody;
    }
}