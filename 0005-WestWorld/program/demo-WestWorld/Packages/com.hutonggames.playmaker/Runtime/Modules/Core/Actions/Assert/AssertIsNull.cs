using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HutongGames.PlayMaker.Tests
{
    [Serializable]
    [ActionCategory(Category.Assert)]
    [ConvertibleGroup("Assert")]
    [ActionDescription("Assert that an Object variable value is null.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Assertions.Assert.IsNull.html")]
    public sealed class AssertIsNull : BaseAction
    {
        [Tooltip("The variable to test.")]
        public ObjectRef Variable;

        [OptionalField]
        [Tooltip("Message to log if the assertion fails.")]
        public string Message;

        public override bool CanExecute() => Variable.IsAssigned;

        public override void Execute()
        {
            var value = Variable.Value;

            // UnityEngine.Object has special null semantics (fake-null).
            // Assert.IsNull(object) does not reliably use Unity's overloaded operator==.
            if (value is UnityEngine.Object uo)
            {
                Assert.IsTrue(uo == null, Message);
                return;
            }

            Assert.IsNull(value, Message);
        }

        public override string GetSummary() => "Assert {Variable} is null";
    }
}