using System;
using HutongGames.PlayMaker.UI;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.UI
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.ImageSpriteMeter)]
    [ActionDescription("Update an ImageSpriteMeter widget.")]
    [HelpURL("guides/ui-widgets/meters/image-sprite-meter/")]
    public sealed class ImageSpriteMeterUpdate : BaseAction
    {
        [Tooltip("The ImageSpriteMeter widget to update.")]
        [SerializeField] private ImageSpriteMeterVar _meter;

        [Tooltip("Value to visualize (e.g., health, mana, progress).")]
        [SerializeField] private FloatVar _value;

        public override bool CanExecute() => CheckParameters(_meter, _value);

        public override void Execute()
        {
            var meter = _meter.Value;
            if (!meter)
                return;

            meter.SetValue(_value.Value);
        }

        public override string GetSummary() => "Update {_meter} to {_value}";
    }
}
