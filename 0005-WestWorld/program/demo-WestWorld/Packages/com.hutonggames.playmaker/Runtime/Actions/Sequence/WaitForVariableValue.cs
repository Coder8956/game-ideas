using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Sequence)]
    [ActionDescription("Wait for a specific variable value.")]
    public class WaitForVariableValue : BaseWaitAction
    {
        public enum Test { Equals, NotEquals }

        [Tooltip("The variable to test")]
        [SerializeField]
        private AnyVariableRef _variable;

        [Tooltip("The test.")]
        [SerializeField]
        private Test _test;
        
        [SerializeReference]
        [MatchType(nameof(_variable))]
        [Tooltip("Check against this value")]
        [SerializeField, CanBeNullOrEmpty]
        private IVariableVar _value;
        
        public override bool CanExecute() => !_variable.IsNone;

        public override void Execute()
        {
            switch (_test)
            {
                case Test.Equals:
                    if (IsEqual()) Finish();
                    break;
                case Test.NotEquals:
                    if (!IsEqual()) Finish();
                    break;
            }
        }
        
        private bool IsEqual()
        {
            var variableValue = _variable.Variable.GetValue();
            var testValue = _value.GetValue();

            if (variableValue.IsUnityNull() || testValue.IsUnityNull())
            {
                return variableValue.IsUnityNull() && testValue.IsUnityNull();
            }

            if (variableValue is UnityEngine.Object || testValue is UnityEngine.Object)
            {
                return (variableValue as UnityEngine.Object) == (testValue as UnityEngine.Object);
            }

            return Equals(variableValue, testValue);
        }
        
        public override string GetSummary() => "Wait for {_variable} {_test} {_value}";
    }
}

