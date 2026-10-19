using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedGameObjectVarList : WeightedList<GameObjectVar, WeightedGameObjectVarListItem> { }

    [Serializable]
    public class WeightedGameObjectVarListItem : WeightedListItem<GameObjectVar> { }
}
