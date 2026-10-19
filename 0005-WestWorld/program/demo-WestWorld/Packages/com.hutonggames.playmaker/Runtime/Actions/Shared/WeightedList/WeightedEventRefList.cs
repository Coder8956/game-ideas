using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedEventRefList : WeightedList<EventRef, WeightedEventRefListItem> { }

    [Serializable]
    public class WeightedEventRefListItem : WeightedListItem<EventRef> { }
}
