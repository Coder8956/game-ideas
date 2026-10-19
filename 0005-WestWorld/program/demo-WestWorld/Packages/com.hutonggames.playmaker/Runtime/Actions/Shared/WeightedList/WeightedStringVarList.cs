using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedStringVarList : WeightedList<StringVar, WeightedStringVarListItem> { }

    [Serializable]
    public class WeightedStringVarListItem : WeightedListItem<StringVar> { }
}
