using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.LogicEvent)]
    [ActionDescription("Sends an event when a float variable reaches a given threshold. " +
                       "Only sends the event when the threshold condition becomes true (edge trigger).")]
    public sealed class FloatThresholdEvent : BaseAction
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

        [Tooltip("The float to check.")]
        [SerializeField]
        private FloatRef _float;

        [Tooltip("The check to perform.")]
        [SerializeField]
        private ComparisonOperator _check;

        [Tooltip("Thresholds to check against.")]
        [SerializeField]
        private FloatListVar _thresholds;

        [FormerlySerializedAs("_event")]
        [Tooltip("The event to send when a threshold is reached.")]
        [SerializeField]
        private EventRef _sendEvent;

        private float _lastValue;

        public override bool CanExecute() => CheckParameters(_float, _thresholds, _sendEvent);

        public override void OnStart()
        {
            _lastValue = _float.Value;
            _float.Variable.ValueChanged += OnValueChanged;
        }

        public override void OnStop()
        {
            if (_float?.Variable == null) return;
            _float.Variable.ValueChanged -= OnValueChanged;
        }

        private void OnValueChanged()
        {
            var currentValue = _float.Value;

            foreach (var threshold in _thresholds.Value)
            {
                var thresholdReached = false;
                var wasReached = false;

                switch (_check)
                {
                    case ComparisonOperator.Equals:
                        thresholdReached = Mathf.Approximately(currentValue, threshold);
                        wasReached = Mathf.Approximately(_lastValue, threshold);
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

            return "When {_float} " + checkText + " {_thresholds} {_sendEvent}";
        }
    }
}
