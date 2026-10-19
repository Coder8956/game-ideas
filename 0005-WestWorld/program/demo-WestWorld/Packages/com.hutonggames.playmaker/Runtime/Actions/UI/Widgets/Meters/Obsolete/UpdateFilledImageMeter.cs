using System;
using JetBrains.Annotations;
using UnityEngine;
using HutongGames.PlayMaker.UI;

namespace HutongGames.PlayMaker.Actions.UI
{
    [Obsolete("Use FilledImageMeterUpdate instead.")]
    [Serializable, PublicAPI]
    [ActionCategory(Category.FilledImageMeter)]
    [ActionDescription("Update a FilledImageMeter widget.")]
    [HelpURL("guides/ui-widgets/meters/filled-image-meter/")]
    public sealed class UpdateFilledImageMeter : BaseAction
    {
        [Tooltip("The FilledImageMeter widget to update.")]
        [SerializeField] private FilledImageMeterVar _meter;

        [Tooltip("Value to visualize (e.g., health, mana, progress).")]
        [SerializeField] private FloatVar _value;

        //public override bool CanExecute() => CheckParameters(_meter, _value);

        public override void Execute()
        {
            var meter = _meter.Value;
            if (!meter)
                return;

            meter.SetValue(_value.Value);
        }

        public override string GetSummary() => "Update {_meter} from {_value}";
    }
}
