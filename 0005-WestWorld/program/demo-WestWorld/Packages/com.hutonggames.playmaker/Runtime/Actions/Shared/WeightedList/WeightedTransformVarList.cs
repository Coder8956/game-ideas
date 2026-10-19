using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedTransformVarList : WeightedList<TransformVar, WeightedTransformVarListItem> { }

    [Serializable]
    public class WeightedTransformVarListItem : WeightedListItem<TransformVar> { }
}
