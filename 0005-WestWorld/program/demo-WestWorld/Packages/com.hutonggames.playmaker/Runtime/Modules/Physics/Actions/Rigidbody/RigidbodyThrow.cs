using JetBrains.Annotations;
using HutongGames.PlayMaker.Internal;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Rigidbody)]
    [ActionDescription("Throws a Rigidbody by optionally unparenting it, restoring stored state, and applying release velocity.")]
    public sealed class RigidbodyThrow : BaseAction
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

        [Tooltip("The Rigidbody to throw.")]
        [SerializeField]
        private RigidbodyVar _rigidbody;

        [Tooltip("Interpolation state to apply before throwing.")]
        [SerializeField]
        private RigidbodyInterpolationVar _setInterpolation;

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
        private Vector3Var _velocity;
        
        [Tooltip("Force to apply when Throw Mode is Add Force.")]
        [SerializeField, HideIf(nameof(HideForceFields))]
        private Vector3Var _force;

        [Tooltip("Multiply the velocity or force vector by this value.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _multiplier = new() { Value = 1f };
        
        [Tooltip("Force mode to use when Throw Mode is Add Force.")]
        [SerializeField, HideIf(nameof(HideForceFields))]
        private ForceModeVar _forceMode;

        [Tooltip("Angular velocity to apply when thrown.")]
        [SerializeField]
        private Vector3Var _angularVelocity;

        private bool HideVelocityFields => (ThrowMode)_throwMode.Value == ThrowMode.AddForce;
        private bool HideForceFields => (ThrowMode)_throwMode.Value == ThrowMode.SetVelocity;
        private bool HideReferenceTransform => (DirectionSpace)_directionSpace.Value != DirectionSpace.ReferenceTransform;

        public override bool CanExecute() =>
            CheckParameters(_rigidbody, _setInterpolation, _throwMode, _directionSpace, _referenceTransform, _velocity, _multiplier, _angularVelocity, _force, _forceMode);

        public override void Execute()
        {
            var rb = _rigidbody.Value;
            if (!rb)
            {
                return;
            }

            rb.transform.SetParent(null, true);
            rb.isKinematic = false;
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
            "Throw {_rigidbody}"
            + (!Mathf.Approximately(_multiplier.Value, 1f) ? " * {_multiplier}" : string.Empty)
            + GetDirectionSpaceSummarySuffix();

        private Vector3 ResolveDirection(Transform transformCache, Vector3 value) =>
            ResolveDirectionTransform(transformCache)?.TransformDirection(value) ?? value;

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
