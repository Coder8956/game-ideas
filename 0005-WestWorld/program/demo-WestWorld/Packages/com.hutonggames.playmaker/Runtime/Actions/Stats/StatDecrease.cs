using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Stat)]
    [ActionDescription("Decrease a stat, clamp it to zero, and optionally send an event when it reaches zero.")]
    [HelpURL("actions/stat-actions/stat-decrease/")]
    public sealed class StatDecrease : BaseAction
    {
        [ActionTarget, WriteOnly, AllowWriteConversion]
        [SerializeField]
        [Tooltip("The stat value to decrease.")]
        private FloatRef _value;

        [SerializeField]
        [Tooltip("Amount to subtract from the stat." + Strings.PerSecondNote)]
        private FloatVar _amount;

        [SerializeField, OptionalField]
        [Tooltip("Event sent when the stat reaches zero this frame.")]
        private EventRef _onZero;

        [SerializeField, OptionalField, WriteOnly]
        [Tooltip("Store true if the stat is zero after applying the decrease.")]
        private BoolRef _storeIsZero;

        public override bool CanUsePerSecond => true;

        public override bool CanExecute() => CheckParameters(_value, _amount);

        public override void Execute()
        {
            var amount   = _amount.Value * PerSecond;
            var oldValue = _value.Value;
            var newValue = oldValue - amount;

            if (newValue <= 0f)
            {
                newValue = 0f;

                // Fire event only on *crossing* zero
                if (oldValue > 0f && _onZero.IsSet)
                    SendEvent(_onZero);
            }

            _value.Value = newValue;

            if (_storeIsZero.IsAssigned)
                _storeIsZero.Value = newValue <= 0f;
        }

        public override string GetSummary() =>
            "{_value} -= {_amount} {PerSecond}" +
            (_onZero.IsSet ? " If zero: {_onZero}" : "");
    }
}