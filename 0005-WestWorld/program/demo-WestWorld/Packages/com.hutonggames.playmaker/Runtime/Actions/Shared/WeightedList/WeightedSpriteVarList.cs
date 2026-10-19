using System;
using HutongGames.PlayMaker.Actions;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedSpriteVarList : WeightedList<SpriteVar, WeightedSpriteVarListItem> { }

    [Serializable]
    public class WeightedSpriteVarListItem : WeightedListItem<SpriteVar> { }
}
