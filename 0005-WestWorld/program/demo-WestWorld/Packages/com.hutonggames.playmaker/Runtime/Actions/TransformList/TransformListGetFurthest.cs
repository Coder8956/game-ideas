using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameplayTargetingTransformList)]
    [ActionDescription("Get the furthest Transform in a Transform List from a target.")]
    public sealed class TransformListGetFurthest : BaseAction
    {
        [Tooltip("The Transform list to query.")]
        public TransformListRef Transforms;

        [Tooltip("The Transform to measure distances from.")]
        [OwnerDefaultValue]
        public TransformVar Target;

        [Tooltip("The axis used to measure the distance.")]
        [SerializeField]
        private MoveAxisVar _axis;

        [ActionHeader("Output")]
        [OptionalField, WriteOnly]
        [Tooltip("Store the furthest Transform.")]
        public TransformRef StoreResult;

        [OptionalField, WriteOnly]
        [Tooltip("Store the zero-based index of the furthest Transform.")]
        public IntegerRef StoreIndex;

        [OptionalField, WriteOnly]
        [Tooltip("Store the distance to the furthest Transform.")]
        public FloatRef StoreDistance;

        [OptionalField, WriteOnly]
        [Tooltip("Set to true if a Transform was found.")]
        public BoolRef Found;

        public override bool CanExecute() => CheckParameters(Transforms, Target);

        public override void Execute()
        {
            ResetOutputs();

            var axis = _axis?.Value ?? MoveAxis.XYZ;
            if (!TransformListDistanceQueryUtility.TryFindBest(
                    Transforms?.Value,
                    Target?.Value,
                    axis,
                    wantClosest: false,
                    out var bestIndex,
                    out var bestTransform,
                    out var bestDistance))
            {
                return;
            }

            if (StoreResult != null && StoreResult.IsAssigned)
                StoreResult.Value = bestTransform;

            if (StoreIndex != null && StoreIndex.IsAssigned)
                StoreIndex.Value = bestIndex;

            if (StoreDistance != null && StoreDistance.IsAssigned)
                StoreDistance.Value = bestDistance;

            if (Found != null && Found.IsAssigned)
                Found.Value = true;
        }

        public override string ErrorCheck()
        {
            if (HasAnyOutputAssigned())
                return null;

            return "Action has no outputs set.";
        }

        public override string GetSummary()
        {
            var axis = _axis != null && _axis.IsNotDefault(MoveAxis.XYZ)
                ? $" ({_axis})"
                : string.Empty;

            return $"Get furthest Transform from {{Transforms}} to {{Target}}{axis} -> {{StoreResult:output}} {{StoreIndex:output}} {{StoreDistance:output}} {{Found:output}}";
        }

        private void ResetOutputs()
        {
            if (StoreResult != null && StoreResult.IsAssigned)
                StoreResult.Value = null;

            if (StoreIndex != null && StoreIndex.IsAssigned)
                StoreIndex.Value = -1;

            if (StoreDistance != null && StoreDistance.IsAssigned)
                StoreDistance.Value = 0f;

            if (Found != null && Found.IsAssigned)
                Found.Value = false;
        }

        private bool HasAnyOutputAssigned() =>
            (StoreResult != null && StoreResult.IsAssigned) ||
            (StoreIndex != null && StoreIndex.IsAssigned) ||
            (StoreDistance != null && StoreDistance.IsAssigned) ||
            (Found != null && Found.IsAssigned);
    }
}