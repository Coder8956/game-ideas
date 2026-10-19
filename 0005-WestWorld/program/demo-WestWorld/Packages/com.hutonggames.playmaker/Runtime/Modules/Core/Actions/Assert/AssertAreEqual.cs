using System;
using UnityEngine;
using UnityEngine.Assertions;


namespace HutongGames.PlayMaker.Tests
{
    [Serializable]
    [ActionCategory(Category.Assert)]
    [ConvertibleGroup("Assert")]
    [ActionDescription("Assert that a variable equals an expected value.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Assertions.Assert.AreEqual.html")]
    public class AssertAreEqual : BaseAction
    {
        [BaseType(typeof(object))]
        [Tooltip("The variable to test.")]
        [SerializeReference] public IVariableRef Variable;
        
        [OptionalField] // can be null
        [MatchType(nameof(Variable))]
        [Tooltip("The expected value.")]
        [SerializeReference] public IVariableVar Value;

        [OptionalField]
        [Tooltip("Message to log if the assertion fails.")]
        public string Message;

        public override bool CanExecute() => Variable.IsAssigned && Value.HasValue(true);
        
        public override void Execute()
        {
            Assert.IsTrue(ValueHelper.ValuesEqual(Value.GetValue(), Variable.GetValue()), Message);
        }

        public override string GetSummary() => "Assert {Variable} == {Value}";
    }
}
