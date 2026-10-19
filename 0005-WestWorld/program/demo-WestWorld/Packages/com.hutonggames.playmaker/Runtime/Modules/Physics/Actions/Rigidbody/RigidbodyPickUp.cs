using JetBrains.Annotations;
using HutongGames.PlayMaker.Internal;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Rigidbody)]
    [ActionDescription("Picks up a Rigidbody by smoothly aligning it to a target Transform, then optionally parenting it there. " +
                       "Stores the previous kinematic and interpolation state, then applies a held-state setup.")]
    public sealed class RigidbodyPickUp : BaseAction
    {
        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private float _startTime;
        private bool _initialized;
        private bool _completed;

        public override bool CanFinish => true;
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("The Rigidbody to pick up.")]
        [SerializeField]
        private RigidbodyVar _rigidbody;

        [Tooltip("The target Transform to align and optionally parent to.")]
        [SerializeField]
        private TransformVar _target;

        [Tooltip("Match the target position while picking up.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _setPosition;

        [Tooltip("Match the target rotation while picking up.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _setRotation;

        [Tooltip("Parent the Rigidbody transform to the target Transform after pickup completes.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _parentAfterPickup;

        [Tooltip("Zero velocity and angular velocity while picking up.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _zeroVelocity;

        [Tooltip("Smooth pickup duration in seconds. Set to 0 for an immediate snap.")]
        [SerializeField, DefaultValue(0f)]
        private FloatVar _smoothDuration;

        [Tooltip("Easing function used for smooth pickup transitions.")]
        [SerializeField, DefaultValue(HutongGames.PlayMaker.EasingFunction.Ease.Linear)]
        private EasingFunctionVar _easing;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("Stores the previous kinematic state.")]
        [SerializeField, WriteOnly]
        private BoolRef _wasKinematic;

        [OptionalField]
        [Tooltip("Stores the previous interpolation state.")]
        [SerializeField, WriteOnly]
        private RigidbodyInterpolationRef _previousInterpolation;

        [OptionalField]
        [Tooltip("Event to send after pickup completes.")]
        [SerializeField]
        private EventRef _pickedUpEvent;

        public override bool CanStart() =>
            CheckParameters(_rigidbody, _target, _setPosition, _setRotation, _parentAfterPickup, _zeroVelocity, _smoothDuration, _easing);

        public override bool CanExecute() =>
            CheckParameters(_rigidbody, _setPosition, _setRotation, _parentAfterPickup, _zeroVelocity, _smoothDuration, _easing);

        public override void OnStart()
        {
            _initialized = false;
            _completed = false;
        }

        public override void Execute()
        {
            if (_completed)
            {
                Finish();
                return;
            }

            var rb = _rigidbody.Value;
            var target = _target.Value;
            if (!rb || !target)
            {
                Finish();
                return;
            }

            var usePosition = _setPosition.Value;
            var useRotation = _setRotation.Value;
            if (!usePosition && !useRotation)
            {
                CachePhysicsState(rb);
                CompletePickup(rb, target);
                return;
            }

            if (!_initialized)
            {
                CachePhysicsState(rb);
                _startPosition = rb.position;
                _startRotation = rb.rotation;
                _startTime = Time.time;
                _initialized = true;
            }

            var duration = Mathf.Max(0f, _smoothDuration.Value);
            if (duration <= Mathf.Epsilon)
            {
                ApplyImmediatePickup(rb, target, usePosition, useRotation);
                CompletePickup(rb, target);
                return;
            }

            var t = Mathf.Clamp01((Time.time - _startTime) / duration);
            var easedT = HutongGames.PlayMaker.EasingFunction.Evaluate(_easing.Value, t);
            Progress = t;
            ApplySmoothPickup(rb, target, usePosition, useRotation, easedT);

            if (t < 1f)
            {
                return;
            }

            CompletePickup(rb, target);
        }

        public override string GetSummary() =>
            "Pick up {_rigidbody} to {_target} {_pickedUpEvent}";

        private void CachePhysicsState(Rigidbody rb)
        {
            if (_initialized)
            {
                return;
            }

            if (_wasKinematic is { IsAssigned: true })
            {
                _wasKinematic.Value = rb.isKinematic;
            }

            if (_previousInterpolation is { IsAssigned: true })
            {
                _previousInterpolation.Value = rb.interpolation;
            }

            if (_zeroVelocity.Value)
            {
                ZeroVelocity(rb);
            }

            rb.isKinematic = true;
            rb.interpolation = RigidbodyInterpolation.None;
        }

        private void ApplyImmediatePickup(Rigidbody rb, Transform target, bool setPosition, bool setRotation)
        {
            if (setPosition)
            {
                rb.position = target.position;
            }

            if (setRotation)
            {
                rb.rotation = target.rotation;
            }

        }

        private void ApplySmoothPickup(Rigidbody rb, Transform target, bool setPosition, bool setRotation, float t)
        {
            if (setPosition)
            {
                rb.MovePosition(Vector3.Lerp(_startPosition, target.position, t));
            }

            if (setRotation)
            {
                rb.MoveRotation(Quaternion.Slerp(_startRotation, target.rotation, t));
            }

        }

        private static void ZeroVelocity(Rigidbody rb)
        {
            if (rb.isKinematic)
            {
                return;
            }

            rb.SetVelocityShim(Vector3.zero);
            rb.angularVelocity = Vector3.zero;
        }

        private void CompletePickup(Rigidbody rb, Transform target)
        {
            if (_completed)
            {
                return;
            }

            if (_parentAfterPickup.Value)
            {
                var transformCache = rb.transform;
                transformCache.SetParent(target, true);

                if (_setPosition.Value)
                {
                    transformCache.localPosition = Vector3.zero;
                }

                if (_setRotation.Value)
                {
                    transformCache.localRotation = Quaternion.identity;
                }
            }

            _completed = true;
            Progress = 1f;
            SendEvent(_pickedUpEvent);
            Finish();
        }
    }
}
