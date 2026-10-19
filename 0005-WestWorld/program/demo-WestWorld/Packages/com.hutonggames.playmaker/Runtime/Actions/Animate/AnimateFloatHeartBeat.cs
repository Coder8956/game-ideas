using System;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames
{
    [Serializable]
    [ActionCategory(Category.AnimateVariables)]
    [ConvertibleGroup("AnimateFloat")]
    [ActionDescription("Animate a Float variable using a HeartBeat function.")]
    [MovedFrom(true, null, null, "FloatHeartBeat")]
    public class AnimateFloatHeartBeat : BaseFloatAnimationFunctionAction, IHasGraphPreview
    {
        protected override string AnimationName => "HeartBeat";
        public override float Evaluate(float t) => AnimationFunctions.HeartBeat(t);
    }
}