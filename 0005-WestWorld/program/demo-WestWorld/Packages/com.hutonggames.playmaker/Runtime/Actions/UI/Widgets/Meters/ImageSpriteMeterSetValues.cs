using System;
using HutongGames.PlayMaker.UI;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.UI
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.ImageSpriteMeter)]
    [ActionDescription("Set min, max, and current value on an ImageSpriteMeter widget.")]
    [HelpURL("guides/ui-widgets/meters/image-sprite-meter/")]
    public sealed class ImageSpriteMeterSetValues : BaseAction
    {
        [Tooltip("The ImageSpriteMeter widget to update.")]
        [SerializeField] private ImageSpriteMeterVar _meter;

        [Tooltip("Minimum value that maps to an empty meter.")]
        [SerializeField] private FloatVar _minValue;

        [Tooltip("Maximum value that maps to a full meter.")]
        [SerializeField] private FloatVar _maxValue;

        [Tooltip("Current value to visualize.")]
        [SerializeField] private FloatVar _value;

        public override bool CanExecute() => CheckParameters(_meter, _minValue, _maxValue, _value);

        public override void Execute()
        {
            var meter = _meter.Value;
            if (!meter)
                return;

            meter.SetRangeAndValue(_minValue.Value, _maxValue.Value, _value.Value);
        }

        public override string GetSummary() => "Set {_meter} min {_minValue}, max {_maxValue}, value {_value}";
    }
}
