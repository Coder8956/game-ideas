using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.AnimationCurve)]
    [ActionDescription("Normalize X from a range, evaluate an AnimationCurve, then multiply the curve result by Y Scale. " +
                      "Use this when the curve already defines the output shape and you only need a final multiplier.")]
    [System.Serializable]
    [HelpURL("https://docs.unity3d.com/ScriptReference/AnimationCurve.Evaluate.html")]
    public sealed class AnimationCurveEvaluateScaled : BaseAction
    {
        [Tooltip("The AnimationCurve.")]
        [SerializeField]
        private AnimationCurveRef _animationCurve;

        [Tooltip("The input X value to normalize (e.g., distance).")]
        [SerializeField]
        private FloatVar _x;

        [Tooltip("Minimum of the X range (mapped to 0).")]
        [SerializeField]
        private FloatVar _xMin;

        [Tooltip("Maximum of the X range (mapped to 1).")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _xMax;

        [Tooltip("Clamp normalized X to [0,1] before evaluating the curve.")]
        [SerializeField]
        private bool _clampNormalizedX = true;

        [Tooltip("Multiplier applied to the evaluated curve result. This scales the output, it does not define an output range.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _yScale;

        [Tooltip("Store the result in Float variable.")]
        [SerializeField]
        [WriteOnly]
        private FloatRef _result;

        public override bool CanExecute() =>
            CheckParameters(_animationCurve, _x, _xMin, _xMax, _yScale, _result);

        public override void Execute()
        {
            var x = _x.Value;
            var xMin = _xMin.Value;
            var xMax = _xMax.Value;

            float t;
            if (Mathf.Approximately(xMax, xMin))
            {
                // Avoid division by zero: default to start of curve
                t = 0f;
            }
            else
            {
                t = (x - xMin) / (xMax - xMin);
            }

            if (_clampNormalizedX)
            {
                t = Mathf.Clamp01(t);
            }

            var y = _animationCurve.Value.Evaluate(t);
            _result.Value = y * _yScale.Value;
        }

        public override string GetSummary() =>
            "Evaluate {_animationCurve} x: {_x} in [{_xMin}, {_xMax}] y: {_yScale} -> {_result}";
    }
}
