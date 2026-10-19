using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.AnimationCurve)]
    [ActionDescription("Normalize X from a range, evaluate an AnimationCurve, then remap the curve result from Y Min to Y Max. " +
                      "Use this when the curve acts as a normalized profile and this action defines the output range.")]
    [System.Serializable]
    [HelpURL("https://docs.unity3d.com/ScriptReference/AnimationCurve.Evaluate.html")]
    public sealed class AnimationCurveEvaluateRange : BaseAction
    {
        [Tooltip("The AnimationCurve.")]
        [SerializeField]
        private AnimationCurveRef _animationCurve;

        [Tooltip("The input X value to normalize.")]
        [SerializeField]
        private FloatRef _x;

        [Tooltip("Minimum of the X range (mapped to 0).")]
        [SerializeField]
        private FloatVar _xMin;

        [Tooltip("Maximum of the X range (mapped to 1).")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _xMax;

        [Tooltip("Clamp normalized X to [0,1] before evaluating the curve.")]
        [SerializeField]
        private bool _clampNormalizedX = true;

        [Tooltip("Minimum of the output Y range after evaluating the curve.")]
        [SerializeField]
        private FloatVar _yMin;

        [Tooltip("Maximum of the output Y range after evaluating the curve.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _yMax;

        [Tooltip("Store the result in Float variable.")]
        [SerializeField]
        [WriteOnly]
        private FloatRef _result;

        public override bool CanExecute() =>
            CheckParameters(_animationCurve, _x, _xMin, _xMax, _yMin, _yMax, _result);

        public override void Execute()
        {
            var x = _x.Value;
            var xMin = _xMin.Value;
            var xMax = _xMax.Value;

            float t;
            if (Mathf.Approximately(xMax, xMin))
            {
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

            var curveValue = _animationCurve.Value.Evaluate(t);
            _result.Value = Mathf.LerpUnclamped(_yMin.Value, _yMax.Value, curveValue);
        }

        public override string GetSummary() =>
            "Evaluate {_animationCurve} x: {_x} in [{_xMin}, {_xMax}] y: {_yMin}..{_yMax} -> {_result}";
    }
}
