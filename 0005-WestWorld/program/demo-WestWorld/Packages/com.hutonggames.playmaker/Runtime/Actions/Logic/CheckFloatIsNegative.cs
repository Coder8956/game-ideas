using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckFloat")]
    [ActionDescription("Check if a Float variable has a negative value.")]
    public class CheckFloatIsNegative : BaseTrueFalseAction
    {
        [Tooltip("The Float to check.")]
        public FloatRef Float;
        
        protected override string TrueSummary => "{Float} is negative";
        protected override string FalseSummary => "{Float} is not negative";
        
        public override bool CanExecute() => CheckParameters(Float);

        protected override bool Test() => Float.Value > 0;
    }
}