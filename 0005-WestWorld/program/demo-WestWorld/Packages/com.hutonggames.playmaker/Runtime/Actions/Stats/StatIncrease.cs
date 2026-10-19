using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Stat)]
    [ActionDescription("Increase a stat and optionally send an event when it reaches or crosses a threshold.")]
    [HelpURL("actions/stat-actions/stat-increase/")]
    public sealed class StatIncrease : BaseAction
    {
        [ActionTarget, WriteOnly, AllowWriteConversion]
        [SerializeField]
        [Tooltip("The stat value to increase.")]
        private FloatRef _value;

        [SerializeField]
        [Tooltip("Amount to add to the stat." + Strings.PerSecondNote)]
        private FloatVar _amount;

        [SerializeField, OptionalField]
        [Tooltip("Threshold value used only if an event is assigned.")]
        private FloatVar _threshold;

        [SerializeField, OptionalField]
        [Tooltip("Event sent when the stat reaches or crosses the threshold this frame.")]
        private EventRef _onThreshold;

        [SerializeField, OptionalField, WriteOnly]
        [Tooltip("Store true if the stat is >= threshold after applying the increase.")]
        private BoolRef _storeReached;

        public override bool CanUsePerSecond => true;

        public override bool CanExecute() => CheckParameters(_value, _amount);

        public override void Execute()
        {
            var amount   = _amount.Value * PerSecond;
            var oldValue = _value.Value;
            var newValue = oldValue + amount;

            // Only evaluate threshold if an event is set
            if (_onThreshold.IsSet)
            {
                var threshold = _threshold.Value;

                // Fire event on upward crossing: old < t <= new
                if (oldValue < threshold && newValue >= threshold)
                    SendEvent(_onThreshold);

                if (_storeReached.IsAssigned)
                    _storeReached.Value = newValue >= threshold;
            }

            _value.Value = newValue;
        }

        public override string GetSummary() =>
            "{_value} += {_amount} {PerSecond}" +
            (_onThreshold.IsSet ? " If >= {_threshold}: {_onThreshold}" : "");
    }
}
