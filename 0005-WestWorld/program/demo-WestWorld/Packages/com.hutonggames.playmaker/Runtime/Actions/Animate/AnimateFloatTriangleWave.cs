using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a Trangle Wave function.")]
    public class AnimateFloatTriangleWave : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "Triangle Wave";
        public override float Evaluate(float t) => AnimationFunctions.TriangleWave(t);
    }
}