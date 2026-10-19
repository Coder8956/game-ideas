using System;
using JetBrains.Annotations;
using UnityEngine;
using HutongGames.PlayMaker.UI;

namespace HutongGames.PlayMaker.Actions.UI
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.MeterLabel)]
    [ActionDescription("Set min, max, and current value on a MeterLabel widget.")]
    [HelpURL("guides/ui-widgets/meters/meter-label/")]
    public sealed class MeterLabelSetValues : BaseAction
    {
        [Tooltip("The MeterLabel widget to update.")]
        [SerializeField] private MeterLabelVar _label;

        [Tooltip("Minimum value that maps to normalized = 0.")]
        [SerializeField] private FloatVar _minValue;

        [Tooltip("Maximum value that maps to normalized = 1 and 100%.")]
        [SerializeField] private FloatVar _maxValue;

        [Tooltip("Current value to show in the label.")]
        [SerializeField] private FloatVar _value;

        public override bool CanExecute() => CheckParameters(_label, _minValue, _maxValue, _value);

        public override void Execute()
        {
            var label = _label.Value;
            if (!label)
                return;

            label.SetRangeAndValue(_minValue.Value, _maxValue.Value, _value.Value);
        }

        public override string GetSummary() => "Set {_label} min {_minValue}, max {_maxValue}, value {_value}";
    }
}
