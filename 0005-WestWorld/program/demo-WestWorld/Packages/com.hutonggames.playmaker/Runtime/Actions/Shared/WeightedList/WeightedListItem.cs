using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedListItem<T> : WeightedListItemBase
    {
        [NotOwnerDefaultValue]
        [CanBeNullOrEmpty]
        public T Value;

        public override void Reset()
        {
            base.Reset();
            Value = default;
        }
        
        public override string ToString() => Value?.ToString() ?? "Null";
    }
}