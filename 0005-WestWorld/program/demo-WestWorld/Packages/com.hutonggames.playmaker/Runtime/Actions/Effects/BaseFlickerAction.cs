using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for flicker-style effects (random on/off at a fixed frequency).
    /// </summary>
    [Serializable, PublicAPI]
    public abstract class BaseFlickerAction : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        [DefaultValue(0.1f)]
        [Tooltip("How often to evaluate the flicker state in seconds.")]
        public FloatVar Frequency;

        [VarSlider(0f, 1f)]
        [DefaultValue(0.5f)]
        [Tooltip("Chance the target will be ON each tick (0-1). E.g. 0.95 for occasional flicker.")]
        public FloatVar AmountOn;

        [Tooltip("Use unscaled realtime.")]
        [FormerlySerializedAs("IgnoreTimeScale")]
        public BoolVar UseRealtime;

        [DefaultValue(false)]
        [Tooltip("Restore the target to its original state when exiting the state.")]
        public BoolVar RestoreOnExit;

        [OptionalField, WriteOnly]
        [Tooltip("Optionally store the current ON state." +
                 "\nUse this to sync other effects with this effect.")]
        public BoolRef IsOn;

        private float _timer;

        public override void OnStart()
        {
            CaptureOriginalState();
            _timer = 0f;
        }

        public override void OnStop()
        {
            if (RestoreOnExit.Value)
                RestoreOriginalState();
        }

        public override void Execute()
        {
            var dt = UseRealtime.Value ? Time.unscaledDeltaTime : Time.deltaTime;
            _timer += dt;

            // Guard against zero/negative (and avoid a tight loop).
            var freq = Mathf.Max(0.0001f, Frequency.Value);

            if (_timer < freq) return;

            // Advance by whole ticks; apply only the final state once.
            // Cap the number of ticks processed in one frame to avoid worst-case stalls.
            const int maxTicksPerFrame = 32;

            var ticks = Mathf.Min((int)(_timer / freq), maxTicksPerFrame);
            _timer -= ticks * freq;

            var chanceOn = Mathf.Clamp01(AmountOn.Value);

            bool on = false;
            for (var i = 0; i < ticks; i++)
                on = Random.value < chanceOn;

            StoreIsOn(on);
            Apply(on);
        }

        private void StoreIsOn(bool value)
        {
            if (IsOn.IsAssigned)
                IsOn.Value = value;
        }

        protected abstract void Apply(bool on);

        protected virtual void CaptureOriginalState() { }

        protected virtual void RestoreOriginalState() { }

        protected virtual string Target => "Target";
        
        public override string GetSummary() =>
            "Flicker {" + Target + "} Freq {Frequency} On {AmountOn} {UseRealtime:option} {IsOn:output}";
    }
}
