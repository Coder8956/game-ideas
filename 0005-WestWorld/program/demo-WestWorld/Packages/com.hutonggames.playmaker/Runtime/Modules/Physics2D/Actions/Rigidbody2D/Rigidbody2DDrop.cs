using JetBrains.Annotations;
using HutongGames.PlayMaker.Internal;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Rigidbody2D)]
    [ActionDescription("Drops a previously picked up Rigidbody2D by optionally unparenting it and restoring stored state.")]
    public sealed class Rigidbody2DDrop : BaseAction
    {
        [Tooltip("The Rigidbody2D to drop.")]
        [SerializeField]
        private Rigidbody2DVar _rigidbody2D;

        [Tooltip("Kinematic state to apply after dropping.")]
        [SerializeField]
        private BoolVar _setKinematic;

        [Tooltip("Interpolation state to apply after dropping.")]
        [SerializeField]
        private RigidbodyInterpolation2DVar _setInterpolation;

        [OptionalField]
        [Tooltip("Zero velocity and angular velocity after dropping.")]
        [SerializeField]
        private BoolVar _zeroVelocity;

        public override bool CanExecute() =>
            CheckParameters(_rigidbody2D, _setKinematic, _setInterpolation);

        public override void Execute()
        {
            var rb = _rigidbody2D.Value;
            if (!rb)
            {
                return;
            }

            rb.transform.SetParent(null, true);
            rb.SetIsKinematicShim(_setKinematic.Value);
            rb.interpolation = _setInterpolation.Value;

            if (_zeroVelocity is { IsAssigned: true } && _zeroVelocity.Value)
            {
                ZeroVelocity(rb);
            }
        }

        public override string GetSummary() =>
            "Drop {_rigidbody2D}";

        private static void ZeroVelocity(Rigidbody2D rb)
        {
            if (rb.GetIsKinematicShim())
            {
                return;
            }

            rb.SetVelocityShim(Vector2.zero);
            rb.angularVelocity = 0f;
        }
    }
}
