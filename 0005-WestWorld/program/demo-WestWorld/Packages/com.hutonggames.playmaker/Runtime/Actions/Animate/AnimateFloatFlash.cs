using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a Flash function.")]
    public class AnimateFloatFlash : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "Flash";
        public override float Evaluate(float t) => AnimationFunctions.Flash(t);
    }
}