using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.FxDriver)]
    [ActionDescription(
        "Drives a TrailRenderer from an input value.\n" +
        "Maps the input into 0–1 using InputMin/Max, then scales width, time,\n" +
        "emission, and optionally applies a color gradient with HDR boosting.")]
    public sealed class FxDriverTrailRenderer : BaseFxDriver
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        #region Trail

        [ActionHeader("Trail")]

        [Tooltip("The TrailRenderer to control.")]
        [SerializeField]
        private TrailRendererVar _trail;

        #endregion

        #region Width

        [ActionHeader("Width")]

        [Tooltip("Minimum trail width at normalized input 0.")]
        [SerializeField, DefaultValue(0.05f)]
        private FloatVar _minWidth;

        [Tooltip("Maximum trail width at normalized input 1.")]
        [SerializeField, DefaultValue(0.3f)]
        private FloatVar _maxWidth;

        #endregion

        #region Length

        [ActionHeader("Length")]

        [Tooltip("Minimum trail time (length) at normalized input 0.")]
        [SerializeField, DefaultValue(0.1f)]
        private FloatVar _minTime;

        [Tooltip("Maximum trail time (length) at normalized input 1.")]
        [SerializeField, DefaultValue(0.5f)]
        private FloatVar _maxTime;

        #endregion

        #region Emission

        [ActionHeader("Emission")]

        [Tooltip("Enable or disable trail emission based on normalized input.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _controlEmitting;

        [Tooltip("Normalized threshold above which the trail emits.")]
        [SerializeField, DefaultValue(0.05f)]
        private FloatVar _emittingThreshold;

        #endregion

        #region Color Gradient

        [ActionHeader("Color")]

        [Tooltip("If true, applies a gradient color based on the normalized input.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _useColorGradient;

        [Tooltip("Color gradient evaluated at normalized input 0–1.")] [SerializeField]
        private GradientVar _colorGradient;

        [Tooltip("HDR boost multiplier at normalized input 1.\n" +
                 "1 = no extra boost. Values > 1 increase brightness for bloom-heavy trails.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _hdrMultiplier;

        #endregion

        public override bool CanExecute() =>
            base.CanExecute() && CheckParameters(_trail);

        public override void Execute()
        {
            var trail = _trail.Value;
            if (trail == null)
                return;

            var t = Mathf.Clamp01(GetInput01());

            // Width -----------------------------------------------------------
            var minWidth = Mathf.Max(_minWidth.Value, 0f);
            var maxWidth = Mathf.Max(_maxWidth.Value, minWidth);
            trail.widthMultiplier = Mathf.Lerp(minWidth, maxWidth, t);

            // Length ----------------------------------------------------------
            var minTime = Mathf.Max(_minTime.Value, 0f);
            var maxTime = Mathf.Max(_maxTime.Value, minTime);
            trail.time = Mathf.Lerp(minTime, maxTime, t);

            // Emission --------------------------------------------------------
            if (_controlEmitting.Value)
            {
                var threshold = Mathf.Clamp01(_emittingThreshold.Value);
                trail.emitting = t > threshold;
            }

            // Color + HDR -----------------------------------------------------
            if (_useColorGradient.Value && _colorGradient.HasValue())
            {
                var baseColor = _colorGradient.Value.Evaluate(t);

                var hdr   = Mathf.Max(_hdrMultiplier.Value, 1f);
                var boost = Mathf.Lerp(1f, hdr, t);
                var final = baseColor * boost;

                trail.startColor = final;
                trail.endColor   = final;
            }
        }

        public override string GetSummary() => "Drive {_trail} FX with {_input} ({_inputMin}-{_inputMax})";
    }
}
