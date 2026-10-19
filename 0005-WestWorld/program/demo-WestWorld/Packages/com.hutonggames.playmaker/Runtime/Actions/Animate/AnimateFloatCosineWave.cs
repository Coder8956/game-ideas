using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a Cosine Wave function. " +
                       "\n\nUseful for bobbing or floaty style animations.")]
    public class AnimateFloatCosineWave : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "Cosine Wave";
        public override float Evaluate(float t) => AnimationFunctions.CosineWave(t);
    }
}