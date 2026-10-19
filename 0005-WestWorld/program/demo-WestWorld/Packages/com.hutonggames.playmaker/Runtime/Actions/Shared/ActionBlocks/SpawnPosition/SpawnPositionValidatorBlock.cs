using System;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for action blocks that validate candidate spawn positions.
    /// </summary>
    [Serializable]
    public abstract class SpawnPositionValidatorBlock : BaseActionBlock
    {
        public abstract bool IsValidPosition(FindValidRandomPosition action);
    }
}
