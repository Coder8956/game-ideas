using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("Smoothing")]
    [ActionDescription("Applies frame-independent smoothing to the Transform's local scale after other actions have modified it. Optionally caps scaling speed.")]
    [HelpURL("actions/transform-actions/smoothing-actions/")]
    public sealed class TransformSmoothScale : BaseAction
    {
        // Run every frame in LateUpdate so we naturally execute after producers in Update
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [OwnerDefaultValue, Tooltip("Transform to smooth (local scale).")]
        [SerializeField] private TransformVar _transform;

        [VarSlider(0.01f, 1.0f), DefaultValue(0.3f)]
        [Tooltip("Smooth Time in seconds (roughly the time to halve the scale error). Smaller = snappier.")]
        [SerializeField] private FloatVar _smoothTime;

        [VarSlider(0, 10)]
        [Tooltip("Optional max scaling speed (units per second along the scale vector). 0 = uncapped.")]
        [SerializeField] private FloatVar _maxSpeed;

        [VarSlider(0, 10)]
        [Tooltip("If the scale jump exceeds this distance in one step, snap instead of smoothing. 0 = disabled.")]
        [SerializeField] private FloatVar _teleportThreshold;

        // Internal state (auto-lock pattern)
        private Vector3 _prev;         // previous filtered scale
        private Vector3 _target;       // desired scale we're chasing
        private Vector3 _lastWritten;  // what we wrote last frame
        private bool _hasLastWritten;
        private bool _hasTarget;

        private const float kEqualEpsScale = 1e-4f;

        public override bool CanExecute() => CheckParameters(_transform, _smoothTime);

        public override void OnStateEnter()
        {
            var t = _transform.Value;
            _prev = t ? t.localScale : Vector3.one;
            _hasLastWritten = false;
            _hasTarget = false;
        }

        public override void Execute()
        {
            var t = _transform.Value;
            if (!t) return;

            var current = t.localScale;

            if (!_hasTarget)
            {
                _target = current; // lock to post-snap on first Execute
                _hasTarget = true;
            }
            else
            {
                var upstreamChanged = _hasLastWritten && (current - _lastWritten).sqrMagnitude > kEqualEpsScale * kEqualEpsScale;
                if (upstreamChanged) _target = current;
            }

            if (_teleportThreshold.Value > 0f &&
                (_target - _prev).sqrMagnitude > _teleportThreshold.Value * _teleportThreshold.Value)
            {
                t.localScale = _target;
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

            t.localScale = filtered;
            _prev = filtered;
            _lastWritten = filtered;
            _hasLastWritten = true;
        }

        public override string GetSummary()
        {
            var s = "Smooth {_transform} scale {_smoothTime}s";
            if (_maxSpeed.Value > 0f) s += " max {_maxSpeed}/s";
            //if (_teleportThreshold.Value > 0f) s += " Teleport>{_teleportThreshold}";
            return s;
        }
    }
}
