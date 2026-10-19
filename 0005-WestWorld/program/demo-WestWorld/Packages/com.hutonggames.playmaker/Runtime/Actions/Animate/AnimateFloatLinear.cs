using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a Linear function.")]
    public class AnimateFloatLinear : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "";
        public override float Evaluate(float t) => AnimationFunctions.Linear(t);
    }
}