using System;
using HutongGames.PlayMaker.Actions;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedTileBaseVarList : WeightedList<TileBaseVar, WeightedTileBaseVarListItem> { }

    [Serializable]
    public class WeightedTileBaseVarListItem : WeightedListItem<TileBaseVar> { }
}
