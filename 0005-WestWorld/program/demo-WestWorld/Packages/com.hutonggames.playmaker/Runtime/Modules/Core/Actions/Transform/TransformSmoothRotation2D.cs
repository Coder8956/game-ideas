using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("Smoothing")]
    [ActionDescription("Applies frame-independent smoothing to the Transform's Z rotation after other actions have modified it. " +
                       "Optionally caps angular speed or uses Rigidbody2D for physics-safe rotation.")]
    [HelpURL("actions/transform-actions/smoothing-actions/")]
    public sealed class TransformSmoothRotation2D : BaseAction
    {
        // Run every frame in LateUpdate so we naturally execute after producers in Update
        public override UpdateMode DefaultUpdateMode => UpdateMode.LateUpdate | UpdateMode.EveryFrame;

        [OwnerDefaultValue]
        [Tooltip("Transform to smooth (Z rotation only).")]
        [SerializeField] private TransformVar _transform;

        [VarSlider(0.01f, 1.0f), DefaultValue(0.3f)]
        [Tooltip("Smooth Time in seconds (roughly the time to halve the angular error). Smaller = snappier.")]
        [SerializeField] private FloatVar _smoothTime;

        [VarSlider(0, 1080)]
        [Tooltip("Optional max angular speed in degrees per second. 0 = uncapped.")]
        [SerializeField] private FloatVar _maxAngularSpeed;

        [VarSlider(0, 360)]
        [Tooltip("If the rotation jump exceeds this angle on a single step, snap instead of smoothing. 0 = disabled.")]
        [SerializeField] private FloatVar _teleportAngle;

        [Tooltip("Use Rigidbody2D if present (physics-safe MoveRotation). " +
                 "Hint: Set interpolation to Interpolate on the rigidbody.")]
        [SerializeField] private BoolVar _useRigidbody2D;

        [Tooltip("Lock the target on the first frame (if upstream actions don't update every frame). " +
                 "Turn off to follow the current value every-frame.")]
        [SerializeField] private BoolVar _lockTargetOnStart;

        // State
        private float _prevZ;     // filtered Z from previous tick (seeded pre-snap)
        private float _targetZ;   // fixed target when locking
        private bool _hasTarget;  // captured on first Execute (post-producer)

        public override bool CanExecute() => CheckParameters(_transform, _smoothTime);

        // Seed from pre-snap pose before any producers run their OnStart/Execute
        public override void OnStateEnter()
        {
            var t = _transform.Value;
            _prevZ = t ? t.eulerAngles.z : 0f;
            _hasTarget = false; // capture post-producer on first Execute
        }

        public override void Execute()
        {
            var t = _transform.Value;
            if (!t) return;

            // First tick after producers have written: capture desired target
            if (!_hasTarget)
            {
                _targetZ = t.eulerAngles.z;
                _hasTarget = true;
            }

            // Choose goal: fixed target (one-shot) or live current (every-frame producers)
            var goalZ = _lockTargetOnStart.Value ? _targetZ : t.eulerAngles.z;

            // Optional snap on big jumps relative to our filtered value
            if (_teleportAngle.Value > 0f && Mathf.Abs(Mathf.DeltaAngle(_prevZ, goalZ)) > _teleportAngle.Value)
            {
                Write(t, goalZ);
                _prevZ = goalZ;
                return;
            }

            var dt = DeltaTime > 0f ? DeltaTime : Time.deltaTime;
            const float ln2 = 0.69314718056f;
            var alpha = 1f - Mathf.Exp(-ln2 * dt / Mathf.Max(1e-4f, _smoothTime.Value));

            // Low-pass toward goal
            var filteredZ = Mathf.LerpAngle(_prevZ, goalZ, alpha);

            // Optional hard cap per-frame
            if (_maxAngularSpeed.Value > 0f)
            {
                var maxStep = _maxAngularSpeed.Value * dt;
                filteredZ = Mathf.MoveTowardsAngle(t.eulerAngles.z, filteredZ, maxStep);
            }

            Write(t, filteredZ);
            _prevZ = filteredZ;
        }

        private void Write(Transform t, float z)
        {
            if (_useRigidbody2D.Value && t.TryGetComponent<Rigidbody2D>(out var rb2d))
                rb2d.MoveRotation(z);
            else
                t.rotation = Quaternion.Euler(0f, 0f, z);
        }

        public override string GetSummary()
        {
            var s = "Smooth {_transform} rotation 2D {_smoothTime}s";
            //if (_lockTargetOnStart.Value) s += " (Lock Target)";
            if (_maxAngularSpeed.Value > 0f) s += " max {_maxAngularSpeed}°/s";
            //if (_teleportAngle.Value > 0f) s += " Teleport>{_teleportAngle}°";
            s += " {_useRigidbody2D:option}";
            return s;
        }
    }
}
