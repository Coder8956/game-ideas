using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for blink-style effects (on/off pattern).
    /// Derived actions implement Apply(on) for a specific target type.
    /// </summary>
    [Serializable, PublicAPI]
    [ActionCategory(Category.Blink)]
    public abstract class BaseBlinkAction : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        [DefaultValue(0.5f)]
        [Tooltip("How long the target stays ON in seconds.")]
        public FloatVar OnDuration;

        [DefaultValue(0.5f)]
        [Tooltip("How long the target stays OFF in seconds.")]
        public FloatVar OffDuration;

        [Tooltip("Use unscaled realtime.")]
        [FormerlySerializedAs("IgnoreTimeScale")]
        public BoolVar UseRealtime;

        [DefaultValue(false)]
        [Tooltip("Restore the target to its original state when exiting the state.")]
        public BoolVar RestoreOnExit;

        [OptionalField, WriteOnly]
        [Tooltip("Optionally store the current ON state. " +
                 "\nUse this to sync other effects with this effect.")]
        public BoolRef IsOn;

        private float _nextTime;
        private bool _on;

        public override void OnStart()
        {
            CaptureOriginalState();

            _on = true;
            _nextTime = NextDuration(_on);

            StoreIsOn(_on);
            Apply(_on);
        }

        public override void OnStop()
        {
            if (RestoreOnExit.Value)
                RestoreOriginalState();
        }

        public override void Execute()
        {
            _nextTime -= UseRealtime.Value ? Time.unscaledDeltaTime : Time.deltaTime;
            if (_nextTime > 0f) return;

            _on = !_on;

            // Preserve overshoot so the cadence stays stable with low FPS.
            _nextTime += NextDuration(_on);

            StoreIsOn(_on);
            Apply(_on);
        }

        private float NextDuration(bool on)
        {
            const float epsilon = 0.0001f;
            var d = on ? OnDuration.Value : OffDuration.Value;
            return Mathf.Max(epsilon, d);
        }

        private void StoreIsOn(bool value)
        {
            if (IsOn.IsAssigned)
                IsOn.Value = value;
        }

        /// <summary>Implement per-target enable/disable.</summary>
        protected abstract void Apply(bool on);

        protected virtual void CaptureOriginalState() { }

        protected virtual void RestoreOriginalState() { }

        protected virtual string Target => "Target";
        
        public override string GetSummary() =>
            "Blink {" + Target + "} On {OnDuration} Off {OffDuration} {UseRealtime:option} {RestoreOnExit:option} {IsOn:output}";
    }
}
