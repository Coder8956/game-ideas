using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a Float to a String by mapping it through threshold rules.\n" +
                       "Rules are evaluated top-to-bottom; the first match wins.")]
    public sealed class ConvertFloatToStringMap : BaseAction
    {
        public enum ComparisonOperator
        {
            Equals,
            GreaterThan,
            GreaterThanOrEqual,
            LessThan,
            LessThanOrEqual,
        }

        [Serializable]
        public sealed class Rule
        {
            [Tooltip("Threshold to compare against.")]
            [SerializeField]
            public FloatVar Threshold;

            [Tooltip("String to output when this rule matches.")]
            [SerializeField]
            public StringVar Value;

            public Rule() { }

            public Rule(float threshold, string value)
            {
                Threshold = new FloatVar();
                Threshold.SetValue(threshold);

                Value = new StringVar();
                Value.SetValue(value);
            }
        }

        [ActionTarget]
        [Tooltip("The float value to map.")]
        [SerializeField]
        private FloatRef _float;

        [Tooltip("How to compare the float value to each rule threshold.")]
        [SerializeField, DefaultValue(ComparisonOperator.LessThanOrEqual)]
        private ComparisonOperator _check;

        [Tooltip("Rules evaluated in order (first match wins).")]
        [SerializeField]
        private List<Rule> _rules = new();

        [Tooltip("Value to use if no rules match.")]
        [SerializeField]
        private StringVar _defaultValue;

        [Tooltip("Store the mapped String value.")]
        [SerializeField, WriteOnly]
        private StringRef _string;

        public override bool CanExecute() => CheckParameters(_float, _defaultValue, _string);

        public override void Reset()
        {
            base.Reset();

            _check = ComparisonOperator.LessThanOrEqual;

            _defaultValue ??= VariableFactory.CreateVariableVar(typeof(StringVar)) as StringVar;
            _defaultValue.SetValue("Far Away");

            _rules ??= new List<Rule>();
            _rules.Clear();

            // Example defaults (distance labels)
            _rules.Add(new Rule(0.25f, "Arrived!"));
            _rules.Add(new Rule(1f, "Almost there"));
            _rules.Add(new Rule(5f, "Close"));
        }

        public override void Execute()
        {
            var value = _float.Value;

            foreach (var rule in _rules)
            {
                if (rule == null) continue;

                var thresholdVar = rule.Threshold;
                var valueVar = rule.Value;
                if (thresholdVar == null || valueVar == null) continue;

                var threshold = thresholdVar.Value;

                if (Matches(value, threshold))
                {
                    _string.Value = valueVar.Value;
                    return;
                }
            }

            _string.Value = _defaultValue.Value;
        }

        private bool Matches(float value, float threshold)
        {
            switch (_check)
            {
                case ComparisonOperator.Equals:
                    return Mathf.Approximately(value,threshold);
                case ComparisonOperator.GreaterThan:
                    return value > threshold;
                case ComparisonOperator.GreaterThanOrEqual:
                    return value >= threshold;
                case ComparisonOperator.LessThan:
                    return value < threshold;
                case ComparisonOperator.LessThanOrEqual:
                    return value <= threshold;
                default:
                    return false;
            }
        }

        public override string GetSummary() => "Map {_float} -> {_string}";
    }
}
