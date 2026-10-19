using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [Tooltip("Direction based on Euler angles.")]
    public class EulerAnglesDirectionBlock : BaseDirectionBlock
    {
        [Tooltip("Angles around x, y, and z.")]
        public Vector3Var Angles;
        
        [DefaultValue(1f)]
        [Tooltip("Length of the ray.")]
        public FloatVar Length;

        public override bool CanExecute() => Action.CheckParameters(Angles, Length);

        public override Vector3 GetDirection()
        {
            return Quaternion.Euler(Angles.Value) * Vector3.forward * Length.Value;
        }

        public override void SetDirection(Vector3 worldPosition)
        {
            var direction = worldPosition - StartPosition;
            Length.Value = direction.magnitude;
            Angles.Value = Quaternion.LookRotation(direction).eulerAngles;
        }

        public override string GetSummary() => "angles: {Angles} length: {Length}";
    }
}