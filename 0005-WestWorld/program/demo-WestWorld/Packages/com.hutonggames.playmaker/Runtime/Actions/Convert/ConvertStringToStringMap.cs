using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a String to another String by mapping it through ordered match rules.\n" +
                       "Rules are evaluated top-to-bottom; the first match wins.")]
    public sealed class ConvertStringToStringMap : BaseAction
    {
        [Serializable]
        public sealed class Rule
        {
            [Tooltip("String to compare against.")]
            [SerializeField]
            public StringVar Match;

            [Tooltip("String to output when this rule matches.")]
            [SerializeField]
            public StringVar Value;

            public Rule() { }

            public Rule(string match, string value)
            {
                Match = new StringVar();
                Match.SetValue(match);

                Value = new StringVar();
                Value.SetValue(value);
            }
        }

        [ActionTarget]
        [Tooltip("The string value to map.")]
        [SerializeField]
        private StringRef _sourceString;

        [Tooltip("How to compare the input string to each rule.")]
        [SerializeField, DefaultValue(StringComparisonOperation.Equals)]
        private StringComparisonOperation _check;

        [Tooltip("Rules evaluated in order (first match wins).")]
        [SerializeField]
        private List<Rule> _rules = new();

        [Tooltip("Value to use if no rules match.")]
        [SerializeField]
        private StringVar _defaultValue;

        [Tooltip("Store the mapped String value.")]
        [SerializeField, WriteOnly]
        private StringRef _string;

        public override bool CanExecute() => CheckParameters(_sourceString, _defaultValue, _string);

        public override void Reset()
        {
            base.Reset();

            _check = StringComparisonOperation.Equals;

            _defaultValue ??= VariableFactory.CreateVariableVar(typeof(StringVar)) as StringVar;
            _defaultValue?.SetValue("Unknown");

            _rules ??= new List<Rule>();
            _rules.Clear();
        }

        public override void Execute()
        {
            var value = _sourceString.Value;

            foreach (var rule in _rules)
            {
                if (rule == null) continue;

                var matchVar = rule.Match;
                var valueVar = rule.Value;
                if (matchVar == null || valueVar == null) continue;

                if (!_check.Evaluate(value, matchVar.Value)) continue;

                _string.Value = valueVar.Value;
                return;
            }

            _string.Value = _defaultValue.Value;
        }

        public override string GetSummary() => "Map {_sourceString} -> {_string}";
    }
}
