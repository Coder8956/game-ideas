using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Sequence)]
    [ActionDescription("Wait for a bool variable condition.")]
    public class WaitForBoolValue : BaseWaitAction
    {
        public enum Condition
        {
            IsTrue,
            IsFalse,
            Changed
        }
        
        [Tooltip("Boolean variable to check.")]
        [SerializeField]
        private BoolVar _bool;
        
        [Tooltip("Condition to wait for.\n\nChanged is true when the variable value changes from its initial value when entering the state.")]
        [SerializeField]
        private Condition _condition;

        private bool _initialValue;

        public override bool CanExecute() => CheckParameters(_bool);

        public override void OnStart()
        {
            _initialValue = _bool.Value;
        }

        public override void Execute()
        {
            switch(_condition)
            {
                case Condition.IsTrue:
                    if (_bool.Value) Finish();
                    break;
                case Condition.IsFalse:
                    if (!_bool.Value) Finish();
                    break;
                case Condition.Changed:
                    if (_bool.Value != _initialValue) Finish();
                    break;
            }
                
        }
        
        public override string GetSummary() => "Wait for {_bool} {_condition}";
    }
}

