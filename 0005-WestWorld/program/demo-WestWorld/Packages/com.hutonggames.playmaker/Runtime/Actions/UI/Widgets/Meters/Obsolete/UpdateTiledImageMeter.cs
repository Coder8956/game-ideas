using System;
using JetBrains.Annotations;
using UnityEngine;
using HutongGames.PlayMaker.UI;

namespace HutongGames.PlayMaker.Actions.UI
{
    [Obsolete("Use TiledImageMeterUpdate instead.")]
    [Serializable, PublicAPI]
    [ActionCategory(Category.TiledImageMeter)]
    [ActionDescription("Update a TiledImageMeter widget.")]
    [HelpURL("guides/ui-widgets/meters/tiled-image-meter/")]
    public sealed class UpdateTiledImageMeter : BaseAction
    {
        [Tooltip("The TiledImageMeter widget to update.")]
        [SerializeField] private TiledImageMeterVar _meter;

        [Tooltip("Value to visualize (e.g., hearts, lives, ammo).")]
        [SerializeField] private FloatVar _value;

        public override bool CanExecute() => CheckParameters(_meter, _value);

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
