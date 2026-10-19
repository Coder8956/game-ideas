using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedVector3VarList : WeightedList<Vector3Var, WeightedVector3VarListItem> { }

    [Serializable]
    public class WeightedVector3VarListItem : WeightedListItem<Vector3Var> { }
}
