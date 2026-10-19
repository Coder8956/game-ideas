using System;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for action blocks that generate candidate 2D spawn positions.
    /// </summary>
    [Serializable]
    public abstract class SpawnPositionGeneratorBlock2D : BaseActionBlock
    {
        public abstract void Generate(FindValidRandomPosition2D action);
    }
}
