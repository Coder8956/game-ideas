using System;
using UnityEngine;
using UnityEngine.Assertions;


namespace HutongGames.PlayMaker.Tests
{
    [Serializable]
    [ActionCategory(Category.Assert)]
    [ConvertibleGroup("Assert")]
    [ActionDescription("Assert that a variable does not equal a value.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Assertions.Assert.AreNotEqual.html")]
    public class AssertAreNotEqual : BaseAction
    {
        [BaseType(typeof(object))]
        [Tooltip("The variable to test.")]
        [SerializeReference] public IVariableRef Variable;
        
        [MatchType(nameof(Variable))]
        [Tooltip("The value to check.")]
        [SerializeReference] public IVariableVar Value;

        [OptionalField]
        [Tooltip("Message to log if the assertion fails.")]
        public string Message;
        
        public override bool CanExecute() => Variable.IsAssigned && Value.HasValue(true);
        
        public override void Execute()
        {
            Assert.IsFalse(ValueHelper.ValuesEqual(Value.GetValue(), Variable.GetValue()), Message);
        }
        
        public override string GetSummary() => "Assert {Variable} != {Value}";

    }
}
