using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using an ExponentialIn function.")]
    public class AnimateFloatExponentialIn : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "ExpIn";
        public override float Evaluate(float t) => AnimationFunctions.ExponentialIn(t);
    }
}