using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicSpatial)]
    [ActionDescription("Check the distance between an object and a point in space.")]
    public class CheckDistanceToPoint : BaseTrueFalseAction
    {
        [Tooltip("The Transform to check distance from.")]
        public TransformVar FromObject;

        [Tooltip("The point to check distance to.")]
        public Vector3Var ToPoint;
        
        [Tooltip("The check to perform."), DefaultValue("LessThan")]
        public NumericComparisonOperation Check;
        
        [Tooltip("The distance to check against.")]
        public FloatVar Distance;

        [Tooltip("Store the distance between the object and the point.")]
        [OptionalField, WriteOnly, DisplayOrder(2000)]
        public FloatRef StoreDistance;
        
        private float _distanceToPoint;
        
        protected override string TrueSummary => "{FromObject} distance to {ToPoint} is {Check} {Distance} {StoreDistance:output}";
        protected override string FalseSummary => "{FromObject} distance to {ToPoint} is not {Check} {Distance} {StoreDistance:output}";
        
        public override bool CanExecute() => CheckParameters(FromObject, ToPoint, Distance);

        protected override bool Test()
        {
            var from = FromObject.Value;
            if (!from) return false;
            
            _distanceToPoint = Vector3.Distance(from.position, ToPoint.Value);
            if (StoreDistance.IsAssigned) StoreDistance.Value = _distanceToPoint;
            return Check.Evaluate(_distanceToPoint, Distance.Value);
        }

#if UNITY_EDITOR

        public override bool HasDebugInfo => true;
		
        public override string GetDebugInfo() => $"Distance: {_distanceToPoint:0.##}";
		
#endif
    }
}
