using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [Tooltip("Simple vector direction.")]
    public class VectorDirectionBlock : BaseDirectionBlock
    {
        [Tooltip("Direction vector.")]
        public Vector3Var Direction;
        
        public override bool CanExecute() => Action.CheckParameters(Direction);
        
        public override Vector3 GetDirection() => Direction.Value;
        
        public override void SetDirection(Vector3 worldPosition) => Direction.Value = worldPosition - StartPosition;

        public override string GetSummary() => "{Direction}";
    }
}