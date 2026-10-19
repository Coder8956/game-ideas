using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for fade-style effects (one-shot over a duration).
    /// Derived actions implement Apply(normalized) for a specific target type.
    /// </summary>
    [Serializable, PublicAPI]
    public abstract class BaseFadeAction : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
        public override bool CanFinish => true;

        [DefaultValue(0.5f)]
        [Tooltip("How long the fade takes in seconds.")]
        public FloatVar Duration;

        [Tooltip("Use unscaled realtime.")]
        [FormerlySerializedAs("IgnoreTimeScale")]
        public BoolVar UseRealtime;

        [OptionalField, WriteOnly]
        [Tooltip("Optionally store the normalized fade progress (0-1)." +
                 "\nUse this to sync other effects with this effect.")]
        public FloatRef _Progress;

        [OptionalField]
        [Tooltip("Event to send when the fade ends.")]
        public EventRef FinishedEvent;
        
        private float _elapsed;
        private bool _done;

        public override void OnStart()
        {
            _elapsed = 0f;
            _done = false;

            StoreProgress(0f);
            Apply(0f);
        }

        public override void Execute()
        {
            if (_done) return;

            var dt = UseRealtime.Value ? Time.unscaledDeltaTime : Time.deltaTime;
            _elapsed += dt;

            var dur = Mathf.Max(0.0001f, Duration.Value);
            var t = Mathf.Clamp01(_elapsed / dur);

            StoreProgress(t);
            Apply(t);

            if (t >= 1f)
            {
                _done = true;
                SendEvent(FinishedEvent);
                Finish();
            }
        }

        private void StoreProgress(float value)
        {
            Progress = value;
            if (_Progress.IsAssigned)
            {
                _Progress.Value = value;
            }
        }

        /// <summary>Apply the effect at normalized progress (0-1).</summary>
        protected abstract void Apply(float t);

        protected string GetFadeInSummary(string target = "Target") =>
            "Fade in {" + target + "} over {Duration} {UseRealtime:option} {Progress:output}";
        
        protected string GetFadeOutSummary(string target = "Target") =>
            "Fade out {" + target + "} over {Duration} {UseRealtime:option} {Progress:output}";
    }
}
