using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.CharacterController)]
    [ConvertibleGroup("CharacterControllerGrounded")]
    [ActionDescription("Checks grounded state using a sphere cast based on the CharacterController shape. " +
                       "If the cast hits the ground, is grounded is true. " +
                       "<br/>This check pairs best with CharacterControllerMoveInAir for controllable airborne states.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Physics.SphereCast.html")]
    public sealed class CharacterControllerCheckIsGrounded__SphereCast : BaseCharacterControllerCheckIsGroundedAction
    {
        private const float GroundCastPadding = 0.01f;
        private const float GroundMotionEpsilon = 0.0001f;
        private readonly RaycastHit[] _hits = new RaycastHit[8];

        [Tooltip("The CharacterController to check.")]
        [SerializeField, OwnerDefaultValue]
        private CharacterControllerVar _characterController;

        [Tooltip("Extra distance below the CharacterController to check for ground.")]
        [SerializeField, DefaultValue(0.1f)]
        private FloatVar _distance;

        [Tooltip("Layers considered ground.")]
        [SerializeField, DefaultValue("Physics.DefaultRaycastLayers")]
        private LayerMaskVar _groundLayers;

        [Tooltip("Specifies whether this query should hit Triggers.")]
        [SerializeField, DefaultValue(QueryTriggerInteraction.Ignore)]
        private QueryTriggerInteraction _hitTriggers;

        private Transform _trackedGround;
        private Vector3 _lastGroundPosition;
        private bool _hasTrackedGroundPosition;

        public override bool CanExecute() => CheckParameters(_characterController, _distance, _groundLayers) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();
            ResetGroundTracking();
        }

        protected override bool Test()
        {
            var controller = _characterController.Value;
            if (!controller)
            {
                if (_storeRigidbody != null && _storeRigidbody.IsAssigned) _storeRigidbody.Value = null;
                if (_storeHitInfo != null && _storeHitInfo.IsAssigned) _storeHitInfo.Value = default;
                return false;
            }

            var transformCache = controller.transform;
            var up = transformCache.up;
            var radius = GetScaledRadius(controller);
            var origin = GetBottomSphereCenter(controller, radius) + up * GroundCastPadding;
            var maxDistance = Mathf.Max(_distance.Value + GroundCastPadding, GroundCastPadding * 2f);

            var hitCount = Physics.SphereCastNonAlloc(origin,
                                                      radius,
                                                      -up,
                                                      _hits,
                                                      maxDistance,
                                                      _groundLayers.Value,
                                                      _hitTriggers);

            var bestDistance = float.MaxValue;
            var foundHit = false;
            var bestHit = default(RaycastHit);
            var minGroundDot = Mathf.Cos(controller.slopeLimit * Mathf.Deg2Rad);

            for (var i = 0; i < hitCount; ++i)
            {
                var hit = _hits[i];
                var collider = hit.collider;
                if (!collider)
                {
                    continue;
                }

                var hitTransform = collider.transform;
                if (hitTransform == transformCache || hitTransform.IsChildOf(transformCache))
                {
                    continue;
                }

                if (Vector3.Dot(hit.normal, up) < minGroundDot)
                {
                    continue;
                }

                if (hit.distance >= bestDistance)
                {
                    continue;
                }

                bestDistance = hit.distance;
                bestHit = hit;
                foundHit = true;
            }

            if (_storeRigidbody != null && _storeRigidbody.IsAssigned)
            {
                _storeRigidbody.Value = foundHit ? bestHit.rigidbody : null;
            }

            if (_storeHitInfo != null && _storeHitInfo.IsAssigned)
            {
                _storeHitInfo.Value = bestHit;
            }

            // When the controller is moving upward, nearby ground inside the probe distance
            // should not keep the controller grounded unless it is still in immediate contact
            // or the detected ground is itself moving upward with the controller.
            var groundMovingUp = foundHit && IsGroundMovingUp(bestHit, up);
            if (foundHit && !controller.isGrounded && controller.velocity.y > 0f && bestDistance > GroundCastPadding * 2f && !groundMovingUp)
            {
                foundHit = false;
                bestHit = default;

                if (_storeRigidbody != null && _storeRigidbody.IsAssigned)
                {
                    _storeRigidbody.Value = null;
                }

                if (_storeHitInfo != null && _storeHitInfo.IsAssigned)
                {
                    _storeHitInfo.Value = default;
                }
            }

            UpdateGroundTracking(foundHit ? bestHit.collider.transform : null);
            UpdateCoyoteTime(foundHit);
            return foundHit || IsCoyoteTime();
        }

        private static Vector3 GetBottomSphereCenter(CharacterController controller, float radius)
        {
            var transformCache = controller.transform;
            var absScale = Abs(transformCache.lossyScale);
            var height = Mathf.Max(controller.height * absScale.y, radius * 2f);
            var worldCenter = transformCache.TransformPoint(controller.center);
            return worldCenter - transformCache.up * (height * 0.5f - radius);
        }

        private static float GetScaledRadius(CharacterController controller)
        {
            var transformCache = controller.transform;
            var absScale = Abs(transformCache.lossyScale);
            var scale = Mathf.Max(absScale.x, absScale.z);
            var radius = controller.radius * scale;
            var skinWidth = controller.skinWidth * scale;

            // Use the capsule contact radius instead of the full gizmo radius so ledge checks
            // stop counting tiny rim overlap as solid ground.
            return Mathf.Max(radius - skinWidth, 0.01f);
        }

        private static Vector3 Abs(Vector3 value)
        {
            return new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
        }

        private bool IsGroundMovingUp(RaycastHit hit, Vector3 up)
        {
            var groundTransform = hit.collider ? hit.collider.transform : null;
            if (!groundTransform)
            {
                return false;
            }

            if (!_hasTrackedGroundPosition || groundTransform != _trackedGround)
            {
                return false;
            }

            var groundDelta = groundTransform.position - _lastGroundPosition;
            return Vector3.Dot(groundDelta, up) > GroundMotionEpsilon;
        }

        private void UpdateGroundTracking(Transform groundTransform)
        {
            if (!groundTransform)
            {
                ResetGroundTracking();
                return;
            }

            _trackedGround = groundTransform;
            _lastGroundPosition = groundTransform.position;
            _hasTrackedGroundPosition = true;
        }

        private void ResetGroundTracking()
        {
            _trackedGround = null;
            _lastGroundPosition = Vector3.zero;
            _hasTrackedGroundPosition = false;
        }

        protected override string TrueSummary => "{_characterController} is grounded";
        protected override string FalseSummary => "{_characterController} is not grounded";
    }
}
