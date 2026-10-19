using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedColorVarList : WeightedList<ColorVar, WeightedColorVarListItem> { }

    [Serializable]
    public class WeightedColorVarListItem : WeightedListItem<ColorVar> { }
}
