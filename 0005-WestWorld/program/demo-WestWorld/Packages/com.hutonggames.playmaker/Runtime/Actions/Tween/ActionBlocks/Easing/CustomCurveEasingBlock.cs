using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Custom Curve")]
    [Tooltip("Use a custom curve to control the tween.")]
    public class CustomCurveEasingBlock : TweenEasingBlock
    {
        [Tooltip("Custom curve to control the tween." +
                 "\nNormally the curve should start at 0 and end at 1.")]
        public AnimationCurveVar CustomCurve;

        public override bool IsValid => CustomCurve.HasValue();

        public override float Evaluate(float atNormalizedTime)
        {
            return CustomCurve.Value.Evaluate(atNormalizedTime);
        }

        public override string GetSummary() => "Custom Curve";
    }
}