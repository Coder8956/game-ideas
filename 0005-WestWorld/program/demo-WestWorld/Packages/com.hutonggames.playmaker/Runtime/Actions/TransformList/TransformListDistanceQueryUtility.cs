using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    internal static class TransformListDistanceQueryUtility
    {
        public static bool TryFindBest(
            IReadOnlyList<Transform> transforms,
            Transform target,
            MoveAxis axis,
            bool wantClosest,
            out int bestIndex,
            out Transform bestTransform,
            out float bestDistance)
        {
            bestIndex = -1;
            bestTransform = null;
            bestDistance = 0f;

            if (transforms == null || target == null || transforms.Count == 0)
                return false;

            var targetPosition = target.position;
            var bestDistanceSqr = 0f;

            for (var i = 0; i < transforms.Count; i++)
            {
                var candidate = transforms[i];
                if (candidate == null)
                    continue;

                var offset = MoveAxisHelper.ProjectToAxis(axis, candidate.position - targetPosition);
                var distanceSqr = offset.sqrMagnitude;

                if (bestIndex < 0)
                {
                    bestIndex = i;
                    bestTransform = candidate;
                    bestDistanceSqr = distanceSqr;
                    continue;
                }

                var isBetter = wantClosest
                    ? distanceSqr < bestDistanceSqr
                    : distanceSqr > bestDistanceSqr;

                if (!isBetter)
                    continue;

                bestIndex = i;
                bestTransform = candidate;
                bestDistanceSqr = distanceSqr;
            }

            if (bestIndex < 0)
                return false;

            bestDistance = Mathf.Sqrt(bestDistanceSqr);
            return true;
        }
    }
}