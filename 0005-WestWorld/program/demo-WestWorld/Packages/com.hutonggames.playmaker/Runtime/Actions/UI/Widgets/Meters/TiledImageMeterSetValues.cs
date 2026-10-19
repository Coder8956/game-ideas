using System;
using JetBrains.Annotations;
using UnityEngine;
using HutongGames.PlayMaker.UI;

namespace HutongGames.PlayMaker.Actions.UI
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.TiledImageMeter)]
    [ActionDescription("Set value, value-per-icon, and max-icons on a TiledImageMeter widget.")]
    [HelpURL("guides/ui-widgets/meters/tiled-image-meter/")]
    public sealed class TiledImageMeterSetValues : BaseAction
    {
        [Tooltip("The TiledImageMeter widget to update.")]
        [SerializeField] private TiledImageMeterVar _meter;

        [Tooltip("Current value to visualize (e.g., hearts, lives, ammo).")]
        [SerializeField] private FloatVar _value;

        [Tooltip("Value represented by one icon (e.g., 1 HP per heart, or 0.5 for half-hearts).")]
        [SerializeField] private FloatVar _valuePerIcon;

        [Tooltip("Maximum number of icons to show (0 = unlimited).")]
        [SerializeField] private IntegerVar _maxIcons;

        public override bool CanExecute() => CheckParameters(_meter, _value, _valuePerIcon, _maxIcons);

        public override void Execute()
        {
            var meter = _meter.Value;
            if (!meter)
                return;

            meter.SetValues(_value.Value, _valuePerIcon.Value, _maxIcons.Value);
        }

        public override string GetSummary() =>
            "Set {_meter} value {_value}, value/icon {_valuePerIcon}, max icons {_maxIcons}";
    }
}
