using System;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for action blocks that generate candidate spawn positions.
    /// </summary>
    [Serializable]
    public abstract class SpawnPositionGeneratorBlock : BaseActionBlock
    {
        public abstract void Generate(FindValidRandomPosition action);
    }
}
