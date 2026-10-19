using System;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for action blocks that modify candidate 2D spawn positions.
    /// </summary>
    [Serializable]
    public abstract class SpawnPositionModifierBlock2D : BaseActionBlock
    {
        public abstract bool ModifyCandidate(FindValidRandomPosition2D action);
    }
}
