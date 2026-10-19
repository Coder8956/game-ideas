using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.FxDriver)]
    [ActionDescription(
        "Drives a Light from an input value.\n" +
        "Maps the input into 0–1 using InputMin/Max, then scales intensity\n" +
        "and optionally applies a color gradient with HDR boosting.")]
    public sealed class FxDriverLight : BaseFxDriver
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        #region Light

        [ActionHeader("Light")]

        [Tooltip("The Light to drive.")]
        [SerializeField]
        private LightVar _light;

        #endregion

        #region Intensity Scaling

        [ActionHeader("Intensity")]

        [Tooltip("Light intensity at input 0 (mapped to 0).")]
        [SerializeField, DefaultValue(0f)]
        private FloatVar _minIntensity;

        [Tooltip("Light intensity at input 1 (mapped to 1).")]
        [SerializeField, DefaultValue(2f)]
        private FloatVar _maxIntensity;

        #endregion

        #region Color Gradient

        [ActionHeader("Color")]

        [Tooltip("If true, applies a gradient color based on the normalized input.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _useColorGradient;

        [Tooltip("Color gradient evaluated at normalized input 0–1.")] [SerializeField]
        private GradientVar _colorGradient;

        [Tooltip("HDR boost multiplier at normalized input 1.\n" +
                 "1 = no extra boost. Values > 1 increase brightness for bloom-heavy lights.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _hdrMultiplier;

        #endregion

        public override bool CanExecute() =>
            base.CanExecute() && CheckParameters(_light);

        public override void Execute()
        {
            var light = _light.Value;
            if (light == null)
                return;

            // 0–1 from raw input using InputMin/Max
            var t = Mathf.Clamp01(GetInput01());

            // Intensity -------------------------------------------------------
            var min = Mathf.Max(_minIntensity.Value, 0f);
            var max = Mathf.Max(_maxIntensity.Value, min);

            light.intensity = Mathf.Lerp(min, max, t);

            // Color + HDR -----------------------------------------------------
            if (_useColorGradient.Value && _colorGradient.HasValue())
            {
                var baseColor = _colorGradient.Value.Evaluate(t);

                // Lerp HDR multiplier from 1 → hdrMultiplier with input
                var hdr   = Mathf.Max(_hdrMultiplier.Value, 1f);
                var boost = Mathf.Lerp(1f, hdr, t);
                var final = baseColor * boost;

                light.color = final;
            }
        }

        public override string GetSummary() => "Drive {_light} FX with {_input} ({_inputMin}-{_inputMax})";
    }
}
