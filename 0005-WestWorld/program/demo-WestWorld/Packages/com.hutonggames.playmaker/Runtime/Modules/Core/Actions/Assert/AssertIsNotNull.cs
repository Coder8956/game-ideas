using System;
using UnityEngine;
using UnityEngine.Assertions;


namespace HutongGames.PlayMaker.Tests
{
    [Serializable]
    [ActionCategory(Category.Assert)]
    [ConvertibleGroup("Assert")]
    [ActionDescription("Assert that an Object variable value is not null.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Assertions.Assert.IsNotNull.html")]
    public class AssertIsNotNull : BaseAction
    {
        [Tooltip("The variable to test.")]
        public ObjectRef Variable;

        [OptionalField]
        [Tooltip("Message to log if the assertion fails.")]
        public string Message;
        
        public override bool CanExecute() => Variable.IsAssigned;
        
        public override void Execute() => Assert.IsNotNull(Variable.Value, Message);
        
        public override string GetSummary() => "Assert {Variable} is not null";
    }
}