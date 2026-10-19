using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a Breathe function.")]
    public class AnimateFloatBreathe : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "Breathe";
        public override float Evaluate(float t) => AnimationFunctions.Breathe(t);
    }
}