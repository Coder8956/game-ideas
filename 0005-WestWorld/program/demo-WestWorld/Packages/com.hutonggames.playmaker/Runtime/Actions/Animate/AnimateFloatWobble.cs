using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a Wobble function.")]
    public class AnimateFloatWobble : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "Wobble";
        public override float Evaluate(float t) => AnimationFunctions.Wobble(t);
    }
}