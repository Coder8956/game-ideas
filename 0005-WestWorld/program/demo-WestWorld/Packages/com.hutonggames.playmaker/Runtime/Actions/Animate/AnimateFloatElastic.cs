using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using an Elastic function.")]
    public class AnimateFloatElastic : BaseFloatAnimationFunctionAction, IHasGraphPreview
    { 
        protected override string AnimationName => "Elastic";
        public float MaxY => 2; // for graph preview
        public override float Evaluate(float t) => AnimationFunctions.Elastic(t);
    }
}