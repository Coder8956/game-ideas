using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Project Down To Surface")]
    [Tooltip("Project the candidate position downward onto the first collider hit.")]
    public class ProjectDownToSurfaceModifierBlock : SpawnPositionModifierBlock
    {
        [DefaultValue(10f)]
        [Tooltip("Offset applied before raycasting downward.")]
        public FloatVar RaycastOffset;

        [DefaultValue(100f)]
        [Tooltip("Maximum distance to raycast downward.")]
        public FloatVar MaxDistance;

        [DefaultValue(0f)]
        [Tooltip("Offset the candidate position away from the surface along the hit normal.")]
        public FloatVar SurfaceOffset;

        [Tooltip("Align the candidate rotation to the hit surface normal.")]
        public BoolVar AlignToSurface;

        [Tooltip("A Layer mask that is used to selectively ignore colliders.")]
        [DefaultValue("Physics.DefaultRaycastLayers")]
        public LayerMaskVar LayerMask;

        [Tooltip("Specifies whether this query should hit Triggers.")]
        [DefaultValue(QueryTriggerInteraction.UseGlobal)]
        public QueryTriggerInteraction HitTriggers;

        public override bool CanExecute() => Action.CheckParameters(RaycastOffset, SurfaceOffset, AlignToSurface, MaxDistance, LayerMask);

        public override bool ModifyCandidate(FindValidRandomPosition action)
        {
            var origin = action.CandidatePosition + Vector3.up * RaycastOffset.Value;
            var maxDistance = Mathf.Max(0f, MaxDistance.Value);

            if (!Physics.Raycast(origin, Vector3.down, out var hit, maxDistance, LayerMask.Value, HitTriggers))
            {
                return false;
            }

            action.CandidatePosition = hit.point + hit.normal * SurfaceOffset.Value;

            if (AlignToSurface.Value)
            {
                var forwardOnSurface = Vector3.ProjectOnPlane(action.CandidateRotation * Vector3.forward, hit.normal);
                if (forwardOnSurface.sqrMagnitude > Mathf.Epsilon)
                {
                    action.CandidateRotation = Quaternion.LookRotation(forwardOnSurface.normalized, hit.normal);
                }
                else
                {
                    action.CandidateRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                }
            }

            return true;
        }

        public override string GetSummary() => "Project down to surface";
    }
}
