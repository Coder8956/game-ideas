using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.AI
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.AI.NavMeshPath)]
    [ActionDescription("Gets the next corner on a NavMeshPath for a Transform to move towards. " +
                       "The action finds the closest path segment to the Transform and returns the " +
                       "segment end in forward mode or segment start in reverse mode.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshPath-corners.html")]
    public sealed class NavMeshPathGetNextCorner : BaseAction
    {
        [Tooltip("The NavMeshPath.")]
        [SerializeField]
        private NavMeshPathRef _navMeshPath;

        [OwnerDefaultValue]
        [Tooltip("The Transform used to query the path.")]
        [SerializeField]
        private TransformVar _transform;

        [DefaultValue(false)]
        [Tooltip("If true, traverse the path backwards and return the previous corner to move towards.")]
        [SerializeField]
        private BoolVar _reverse;

        [DefaultValue(0.1f)]
        [Tooltip("If the Transform is within this distance of the selected corner, advance to the next one. Set to 0 to disable.")]
        [SerializeField]
        private FloatVar _cornerReachedDistance;

        [ActionHeader("Output")]
        [OptionalField]
        [WriteOnly]
        [Tooltip("Store the corner world position.")]
        [SerializeField]
        private Vector3Ref _corner;

        [OptionalField]
        [WriteOnly]
        [Tooltip("Store the zero-based corner index.")]
        [SerializeField]
        private IntegerRef _cornerIndex;

        [OptionalField]
        [WriteOnly]
        [Tooltip("True if a corner was found.")]
        [SerializeField]
        private BoolRef _found;

        public override bool CanExecute() => CheckParameters(_navMeshPath, _transform);

        public override void Execute()
        {
            ResetOutputs();

            var corners = _navMeshPath.Value?.corners;
            var transform = _transform.Value;
            if (corners == null || corners.Length == 0 || transform == null)
            {
                return;
            }

            if (corners.Length == 1)
            {
                SetOutputs(corners[0], 0);
                return;
            }

            var position = transform.position;
            var closestSegmentIndex = GetClosestSegmentIndex(position, corners);
            var selectedCornerIndex = _reverse.Value
                ? closestSegmentIndex
                : closestSegmentIndex + 1;

            var cornerReachedDistance = Mathf.Max(0f, _cornerReachedDistance.Value);
            if (cornerReachedDistance > 0f)
            {
                var sqrCornerReachedDistance = cornerReachedDistance * cornerReachedDistance;
                if ((position - corners[selectedCornerIndex]).sqrMagnitude <= sqrCornerReachedDistance)
                {
                    selectedCornerIndex = _reverse.Value
                        ? Mathf.Max(0, selectedCornerIndex - 1)
                        : Mathf.Min(corners.Length - 1, selectedCornerIndex + 1);
                }
            }

            SetOutputs(corners[selectedCornerIndex], selectedCornerIndex);
        }

        public override string ErrorCheck()
        {
            return HasAnyOutputAssigned()
                ? null
                : "Action has no outputs set.";
        }

        public override string GetSummary()
        {
            var direction = _reverse.IsNotDefault()
                ? " (reverse)"
                : string.Empty;

            return $"Get next corner on {{_navMeshPath}} for {{_transform}}{direction} {{_corner:output}} {{_cornerIndex:output}} {{_found:output}}";
        }

        private void ResetOutputs()
        {
            if (_corner != null && _corner.IsAssigned)
            {
                _corner.Value = Vector3.zero;
            }

            if (_cornerIndex != null && _cornerIndex.IsAssigned)
            {
                _cornerIndex.Value = -1;
            }

            if (_found != null && _found.IsAssigned)
            {
                _found.Value = false;
            }
        }

        private void SetOutputs(Vector3 corner, int cornerIndex)
        {
            if (_corner != null && _corner.IsAssigned)
            {
                _corner.Value = corner;
            }

            if (_cornerIndex != null && _cornerIndex.IsAssigned)
            {
                _cornerIndex.Value = cornerIndex;
            }

            if (_found != null && _found.IsAssigned)
            {
                _found.Value = true;
            }
        }

        private static int GetClosestSegmentIndex(Vector3 position, Vector3[] corners)
        {
            var bestSegmentIndex = 0;
            var bestDistance = float.PositiveInfinity;

            for (var i = 0; i < corners.Length - 1; i++)
            {
                var closestPoint = GetClosestPointOnSegment(corners[i], corners[i + 1], position);
                var distance = (position - closestPoint).sqrMagnitude;
                if (distance >= bestDistance)
                {
                    continue;
                }

                bestDistance = distance;
                bestSegmentIndex = i;
            }

            return bestSegmentIndex;
        }

        private static Vector3 GetClosestPointOnSegment(Vector3 start, Vector3 end, Vector3 point)
        {
            var segment = end - start;
            var segmentLengthSquared = segment.sqrMagnitude;
            if (segmentLengthSquared <= Mathf.Epsilon)
            {
                return start;
            }

            var t = Mathf.Clamp01(Vector3.Dot(point - start, segment) / segmentLengthSquared);
            return start + segment * t;
        }

        private bool HasAnyOutputAssigned() =>
            (_corner != null && _corner.IsAssigned) ||
            (_cornerIndex != null && _cornerIndex.IsAssigned) ||
            (_found != null && _found.IsAssigned);
    }
}
