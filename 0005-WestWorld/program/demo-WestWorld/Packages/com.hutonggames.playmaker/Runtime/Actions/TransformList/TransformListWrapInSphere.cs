using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameplayMovementTransformList)]
    [ActionDescription("Wraps transforms inside a sphere around a center transform. " +
                       "When transforms leave the sphere, they are teleported to the opposite side.")]
    [HelpURL("actions/transform-actions/transform-clamp-actions/")]
    [MovedFrom(true, null, null, "WrapTransformsInSphere")]
    public sealed class TransformListWrapInSphere : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("List of transforms to wrap.")]
        public TransformListVar Transforms;

        [Tooltip("Center of the wrapping sphere. Typically the camera or ship.")]
        public TransformVar Center;

        [Tooltip("Radius of the wrapping sphere in world units.")] [DefaultValue(100f)]
        public FloatVar Radius;

        private float _radiusSqr;

        public override void Execute()
        {
            DoWrap();
        }

        private void DoWrap()
        {
            var center = Center.Value;
            var transforms = Transforms.Value;
            if (transforms == null || center == null || transforms.Count == 0)
                return;

            var centerPos = center.position;
            var radiusValue = Radius.Value;
            _radiusSqr = radiusValue * radiusValue;

            foreach (var transform in transforms)
            {
                if (transform == null) continue;

                var pos = transform.position;
                var offset = pos - centerPos;
                var sqrMag = offset.sqrMagnitude;

                if (sqrMag > _radiusSqr && sqrMag > 1e-6f)
                {
                    // Wrap to the opposite side of the sphere:
                    // keep the direction, mirror through center.
                    var invMag = 1.0f / Mathf.Sqrt(sqrMag);
                    var dir = offset * invMag;

                    var wrappedPos = centerPos - dir * radiusValue;
                    transform.position = wrappedPos;
                }
            }
        }

        public override string GetSummary()
        {
            return "Wrap {Transforms} within {Radius} units of {Center}";
        }
    }
}