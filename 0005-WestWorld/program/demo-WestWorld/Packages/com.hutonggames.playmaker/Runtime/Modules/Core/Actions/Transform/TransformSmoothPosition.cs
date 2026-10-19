using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("Smoothing")]
    [ActionDescription("Applies frame-independent smoothing to the Transform's position after other actions have modified it. Optionally caps movement speed or uses Rigidbody/Rigidbody2D for physics-safe motion.")]
    [HelpURL("actions/transform-actions/smoothing-actions/")]
    public sealed class TransformSmoothPosition : BaseAction
    {
        // Run every frame in LateUpdate so we naturally execute after producers in Update
        public override UpdateMode DefaultUpdateMode => UpdateMode.LateUpdate | UpdateMode.EveryFrame;

        [OwnerDefaultValue, Tooltip("Transform to smooth (world position).")]
        [SerializeField] private TransformVar _transform;

        [VarSlider(0.01f, 1.0f), DefaultValue(0.3f)]
        [Tooltip("Smooth Time in seconds (roughly the time to halve the position error). Smaller = snappier.")]
        [SerializeField] private FloatVar _smoothTime;

        [VarSlider(0, 100)]
        [Tooltip("Optional max movement speed in meters per second. 0 = uncapped.")]
        [SerializeField] private FloatVar _maxSpeed;

        [VarSlider(0, 100)]
        [Tooltip("If the position jump exceeds this distance in one step, snap instead of smoothing. 0 = disabled.")]
        [SerializeField] private FloatVar _teleportThreshold;

        [Tooltip("Use Rigidbody or Rigidbody2D if present (physics-safe MovePosition). " +
                 "Hint: Set interpolation to Interpolate on the rigidbody.")]
        [SerializeField] private BoolVar _useRigidbody;

        // Internal state (auto-lock pattern)
        private Vector3 _prev;         // previous filtered position (seeded pre-snap)
        private Vector3 _target;       // desired position we're chasing
        private Vector3 _lastWritten;  // what we wrote last frame
        private bool _hasLastWritten;
        private bool _hasTarget;

        private const float kEqualEpsPos = 1e-4f; // meters

        public override bool CanExecute() => CheckParameters(_transform, _smoothTime);

        public override void OnStateEnter()
        {
            var t = _transform.Value;
            _prev = t ? t.position : Vector3.zero;
            _hasLastWritten = false;
            _hasTarget = false;
        }

        public override void Execute()
        {
            var t = _transform.Value;
            if (!t) return;

            var current = t.position;

            if (!_hasTarget)
            {
                // First frame after producers: lock target to post-snap/current
                _target = current;
                _hasTarget = true;
            }
            else
            {
                // Upstream changed this frame if current != what we wrote last frame
                var upstreamChanged = _hasLastWritten && (current - _lastWritten).sqrMagnitude > kEqualEpsPos * kEqualEpsPos;
                if (upstreamChanged) _target = current;
            }

            if (_teleportThreshold.Value > 0f &&
                (_target - _prev).sqrMagnitude > _teleportThreshold.Value * _teleportThreshold.Value)
            {
                Write(t, _target);
                _prev = _target;
                _lastWritten = _target;
                _hasLastWritten = true;
                return;
            }

            var dt = DeltaTime > 0f ? DeltaTime : Time.deltaTime;
            var smooth = Mathf.Max(1e-4f, _smoothTime.Value);
            const float ln2 = 0.69314718056f;
            var alpha = 1f - Mathf.Exp(-ln2 * dt / smooth);

            var filtered = Vector3.LerpUnclamped(_prev, _target, alpha);

            if (_maxSpeed.Value > 0f)
            {
                var delta = filtered - current;
                var maxStep = _maxSpeed.Value * dt;
                if (delta.magnitude > maxStep)
                    filtered = current + delta.normalized * maxStep;
            }

            Write(t, filtered);
            _prev = filtered;
            _lastWritten = filtered;
            _hasLastWritten = true;
        }

        private void Write(Transform t, Vector3 p)
        {
            if (_useRigidbody.Value && t.TryGetComponent<Rigidbody>(out var rb) && !rb.isKinematic)
                rb.MovePosition(p);
            else if (_useRigidbody.Value && t.TryGetComponent<Rigidbody2D>(out var rb2d))
                rb2d.MovePosition(p);
            else
                t.position = p;
        }

        public override string GetSummary()
        {
            var s = "Smooth {_transform} position {_smoothTime}s";
            if (_maxSpeed.Value > 0f) s += " max {_maxSpeed} m/s";
            //if (_teleportThreshold.Value > 0f) s += " Teleport>{_teleportThreshold} m";
            s += " {_useRigidbody:option}";
            return s;
        }
    }
}
