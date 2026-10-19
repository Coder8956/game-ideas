using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Distance To Target")]
    public sealed class TransformSortByDistanceToTargetBlock : TransformSortBlock
    {
        [Tooltip("Measure the distance from each Transform to this target.")]
        public TransformVar Target;

        [Tooltip("The axis used to measure the distance.")]
        [SerializeField]
        private MoveAxisVar _axis;

        public override bool CanExecute() => Target != null && Target.IsNotNoneOrNull;

        public override bool TryGetSortValue(Transform transform, out object value)
        {
            value = null;

            var target = Target?.Value;
            if (transform == null || target == null)
                return false;

            var axis = _axis?.Value ?? MoveAxis.XYZ;
            value = MoveAxisHelper.GetDistance(axis, transform.position, target.position);
            return true;
        }

        public override string GetSummary() =>
            _axis != null && _axis.IsNotDefault(MoveAxis.XYZ)
                ? $"Distance To {{Target}} ({_axis})"
                : "Distance To {Target}";
    }
}