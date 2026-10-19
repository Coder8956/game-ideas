using System;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for action blocks that modify candidate spawn positions.
    /// </summary>
    [Serializable]
    public abstract class SpawnPositionModifierBlock : BaseActionBlock
    {
        public abstract bool ModifyCandidate(FindValidRandomPosition action);
    }
}
