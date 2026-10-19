using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a TickTock function.")]
    [MovedFrom(true, null, null, "FloatTickTock")]
    public class AnimateFloatTickTock : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "TickTock";
        public override float Evaluate(float t) => AnimationFunctions.TickTock(t);
    }
}