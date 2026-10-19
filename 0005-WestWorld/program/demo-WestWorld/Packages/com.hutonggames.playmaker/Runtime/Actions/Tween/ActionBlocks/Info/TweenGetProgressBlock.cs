using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Get Progress")]
    public class TweenGetProgressBlock : TweenInfoBlock
    {
        [Tooltip("Get the normalized time elapsed." +
                 "\n0 at the start of the tween, 1 at the end.")]
        public FloatRef GetProgress;

        public override void Execute()
        {
            GetProgress.Value = Action.Progress;
        }
    }
}