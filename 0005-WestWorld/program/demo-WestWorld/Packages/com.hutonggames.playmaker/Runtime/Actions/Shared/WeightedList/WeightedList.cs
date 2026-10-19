using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedList<T, TItem> : WeightedListBase, IHasIsValid
        where TItem : WeightedListItem<T>, new()
    {
        public const string ValuesProp = nameof(Values);
        
        public override int Count => Values.Count;
        
        [SerializeField]
        [FormerlySerializedAs("_values")]
        protected List<TItem> Values = new();

        public bool IsValid => Values.Count > 0;
        
        public T GetRandomItem(T none = default, float noneWeight = 0f)
        {
            if (Values == null || Values.Count == 0)
                return none;

            var total = Mathf.Max(0f, noneWeight);
            foreach (var it in Values) total += Mathf.Max(0f, it.Weight.Value);
            if (total <= 0f) return none;

            var r = UnityEngine.Random.value * total;
            if (r < noneWeight) return none;

            var cumulativeWeight = noneWeight;
            foreach (var it in Values)
            {
                cumulativeWeight += Mathf.Max(0f, it.Weight.Value);
                if (r < cumulativeWeight) return it.Value;
            }

            // In case of rounding errors, return the last item
            return Values[^1].Value;
        }

        public T GetRandomItem(T lastItem, bool noRepeat, T none = default, float noneWeight = 0f)
        {
            if (!noRepeat)
            {
                return GetRandomItem(none, noneWeight);
            }

            var comparer = EqualityComparer<T>.Default;
            var maxAttempts = Mathf.Max(1, Count * 4);

            for (var i = 0; i < maxAttempts; i++)
            {
                var item = GetRandomItem(none, noneWeight);
                if (!comparer.Equals(item, lastItem))
                {
                    return item;
                }
            }

            return GetRandomItem(none, noneWeight);
        }

        public override string ToString() => DebugUtility.GetListDebugString(Values);
    }
}
