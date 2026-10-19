using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckString")]
    [ActionDescription("Check if a String variable is equal to a given value.")]
    public class CheckStringEquals : BaseTrueFalseAction
    {
        [Tooltip("The String to check.")]
        public StringRef String;

        [Tooltip("The value to compare to.")]
        public StringVar EqualTo;
        
        protected override string TrueSummary => "{String} == {EqualTo}";
        protected override string FalseSummary => "{String} != {EqualTo}";
        
        public override bool CanExecute() => CheckParameters(String, EqualTo);

        protected override bool Test()
        {
            if (String.Value == null) return EqualTo.Value == null;
            return String.Value.Equals(EqualTo.Value, StringComparison.Ordinal);
        }
    }
}