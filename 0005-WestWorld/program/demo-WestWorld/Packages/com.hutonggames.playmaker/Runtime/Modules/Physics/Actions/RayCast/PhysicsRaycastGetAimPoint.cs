using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.GameplayTargetingAim)]
    [ActionDescription("Calculates an aim point along a ray using hit info and min/max distances. " +
                       "Works with any Physics Raycast action that stores a Ray and RaycastHit.")]
    [HelpURL("actions/physics-actions/gameplay/physics-raycast-get-aim-point/")]
    public class PhysicsRaycastGetAimPoint : BaseAction
    {
        [ActionHeader("Input")]

        [OptionalField]
        [Tooltip("The Ray used for the raycast (origin + direction in world space). " +
                 "Typically stored by a PhysicsRaycast action in StoreRay.")]
        [SerializeField]
        private RayRef _ray;

        [OptionalField]
        [Tooltip("Hit info from a previous raycast. If not set or not hit, the aim point is at Max Aim Distance along the ray.")]
        [SerializeField]
        private RaycastHitRef _hitInfo;

        [ActionHeader("Aim Settings")]

        [Tooltip("Minimum distance from the origin for the aim point. " +
                 "If the hit is closer than this, the aim point is pushed out to this distance.")]
        [SerializeField, DefaultValue(1)]
        private FloatVar _minAimDistance;

        [Tooltip("Maximum distance from the origin for the aim point. " +
                 "Used when nothing is hit, and clamps hits further than this.")]
        [SerializeField, DefaultValue(400)]
        private FloatVar _maxAimDistance;

        [ActionHeader("Result")]

        [OptionalField, WriteOnly]
        [Tooltip("Aim point along the ray in world space. This is always between Min Aim Distance and Max Aim Distance.")]
        [SerializeField]
        private Vector3Ref _aimPoint;

        [OptionalField, WriteOnly]
        [Tooltip("The distance from the ray origin to the aim point.")]
        [SerializeField]
        private FloatRef _aimDistance;

        public override bool CanExecute()
        {
            // Ray is technically optional (you *could* build a default), but in practice
            // the user should always assign it.
            return _ray.HasValue() && base.CanExecute();
        }

        public override void Execute()
        {
            if (!_ray.HasValue())
            {
                Finish();
                return;
            }

            var ray = _ray.Value;

            var origin = ray.origin;
            var dir    = ray.direction;

            if (dir.sqrMagnitude < 1e-6f)
            {
                dir = Vector3.forward;
            }
            else
            {
                dir.Normalize(); // Make sure distance math is in world units.
            }

            var min = Mathf.Max(0f, _minAimDistance.Value);
            var max = Mathf.Max(min, _maxAimDistance.Value);

            float distance;

            var hasHitInfo = _hitInfo.HasValue() && _hitInfo.Value.collider != null;
            if (hasHitInfo)
            {
                var hitDistance = _hitInfo.Value.distance;
                distance = Mathf.Clamp(hitDistance, min, max);
            }
            else
            {
                distance = max;
            }

            // Extra safety: avoid a zero distance unless origin is actually at (0,0,0).
            if (distance <= 0f && origin != Vector3.zero)
            {
                distance = (min > 0f ? min : 1f);
            }

            var point = origin + dir * distance;

            if (_aimPoint.HasValue())
            {
                _aimPoint.Value = point;
            }

            if (_aimDistance.HasValue())
            {
                _aimDistance.Value = distance;
            }

            Finish();
        }

        public override string GetSummary()
        {
            return "Get aim point along {_ray} [{_minAimDistance}, {_maxAimDistance}] {_aimPoint:output} {_aimDistance:output}";
        }
    }
}
