using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [Tooltip("Direction based on vector and length.")]
    public class VectorLengthDirectionBlock : BaseDirectionBlock
    {
        [Tooltip("Direction vector.")]
        public Vector3Var Direction;
        
        [DefaultValue(1f)]
        [Tooltip("Length of the ray.")]
        public FloatVar Length;
        
        public override bool CanExecute() => Action.CheckParameters(Direction, Length);
        
        public override Vector3 GetDirection() => Direction.Value.normalized * Length.Value;
        
        public override void SetDirection(Vector3 worldPosition)
        {
            Direction.Value = worldPosition - StartPosition;
            Length.Value = Direction.Value.magnitude;
        }

        public override string GetSummary() => "{Direction} length: {Length}";
    }
}