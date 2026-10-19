using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameplayTargetingTransform)]
    [ActionDescription("Checks if a Transform is within a set distance to a target.")]
    [HelpURL("actions/transform-actions/measurement-actions/")]
    public class TransformCheckIsCloseToTarget : BaseTrueFalseAction
    {
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [Tooltip("The Target Transform.")]
        public TransformVar Target;
        
        [Tooltip("The distance to check.")]
        public FloatVar Distance;

        [Tooltip("The axis used to measure the distance.")]
        [SerializeField]
        private MoveAxisVar _axis;
        
        public override bool CanExecute() => CheckParameters(Transform, Target, Distance, _axis);

        protected override bool Test()
        {
            var transform = Transform.Value;
            if (transform == null) return false;
            
            var target = Target.Value;
            if (target == null) return false;
            
            var distance = Distance.Value;
            var testDistance = MoveAxisHelper.GetDistanceSquared(_axis.Value, transform.position, target.position);
            return testDistance < distance * distance;
        }

        protected override string TrueSummary => "{Transform} closer than {Distance} to {Target} ";
        protected override string FalseSummary => "{Transform} further than {Distance} to {Target} ";
        
        public override string GetSummary() => base.GetSummary() + " ({_axis})";
    }
}
