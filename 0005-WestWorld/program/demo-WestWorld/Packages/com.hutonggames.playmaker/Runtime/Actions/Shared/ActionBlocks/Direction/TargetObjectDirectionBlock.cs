using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [Tooltip("Direction based on target GameObject.")]
    public class TargetObjectDirectionBlock : BaseDirectionBlock
    {
        [Tooltip("Target GameObject.")]
        public GameObjectVar Target;
        
        [DefaultValue(1f)]
        [Tooltip("Length of the ray.")]
        public FloatVar Length;

        public override bool IsValid => Target.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Target, Length);
        
        public override Vector3 GetDirection() => (Target.Transform.position - StartPosition).normalized * Length.Value;

        public override string GetSummary() => "target: {Target} length: {Length}";
    }
}