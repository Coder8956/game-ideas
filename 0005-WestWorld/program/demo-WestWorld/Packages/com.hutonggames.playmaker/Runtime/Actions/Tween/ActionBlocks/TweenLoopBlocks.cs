using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public class TweenLoopBlock : TweenActionBlock
    {
        [Tooltip("Determines if the tween should loop.")]
        public LoopMode LoopMode;
        
        [OptionalField, WriteOnly]
        [Tooltip("Get the number of times the Tween has looped.")]
        public IntegerRef GetLoopCount;
        
        public override void Execute()
        {
            GetLoopCount.Value = TweenAction.LoopCount;
        }

        public override string GetSummary() => LoopMode == LoopMode.None ? "once" : LoopMode.ToString();
    }
}