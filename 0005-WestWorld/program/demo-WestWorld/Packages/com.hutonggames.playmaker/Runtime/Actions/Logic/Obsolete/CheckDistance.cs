using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [Obsolete("Use CheckDistanceToTarget or CheckDistanceToPoint instead. This action will be removed in a future version.")]
    [PublicAPI]
    [ActionCategory(Category.LogicSpatial)]
    [ActionDescription("Check the distance between 2 objects.")]
    public class CheckDistance : BaseTrueFalseAction
    {
        [Tooltip("The Transform to check distance from.")]
        public TransformVar FromObject;

        [Tooltip("The Transform to check distance to.")]
        public TransformVar ToObject;
        
        [Tooltip("The check to perform."), DefaultValue("LessThan")]
        public NumericComparisonOperation Check;
        
        [Tooltip("The distance to check against.")]
        public FloatVar Distance;
        
        private float _distanceToTarget;
        
        protected override string TrueSummary => "{FromObject} distance to {ToObject} is {Check} {Distance}";
        protected override string FalseSummary => "{FromObject} distance to {ToObject} is not {Check} {Distance}";
        
        public override bool CanExecute() => CheckParameters(FromObject, ToObject, Distance);

        protected override bool Test()
        {
            var from = FromObject.Value;
            if (!from) return false;

            var target = ToObject.Value;
            if (!target) return false;
            
            _distanceToTarget = Vector3.Distance(from.position, target.position);
            return Check.Evaluate(_distanceToTarget, Distance.Value);
        }

#if UNITY_EDITOR

        public override bool HasDebugInfo => true;
		
        public override string GetDebugInfo() => $"Distance: {_distanceToTarget:0.##}";
		
#endif
    }
}
