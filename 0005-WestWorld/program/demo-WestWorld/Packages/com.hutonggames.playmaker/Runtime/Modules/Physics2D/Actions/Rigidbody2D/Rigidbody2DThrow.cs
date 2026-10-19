using JetBrains.Annotations;
using HutongGames.PlayMaker.Internal;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Rigidbody2D)]
    [ActionDescription("Throws a Rigidbody2D by optionally unparenting it, restoring stored state, and applying release velocity.")]
    public sealed class Rigidbody2DThrow : BaseAction
    {
        private enum ThrowMode
        {
            SetVelocity,
            AddForce
        }

        private enum DirectionSpace
        {
            World,
            Self,
            ReferenceTransform
        }

        [Tooltip("The Rigidbody2D to throw.")]
        [SerializeField]
        private Rigidbody2DVar _rigidbody2D;

        [Tooltip("Interpolation state to apply before throwing.")]
        [SerializeField]
        private RigidbodyInterpolation2DVar _setInterpolation;

        [Tooltip("How to apply the throw.")]
        [SerializeField, DefaultValue(ThrowMode.SetVelocity)]
        private EnumVar _throwMode = new(typeof(ThrowMode));

        [Tooltip("Which transform basis to use for velocity or force.")]
        [SerializeField, DefaultValue(DirectionSpace.World)]
        private EnumVar _directionSpace = new(typeof(DirectionSpace));

        [Tooltip("Reference transform used when Direction Space is Reference Transform.")]
        [SerializeField, HideIf(nameof(HideReferenceTransform))]
        private TransformVar _referenceTransform;

        [Tooltip("Linear velocity to apply when Throw Mode is Set Velocity.")]
        [SerializeField, HideIf(nameof(HideVelocityFields))]
        private Vector2Var _velocity;

        [Tooltip("Multiply the velocity or force vector by this value.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _multiplier = new() { Value = 1f };

        [Tooltip("Force to apply when Throw Mode is Add Force.")]
        [SerializeField, HideIf(nameof(HideForceFields))]
        private Vector2Var _force;

        [Tooltip("Force mode to use when Throw Mode is Add Force.")]
        [SerializeField, HideIf(nameof(HideForceFields))]
        private ForceMode2DVar _forceMode;

        [Tooltip("Angular velocity to apply when thrown.")]
        [SerializeField]
        private FloatVar _angularVelocity;

        private bool HideVelocityFields => (ThrowMode)_throwMode.Value == ThrowMode.AddForce;
        private bool HideForceFields => (ThrowMode)_throwMode.Value == ThrowMode.SetVelocity;
        private bool HideReferenceTransform => (DirectionSpace)_directionSpace.Value != DirectionSpace.ReferenceTransform;

        public override bool CanExecute() =>
            CheckParameters(_rigidbody2D, _setInterpolation, _throwMode, _directionSpace, _referenceTransform, _velocity, _multiplier, _angularVelocity, _force, _forceMode);

        public override void Execute()
        {
            var rb = _rigidbody2D.Value;
            if (!rb)
            {
                return;
            }

            rb.transform.SetParent(null, true);
            rb.SetIsKinematicShim(false);
            rb.interpolation = _setInterpolation.Value;

            var multiplier = _multiplier.Value;

            if ((ThrowMode)_throwMode.Value == ThrowMode.AddForce)
            {
                rb.AddForce(ResolveDirection(rb.transform, _force.Value * multiplier), _forceMode.Value);
                rb.angularVelocity = _angularVelocity.Value;
            }
            else
            {
                rb.SetVelocityShim(ResolveDirection(rb.transform, _velocity.Value * multiplier));
                rb.angularVelocity = _angularVelocity.Value;
            }

        }

        public override string GetSummary() =>
            "Throw {_rigidbody2D}"
            + (!Mathf.Approximately(_multiplier.Value, 1f) ? " * {_multiplier}" : string.Empty)
            + GetDirectionSpaceSummarySuffix();

        private Vector2 ResolveDirection(Transform transformCache, Vector2 value)
        {
            var referenceTransform = ResolveDirectionTransform(transformCache);
            if (!referenceTransform)
            {
                return value;
            }

            var world = referenceTransform.TransformDirection(new Vector3(value.x, value.y, 0f));
            return new Vector2(world.x, world.y);
        }

        private Transform ResolveDirectionTransform(Transform transformCache)
        {
            return (DirectionSpace)_directionSpace.Value switch
            {
                DirectionSpace.Self => transformCache,
                DirectionSpace.ReferenceTransform => _referenceTransform.Value,
                _ => null
            };
        }

        private string GetDirectionSpaceSummarySuffix()
        {
            return (DirectionSpace)_directionSpace.Value switch
            {
                DirectionSpace.Self => " (self)",
                DirectionSpace.ReferenceTransform => " (reference)",
                _ => string.Empty
            };
        }
    }
}
