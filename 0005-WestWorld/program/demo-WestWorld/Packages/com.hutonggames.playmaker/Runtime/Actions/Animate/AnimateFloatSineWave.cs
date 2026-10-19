using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a Sine Wave function." +
                       "\n\nUseful for bobbing or floaty style animations.")]
    public class AnimateFloatSineWave : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "Sine Wave";
        public override float Evaluate(float t) => AnimationFunctions.SineWave(t);
    }
}