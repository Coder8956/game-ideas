using System;
using UnityEngine;
using UnityEngine.Assertions;


namespace HutongGames.PlayMaker.Tests
{
    [Serializable]
    [ActionCategory(Category.Assert)]
    [ConvertibleGroup("Assert")]
    [ActionDescription("Assert that a float variable is not approximately equal to a value.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Assertions.Assert.AreNotApproximatelyEqual.html")]
    public class AssertAreNotApproximatelyEqual : BaseAction
    {
        [Tooltip("The variable to test.")]
        public FloatRef Variable;

        [Tooltip("The value to check against.")]
        public FloatVar Value;
        
        [DefaultValue(0.00001f)]
        [Tooltip("The tolerance of the check.")]
        public FloatVar Tolerance;
        
        [OptionalField]
        [Tooltip("Message to log if the assertion fails.")]
        public string Message;
        
        public override bool CanExecute() => Variable.IsAssigned && Value.HasValue(true);
        
        public override void Execute() => Assert.AreNotApproximatelyEqual( Value.Value,Variable.Value, Tolerance.Value, Message);
        
        public override string GetSummary() => "Assert {Variable} !≈ {Value}";

    }
}