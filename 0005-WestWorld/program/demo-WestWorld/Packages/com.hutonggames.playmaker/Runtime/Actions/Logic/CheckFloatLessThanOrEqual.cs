using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckFloat")]
    [ActionDescription("Check if a Float variable is less than or equal to a given value.")]
    public class CheckFloatLessThanOrEqual : BaseTrueFalseAction
    {
        [Tooltip("The Float to check.")]
        public FloatRef Float;

        [Tooltip("The value to compare to.")]
        [ConvertibleName("Other")]
        public FloatVar LessThanOrEqual;
        
        protected override string TrueSummary => "{Float} <= {LessThanOrEqual}";
        protected override string FalseSummary => "{Float} > {LessThanOrEqual}";
        
        public override bool CanExecute() => CheckParameters(Float, LessThanOrEqual);

        protected override bool Test() => Float.Value <= LessThanOrEqual.Value;
    }
}