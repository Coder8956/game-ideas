using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedVector2VarList : WeightedList<Vector2Var, WeightedVector2VarListItem> { }

    [Serializable]
    public class WeightedVector2VarListItem : WeightedListItem<Vector2Var> { }
}
