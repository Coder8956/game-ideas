using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckFloat")]
    [ActionDescription("Check if a Float variable has a positive value.")]
    public class CheckFloatIsPositive : BaseTrueFalseAction
    {
        [Tooltip("The Float to check.")]
        public FloatRef Float;
        
        protected override string TrueSummary => "{Float} is positive";
        protected override string FalseSummary => "{Float} is not positive";
        
        public override bool CanExecute() => CheckParameters(Float);

        protected override bool Test() => Float.Value > 0;
    }
}