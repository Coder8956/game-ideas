using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.CharacterController)]
    [ActionDescription("Checks whether a CharacterController has enough headroom to reach a target height while keeping its feet in the same place.")]
    public sealed class CharacterControllerCheckHasHeadroom : BaseTrueFalseAction
    {
        [RequiredComponent(typeof(CharacterController))]
        [Tooltip("The CharacterController to test.")]
        [SerializeField, OwnerDefaultValue]
        private CharacterControllerVar _characterController;

        [Tooltip("The height to test for. Use the standing height when deciding if a crouched CharacterController can stand up.")]
        [SerializeField, DefaultValue(2f)]
        private FloatVar _targetHeight;

        [Tooltip("A Layer mask that defines which layers to include in the check.")]
        [SerializeField, DefaultValue("Physics.AllLayers")]
        private LayerMaskVar _layerMask;

        [Tooltip("Specifies whether this query should hit Triggers.")]
        [SerializeField, DefaultValue(QueryTriggerInteraction.UseGlobal)]
        private QueryTriggerInteraction _hitTriggers;

        public override bool CanExecute() =>
            CheckParameters(_characterController, _targetHeight, _layerMask) && base.CanExecute();

        protected override bool Test()
        {
            var controller = _characterController.Value;
            if (!controller) return false;

            var targetHeight = Mathf.Max(_targetHeight.Value, controller.radius * 2f);
            if (targetHeight <= controller.height + 0.0001f)
            {
                return true;
            }

            var transformCache = controller.transform;
            var absScale = Abs(transformCache.lossyScale);
            var radius = controller.radius * Mathf.Max(absScale.x, absScale.z);
            var scaledHeight = Mathf.Max(targetHeight * absScale.y, radius * 2f);

            var targetCenter = controller.center;
            targetCenter.y += (targetHeight - controller.height) * 0.5f;

            var worldCenter = transformCache.TransformPoint(targetCenter);
            var pointOffset = Mathf.Max(0f, scaledHeight * 0.5f - radius);
            var up = transformCache.up;
            var point0 = worldCenter + up * pointOffset;
            var point1 = worldCenter - up * pointOffset;

            // ReSharper disable once Unity.PreferNonAllocApi
            var hits = Physics.OverlapCapsule(point0, point1, radius, _layerMask.Value, _hitTriggers);
            foreach (var hit in hits)
            {
                if (hit == null || IsIgnoredHit(hit, controller, transformCache)) continue;
                return false;
            }
            
            
            return true;
        }

        protected override string TrueSummary => "{_characterController} has headroom to {_targetHeight}";
        protected override string FalseSummary => "{_characterController} does not have headroom to {_targetHeight}";

        private static bool IsIgnoredHit(Collider hit, CharacterController controller, Transform transformCache)
        {
            var hitTransform = hit.transform;
            return hit == controller
                   || hitTransform == transformCache
                   || hitTransform.IsChildOf(transformCache)
                   || hitTransform.root == transformCache.root;
        }

        private static Vector3 Abs(Vector3 value)
        {
            return new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
        }
    }
}
