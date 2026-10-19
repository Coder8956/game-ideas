using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckFloat")]
    [ActionDescription("Check if a Float variable is equal to a given value.")]
    public class CheckFloatEquals : BaseTrueFalseAction
    {
        [Tooltip("The Float to check.")]
        public FloatRef Float;

        [Tooltip("The value to compare to.")]
        public FloatVar EqualTo;
        
        protected override string TrueSummary => "{Float} == {EqualTo}";
        protected override string FalseSummary => "{Float} != {EqualTo}";
        
        public override bool CanExecute() => CheckParameters(Float, EqualTo);

        protected override bool Test() => Mathf.Approximately(Float.Value, EqualTo.Value);
    }
}