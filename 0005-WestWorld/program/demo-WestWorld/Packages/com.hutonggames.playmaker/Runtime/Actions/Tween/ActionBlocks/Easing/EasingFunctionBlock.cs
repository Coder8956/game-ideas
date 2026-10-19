using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayOrder(-1)]
    [Tooltip("Common easing functions for tweens.")]
    public class EasingFunctionBlock : TweenEasingBlock
    {
        [EaseCurve]
        [Tooltip("Choose an easing function.")]
        public EasingFunctionVar EasingFunction;

        public override bool CanExecute() => EasingFunction.HasValue();

        public override float Evaluate(float atNormalizedTime)
        {
            return HutongGames.PlayMaker.EasingFunction.Evaluate(EasingFunction.Value, atNormalizedTime);
        }

        public override string GetSummary() => "{EasingFunction}";
    }
}