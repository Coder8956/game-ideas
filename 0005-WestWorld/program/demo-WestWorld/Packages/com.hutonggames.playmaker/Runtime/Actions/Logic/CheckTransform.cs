using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckTransform")]
    [ActionDescription("Check a Transform value against a condition.")]
    public class CheckTransform : BaseTrueFalseAction
    {
        [Tooltip("The Transform variable to check.")]
        public TransformRef Transform;

        [MatchType(nameof(Transform))]
        [Tooltip(Strings.ConditionTest)]
        public ConditionTest CheckIf = new ();
        
        public override bool CanExecute() => CheckParameters(Transform);

        protected override string TrueSummary => "{Transform} {CheckIf}";
        protected override string FalseSummary => "{Transform} not {CheckIf}";
        
        protected override bool Test() => CheckIf.Evaluate(Transform.Value);
    }
}
