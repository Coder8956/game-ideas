using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Get Loop Count")]
    public class TweenGetLoopCountBlock : TweenInfoBlock
    {
        [Tooltip("Get the number of times the Tween has looped.")]
        public IntegerRef GetLoopCount;
        
        public override void Execute()
        {
            GetLoopCount.Value = TweenAction.LoopCount;
        }
    }
}