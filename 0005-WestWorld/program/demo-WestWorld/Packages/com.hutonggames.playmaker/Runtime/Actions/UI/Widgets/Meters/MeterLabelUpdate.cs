using System;
using JetBrains.Annotations;
using UnityEngine;
using HutongGames.PlayMaker.UI;

namespace HutongGames.PlayMaker.Actions.UI
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.MeterLabel)]
    [ActionDescription("Update a MeterLabel widget.")]
    [HelpURL("guides/ui-widgets/meters/meter-label/")]
    public sealed class MeterLabelUpdate : BaseAction
    {
        [Tooltip("The MeterLabel widget to update.")]
        [SerializeField] private MeterLabelVar _label;

        [Tooltip("Value to show in the label (e.g., health, progress, score).")]
        [SerializeField, DefaultValue(0f)] private FloatVar _value;

        public override bool CanExecute() => CheckParameters(_label, _value);

        public override void Execute()
        {
            var label = _label.Value;
            if (!label)
                return;

            label.SetValue(_value.Value);
        }

        public override string GetSummary() => "Update {_label} to {_value}";
    }
}
