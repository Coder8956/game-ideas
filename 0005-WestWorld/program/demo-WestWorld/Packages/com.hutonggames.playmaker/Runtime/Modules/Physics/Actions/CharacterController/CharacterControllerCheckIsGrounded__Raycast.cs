using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.CharacterController)]
    [ConvertibleGroup("CharacterControllerGrounded")]
    [ActionDescription("Checks grounded state using a raycast. " +
                       "If the raycast hits the ground, is grounded is true.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Physics.Raycast.html")]
    public sealed class CharacterControllerCheckIsGrounded__Raycast : BaseCharacterControllerCheckIsGroundedAction
    {
        private const float GroundCastPadding = 0.01f;

        [Tooltip("The CharacterController to check.")]
        [SerializeField, OwnerDefaultValue]
        private CharacterControllerVar _characterController;

        [Tooltip("Extra distance below the bottom of the CharacterController capsule to check for ground.")]
        [SerializeField, DefaultValue(0.2f)]
        private FloatVar _distance;

        [Tooltip("Layers considered ground.")]
        [SerializeField, DefaultValue("Physics.DefaultRaycastLayers")]
        private LayerMaskVar _groundLayers;

        [Tooltip("Specifies whether this query should hit Triggers.")]
        [SerializeField, DefaultValue(QueryTriggerInteraction.Ignore)]
        private QueryTriggerInteraction _hitTriggers;

        private readonly RaycastHit[] _hits = new RaycastHit[8];

        public override bool CanExecute() => CheckParameters(_characterController, _distance, _groundLayers) && base.CanExecute();

        protected override bool Test()
        {
            var controller = _characterController.Value;
            if (!controller)
            {
                if (_storeRigidbody != null && _storeRigidbody.IsAssigned) _storeRigidbody.Value = null;
                if (_storeHitInfo != null && _storeHitInfo.IsAssigned) _storeHitInfo.Value = default;
                return false;
            }

            var didHit = RaycastForGround(controller, out var hitInfo);

            if (_storeRigidbody != null && _storeRigidbody.IsAssigned)
            {
                _storeRigidbody.Value = didHit ? hitInfo.rigidbody : null;
            }

            if (_storeHitInfo != null && _storeHitInfo.IsAssigned)
            {
                _storeHitInfo.Value = hitInfo;
            }

            UpdateCoyoteTime(didHit);
            return didHit || IsCoyoteTime();
        }

        private bool RaycastForGround(CharacterController controller, out RaycastHit bestHit)
        {
            var transformCache = controller.transform;
            var rayDirection = -transformCache.up;
            var rayOrigin = GetCapsuleBottom(controller) + transformCache.up * GroundCastPadding;
            var maxDistance = _distance.Value + GroundCastPadding;
            var ignoreTransform = transformCache;

            var hitCount = Physics.RaycastNonAlloc(rayOrigin,
                                                   rayDirection,
                                                   _hits,
                                                   maxDistance,
                                                   _groundLayers.Value,
                                                   _hitTriggers);

            var bestDistance = float.MaxValue;
            bestHit = default;
            var foundHit = false;

            for (var i = 0; i < hitCount; ++i)
            {
                var hit = _hits[i];
                var collider = hit.collider;
                if (!collider)
                {
                    continue;
                }

                var hitTransform = collider.transform;
                if (ignoreTransform != null &&
                    (hitTransform == ignoreTransform || hitTransform.IsChildOf(ignoreTransform)))
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

            return foundHit;
        }

        private static Vector3 GetCapsuleBottom(CharacterController controller)
        {
            var transformCache = controller.transform;
            var absScale = Abs(transformCache.lossyScale);
            var radius = controller.radius * Mathf.Max(absScale.x, absScale.z);
            var height = Mathf.Max(controller.height * absScale.y, radius * 2f);
            var worldCenter = transformCache.TransformPoint(controller.center);
            return worldCenter - transformCache.up * (height * 0.5f);
        }

        private static Vector3 Abs(Vector3 value)
        {
            return new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
        }

        protected override string TrueSummary => "{_characterController} is grounded";
        protected override string FalseSummary => "{_characterController} is not grounded";
    }
}
