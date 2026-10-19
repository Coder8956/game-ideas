using System;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public class TweenActionBlock : BaseActionBlock
    {
        protected BaseTweenAction TweenAction => Action as BaseTweenAction;
    }
}