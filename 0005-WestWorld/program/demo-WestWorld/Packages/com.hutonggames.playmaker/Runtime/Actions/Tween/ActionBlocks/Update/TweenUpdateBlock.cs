using System;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for blocks that update a Tween.
    /// The block needs to return Progress (a normalized time from 0-1),
    /// and determine if the tween finished or looped.
    /// </summary>
    [Serializable]
    public abstract class TweenUpdateBlock : TweenActionBlock
    {
        public bool Finished { get; protected set; }
        
        public abstract float GetProgress();
    }
}