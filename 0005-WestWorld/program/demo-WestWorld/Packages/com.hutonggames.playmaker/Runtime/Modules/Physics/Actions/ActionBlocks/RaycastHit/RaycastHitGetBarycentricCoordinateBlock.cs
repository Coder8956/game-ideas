using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Barycentric Coordinate")]
    public class RaycastHitGetBarycentricCoordinateBlock : RaycastHitBlock
    {
        [WriteOnly]
        [Tooltip("The barycentric coordinate of the triangle we hit." +
                 "This lets you interpolate any of the vertex data along the 3 axes.")]
        public Vector3Ref BarycentricCoordinate;

        public override void GetInfo(RaycastHit hit) => BarycentricCoordinate.Value = hit.barycentricCoordinate;
    }
}