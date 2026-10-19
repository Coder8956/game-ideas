using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using an ExponentialOut function.")]
    public class AnimateFloatExponentialOut : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "ExpOut";
        public override float Evaluate(float t) => AnimationFunctions.ExponentialOut(t);
    }
}