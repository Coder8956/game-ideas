using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a Spring function.")]
    public class AnimateFloatSpring : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "Spring";
        public float MaxY => 2; // for graph preview
        public override float Evaluate(float t) => AnimationFunctions.Spring(t);
    }
}