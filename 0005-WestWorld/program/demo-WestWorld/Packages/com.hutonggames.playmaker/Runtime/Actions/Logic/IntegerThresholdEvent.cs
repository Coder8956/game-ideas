using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.LogicEvent)]
    [ActionDescription("Sends an event when an integer variable reaches a given threshold. " +
                       "Only sends the event when the threshold becomes true (edge trigger).")]
    public class IntegerThresholdEvent : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
        
        public enum ComparisonOperator
        {
            Equals,
            GreaterThan,
            GreaterThanOrEqual,
            LessThan,
            LessThanOrEqual,
        }
        
        [Tooltip("The integer to check.")]
        [SerializeField]
        private IntegerRef _integer;

        [Tooltip("The check to perform.")]
        [SerializeField]
        private ComparisonOperator _check;
        
        [Tooltip("Thresholds to check against.")]
        [SerializeField]
        private IntegerListVar _thresholds;
        
        [FormerlySerializedAs("_event")]
        [Tooltip("The event to send when a threshold is reached.")]
        [SerializeField]
        private EventRef _sendEvent;

        private int _lastValue;
        
        public override bool CanExecute() => CheckParameters(_integer, _thresholds, _sendEvent);
        
        public override void OnStart()
        {
            _lastValue = _integer.Value;
            _integer.Variable.ValueChanged += OnValueChanged;
        }

        public override void OnStop()
        {
            if (_integer?.Variable == null) return;
            _integer.Variable.ValueChanged -= OnValueChanged;
        }

        private void OnValueChanged()
        {
            var currentValue = _integer.Value;

            // Check each threshold
            foreach (var threshold in _thresholds.Value)
            {
                var thresholdReached = false;
                var wasReached = false;

                // Check if threshold is currently reached
                switch (_check)
                {
                    case ComparisonOperator.Equals:
                        thresholdReached = currentValue == threshold;
                        wasReached = _lastValue == threshold;
                        break;
                    case ComparisonOperator.GreaterThan:
                        thresholdReached = currentValue > threshold;
                        wasReached = _lastValue > threshold;
                        break;
                    case ComparisonOperator.GreaterThanOrEqual:
                        thresholdReached = currentValue >= threshold;
                        wasReached = _lastValue >= threshold;
                        break;
                    case ComparisonOperator.LessThan:
                        thresholdReached = currentValue < threshold;
                        wasReached = _lastValue < threshold;
                        break;
                    case ComparisonOperator.LessThanOrEqual:
                        thresholdReached = currentValue <= threshold;
                        wasReached = _lastValue <= threshold;
                        break;
                }

                // Send event only if threshold was just reached (first time)
                if (thresholdReached && !wasReached)
                {
                    SendEvent(_sendEvent);
                    break; // Only send event once per value change
                }
            }

            _lastValue = currentValue;
        }
        
        public override string GetSummary()
        {
            var checkText = _check switch
            {
                ComparisonOperator.Equals => "equals",
                ComparisonOperator.GreaterThan => ">",
                ComparisonOperator.GreaterThanOrEqual => ">=",
                ComparisonOperator.LessThan => "<",
                ComparisonOperator.LessThanOrEqual => "<=",
                _ => "?"
            };
            
            return "When {_integer} " + checkText + " {_thresholds} {_sendEvent}";
        }

    }
}