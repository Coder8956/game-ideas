using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedIntegerVarList : WeightedList<IntegerVar, WeightedIntegerVarListItem> { }

    [Serializable]
    public class WeightedIntegerVarListItem : WeightedListItem<IntegerVar> { }
}
