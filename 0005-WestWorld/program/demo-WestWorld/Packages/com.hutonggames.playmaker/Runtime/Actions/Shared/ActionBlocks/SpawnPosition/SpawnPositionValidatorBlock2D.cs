using System;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for action blocks that validate candidate 2D spawn positions.
    /// </summary>
    [Serializable]
    public abstract class SpawnPositionValidatorBlock2D : BaseActionBlock
    {
        public abstract bool IsValidPosition(FindValidRandomPosition2D action);
    }
}
