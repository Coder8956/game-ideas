using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert an Integer to a String by mapping it through threshold rules.\n" +
                       "Rules are evaluated top-to-bottom; the first match wins.")]
    public sealed class ConvertIntegerToStringMap : BaseAction
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
            public IntegerVar Threshold;

            [Tooltip("String to output when this rule matches.")]
            [SerializeField]
            public StringVar Value;

            public Rule() { }

            public Rule(int threshold, string value)
            {
                Threshold = new IntegerVar();
                Threshold.SetValue(threshold);

                Value = new StringVar();
                Value.SetValue(value);
            }
        }

        [ActionTarget]
        [Tooltip("The integer value to map.")]
        [SerializeField]
        private IntegerRef _integer;

        [Tooltip("How to compare the integer value to each rule threshold.")]
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

        public override bool CanExecute() => CheckParameters(_integer, _defaultValue, _string);

        public override void Reset()
        {
            base.Reset();

            _check = ComparisonOperator.LessThanOrEqual;

            _defaultValue ??= VariableFactory.CreateVariableVar(typeof(StringVar)) as StringVar;
            _defaultValue.SetValue("Unknown");

            _rules ??= new List<Rule>();
            _rules.Clear();

            // Example defaults (health-style bands)
            _rules.Add(new Rule(0, "Dead"));
            _rules.Add(new Rule(25, "Critical"));
            _rules.Add(new Rule(75, "Injured"));
            _rules.Add(new Rule(100, "Healthy"));
        }

        public override void Execute()
        {
            var value = _integer.Value;

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

        private bool Matches(int value, int threshold)
        {
            switch (_check)
            {
                case ComparisonOperator.Equals:
                    return value == threshold;
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

        public override string GetSummary() => "Map {_integer} -> {_string}";
    }
}
