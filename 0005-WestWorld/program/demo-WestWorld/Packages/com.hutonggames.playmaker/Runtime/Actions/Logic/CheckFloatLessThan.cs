using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckFloat")]
    [ActionDescription("Check if a Float variable is less than a given value.")]
    public class CheckFloatLessThan : BaseTrueFalseAction
    {
        [Tooltip("The Float to check.")]
        public FloatRef Float;

        [Tooltip("The value to compare to.")]
        [ConvertibleName("Other")]
        public FloatVar LessThan;
        
        protected override string TrueSummary => "{Float} < {LessThan}";
        protected override string FalseSummary => "{Float} >= {LessThan}";
        
        public override bool CanExecute() => CheckParameters(Float, LessThan);

        protected override bool Test() => Float.Value < LessThan.Value;
    }
}