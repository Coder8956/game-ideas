using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a Pulse function.")]
    [MovedFrom(true, null, null, "FloatPulse")]
    public class AnimateFloatPulse : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "Pulse";
        public override float Evaluate(float t) => AnimationFunctions.Pulse(t);
    }
}