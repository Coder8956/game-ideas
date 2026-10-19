using JetBrains.Annotations;
using HutongGames.PlayMaker.Internal;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Rigidbody)]
    [ActionDescription("Drops a previously picked up Rigidbody by optionally unparenting it and restoring stored state.")]
    public sealed class RigidbodyDrop : BaseAction
    {
        [Tooltip("The Rigidbody to drop.")]
        [SerializeField]
        private RigidbodyVar _rigidbody;

        [Tooltip("Kinematic state to apply after dropping.")]
        [SerializeField]
        private BoolVar _setKinematic;

        [Tooltip("Interpolation state to apply after dropping.")]
        [SerializeField]
        private RigidbodyInterpolationVar _setInterpolation;

        [OptionalField]
        [Tooltip("Zero velocity and angular velocity after dropping.")]
        [SerializeField]
        private BoolVar _zeroVelocity;

        public override bool CanExecute() =>
            CheckParameters(_rigidbody, _setKinematic, _setInterpolation);

        public override void Execute()
        {
            var rb = _rigidbody.Value;
            if (!rb)
            {
                return;
            }

            rb.transform.SetParent(null, true);
            rb.isKinematic = _setKinematic.Value;
            rb.interpolation = _setInterpolation.Value;

            if (_zeroVelocity is { IsAssigned: true } && _zeroVelocity.Value)
            {
                ZeroVelocity(rb);
            }
        }

        public override string GetSummary() =>
            "Drop {_rigidbody}";

        private static void ZeroVelocity(Rigidbody rb)
        {
            if (rb.isKinematic)
            {
                return;
            }

            rb.SetVelocityShim(Vector3.zero);
            rb.angularVelocity = Vector3.zero;
        }
    }
}
