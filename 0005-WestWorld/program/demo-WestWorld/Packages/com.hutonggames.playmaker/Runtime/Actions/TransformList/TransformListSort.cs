using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameplayTargetingTransformList)]
    [ActionDescription("Sort Transforms in a list using sort Action Blocks such as Distance To Target, Size, or Data Field.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort")]
    public sealed class TransformListSort : BaseAction
    {
        public enum SortDirection
        {
            Ascending,
            Descending
        }

        [Tooltip("The Transform list to sort.")]
        public TransformListRef Transforms;

        [SerializeReference]
        [ShowFieldAndActionBlockTitle]
        [DisplayName("Sort By")]
        [Tooltip("Primary sort key.")]
        [DefaultValue(typeof(TransformSortByDistanceToTargetBlock))]
        public TransformSortBlock SortBy;

        [Tooltip("The order to sort the list in.")]
        public SortDirection Direction = SortDirection.Ascending;

        [OptionalField]
        [SerializeReference]
        [ShowFieldAndActionBlockTitle]
        [DisplayName("Then By")]
        [Tooltip("Optional secondary sort key used to break ties.")]
        public TransformSortBlock ThenBy;

        private bool HideThenByDirection => ThenBy == null;

        [HideIf(nameof(HideThenByDirection))]
        [Tooltip("The order to sort the list in for the optional secondary key.")]
        public SortDirection ThenByDirection = SortDirection.Ascending;

        [OptionalField]
        [WriteOnly]
        [Tooltip("Set to true if the list was successfully sorted.")]
        public BoolRef Sorted;

        public override bool CanExecute() =>
            Transforms != null &&
            SortBy != null &&
            SortBy.CanExecute() &&
            (ThenBy == null || ThenBy.CanExecute());

        public override void Execute()
        {
            if (Sorted != null && Sorted.IsAssigned)
                Sorted.Value = false;

            if (SortBy == null || !SortBy.CanExecute())
                return;

            if (ThenBy != null && !ThenBy.CanExecute())
                return;

            try
            {
                IComparer<Transform> comparer = new TransformSortComparer(SortBy, Direction);

                if (ThenBy != null)
                {
                    comparer = new CompositeComparer(
                        comparer,
                        new TransformSortComparer(ThenBy, ThenByDirection));
                }

                if (!TrySortSourceList(comparer))
                    return;

                if (Sorted != null && Sorted.IsAssigned)
                    Sorted.Value = true;
            }
            catch (InvalidOperationException e)
            {
                LogError(e.Message);
            }
        }

        public override string GetSummary()
        {
            var summary = "Sort {Transforms} by {SortBy} {Direction}";

            if (ThenBy != null)
                summary += " then by {ThenBy} {ThenByDirection}";

            return summary + " {Sorted:output}";
        }

        private bool TrySortSourceList(IComparer<Transform> comparer)
        {
            var listVariable = Transforms?.ListVariable;
            if (listVariable == null)
                return false;

            if (listVariable.ElementType == typeof(Transform))
            {
                var transforms = Transforms.Value;
                if (transforms == null || transforms.Count < 2)
                    return false;

                transforms.Sort(comparer);
                listVariable.NotifyValueChanged();
                return true;
            }

            if (listVariable.ElementType == typeof(GameObject))
            {
                var gameObjects = listVariable.List as IList<GameObject>;
                if (gameObjects == null || gameObjects.Count < 2)
                    return false;

                var ordered = new List<GameObject>(gameObjects);
                ordered.Sort((a, b) => comparer.Compare(a ? a.transform : null, b ? b.transform : null));

                for (var i = 0; i < ordered.Count; i++)
                    gameObjects[i] = ordered[i];

                listVariable.NotifyValueChanged();
                return true;
            }

            var transformsFallback = Transforms?.Value;
            if (transformsFallback == null || transformsFallback.Count < 2)
                return false;

            transformsFallback.Sort(comparer);
            listVariable.NotifyValueChanged();
            return true;
        }

        private sealed class TransformSortComparer : IComparer<Transform>
        {
            private readonly TransformSortBlock _sortBlock;
            private readonly SortDirection _direction;

            public TransformSortComparer(TransformSortBlock sortBlock, SortDirection direction)
            {
                _sortBlock = sortBlock;
                _direction = direction;
            }

            public int Compare(Transform x, Transform y)
            {
                var hasX = _sortBlock.TryGetSortValue(x, out var xValue);
                var hasY = _sortBlock.TryGetSortValue(y, out var yValue);

                if (!hasX && !hasY)
                    return 0;

                if (!hasX)
                    return 1;

                if (!hasY)
                    return -1;

                var compare = CompareValues(xValue, yValue);
                return _direction == SortDirection.Descending ? -compare : compare;
            }

            private static int CompareValues(object a, object b)
            {
                if (ReferenceEquals(a, b))
                    return 0;

                if (a == null)
                    return 1;

                if (b == null)
                    return -1;

                if (a is UnityEngine.Object objectA && b is UnityEngine.Object objectB)
                    return string.Compare(objectA.name, objectB.name, StringComparison.Ordinal);

                var stringA = a as string;
                var stringB = b as string;
                if (stringA != null || stringB != null)
                    return string.Compare(stringA ?? a.ToString(), stringB ?? b.ToString(), StringComparison.Ordinal);

                if (TryConvertToDouble(a, out var doubleA) && TryConvertToDouble(b, out var doubleB))
                    return doubleA.CompareTo(doubleB);

                if (a.GetType() == b.GetType() && a is IComparable comparable)
                    return comparable.CompareTo(b);

                if (a is IComparable fallbackComparable)
                {
                    try
                    {
                        return fallbackComparable.CompareTo(b);
                    }
                    catch (ArgumentException)
                    {
                    }
                }

                return string.Compare(a.ToString(), b.ToString(), StringComparison.Ordinal);
            }

            private static bool TryConvertToDouble(object value, out double result)
            {
                switch (value)
                {
                    case byte byteValue:
                        result = byteValue;
                        return true;
                    case sbyte sbyteValue:
                        result = sbyteValue;
                        return true;
                    case short shortValue:
                        result = shortValue;
                        return true;
                    case ushort ushortValue:
                        result = ushortValue;
                        return true;
                    case int intValue:
                        result = intValue;
                        return true;
                    case uint uintValue:
                        result = uintValue;
                        return true;
                    case long longValue:
                        result = longValue;
                        return true;
                    case ulong ulongValue:
                        result = ulongValue;
                        return true;
                    case float floatValue:
                        result = floatValue;
                        return true;
                    case double doubleValue:
                        result = doubleValue;
                        return true;
                    case decimal decimalValue:
                        result = (double)decimalValue;
                        return true;
                    default:
                        result = 0d;
                        return false;
                }
            }
        }

        private sealed class CompositeComparer : IComparer<Transform>
        {
            private readonly IComparer<Transform> _primary;
            private readonly IComparer<Transform> _secondary;

            public CompositeComparer(IComparer<Transform> primary, IComparer<Transform> secondary)
            {
                _primary = primary;
                _secondary = secondary;
            }

            public int Compare(Transform x, Transform y)
            {
                var primaryResult = _primary.Compare(x, y);
                return primaryResult != 0
                    ? primaryResult
                    : _secondary.Compare(x, y);
            }
        }
    }
}
