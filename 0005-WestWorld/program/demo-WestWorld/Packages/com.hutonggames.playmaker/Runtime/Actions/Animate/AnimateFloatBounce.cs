using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a Bounce function.")]
    public class AnimateFloatBounce : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "Bounce";
        public override float Evaluate(float t) => AnimationFunctions.Bounce(t);
    }
}