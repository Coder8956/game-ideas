using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedFloatVarList : WeightedList<FloatVar, WeightedFloatVarListItem> { }

    [Serializable]
    public class WeightedFloatVarListItem : WeightedListItem<FloatVar> { }
}
