using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(TilemapMinimap))]
    public sealed class TilemapMinimapVariable : Variable<TilemapMinimap>
    {
        public TilemapMinimapVariable()
        {
        }

        public TilemapMinimapVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(TilemapMinimap))]
    public sealed class TilemapMinimapVar : VariableVar<TilemapMinimap>
    {
    }

    [Serializable]
    [DataType(typeof(TilemapMinimap))]
    public sealed class TilemapMinimapRef : VariableRef<TilemapMinimap>
    {
    }
}
