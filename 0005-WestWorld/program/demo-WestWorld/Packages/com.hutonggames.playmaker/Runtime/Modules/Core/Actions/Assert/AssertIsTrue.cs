using System;
using UnityEngine;
using UnityEngine.Assertions;


namespace HutongGames.PlayMaker.Tests
{
    [Serializable]
    [ActionCategory(Category.Assert)]
    [ConvertibleGroup("Assert")]
    [ActionDescription("Assert that a variable is true.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Assertions.Assert.IsTrue.html")]
    public class AssertIsTrue : BaseAction
    {
        [Tooltip("The variable to test.")]
        public BoolRef Variable;

        [OptionalField]
        [Tooltip("Message to log if the assertion fails.")]
        public string Message;
        
        public override bool CanExecute() => Variable.IsAssigned;
        
        public override void Execute() => Assert.IsTrue(Variable.Value, Message);
        
        public override string GetSummary() => "Assert {Variable} is true";
    }
}