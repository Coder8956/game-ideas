using System;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public abstract class TweenEasingBlock : TweenActionBlock
    {
        public abstract float Evaluate(float atNormalizedTime);
    }
}