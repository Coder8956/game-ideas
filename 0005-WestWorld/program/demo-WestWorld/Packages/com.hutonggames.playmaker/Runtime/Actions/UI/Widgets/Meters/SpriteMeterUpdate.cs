using System;
using JetBrains.Annotations;
using UnityEngine;
using HutongGames.PlayMaker.UI;

namespace HutongGames.PlayMaker.Actions.UI
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.SpriteMeter)]
    [ActionDescription("Update a SpriteMeter widget.")]
    [HelpURL("guides/ui-widgets/meters/sprite-meter/")]
    public sealed class SpriteMeterUpdate : BaseAction
    {
        [Tooltip("The SpriteMeter widget to update.")]
        [SerializeField] private SpriteMeterVar _meter;

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
