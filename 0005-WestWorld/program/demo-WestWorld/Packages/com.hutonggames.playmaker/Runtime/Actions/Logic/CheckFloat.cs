using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckFloat")]
    [ActionDescription("Check a float value against a condition.")]
    public class CheckFloat : BaseTrueFalseAction
    {
        [Tooltip("The Float variable to check.")]
        public FloatRef Float;

        [Tooltip(Strings.ConditionTest)]
        [MatchType(nameof(Float))]
        public ConditionTest CheckIf = new ();
        
        public override bool CanExecute() => CheckParameters(Float);

        protected override string TrueSummary => "{Float} {CheckIf}";
        protected override string FalseSummary => "{Float} not {CheckIf}";
        
        protected override bool Test() => CheckIf.Evaluate(Float.Value);
    }
}