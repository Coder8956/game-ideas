using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a Square Wave function.")]
    public class AnimateFloatSquareWave : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "Square Wave";
        public override float Evaluate(float t) => AnimationFunctions.SquareWave(t);
    }
}