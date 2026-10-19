using System;
using UnityEngine;
using UnityEngine.Assertions;


namespace HutongGames.PlayMaker.Tests
{
    [Serializable]
    [ActionCategory(Category.Assert)]
    [ConvertibleGroup("Assert")]
    [ActionDescription("Assert that a variable is false.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Assertions.Assert.IsFalse.html")]
    public class AssertIsFalse : BaseAction
    {
        [Tooltip("The variable to test.")]
        public BoolRef Variable;

        [OptionalField]
        [Tooltip("Message to log if the assertion fails.")]
        public string Message;
        
        public override bool CanExecute() => Variable.IsAssigned;
        
        public override void Execute() => Assert.IsFalse(Variable.Value, Message);
        
        public override string GetSummary() => "Assert {Variable} is false";
    }
}