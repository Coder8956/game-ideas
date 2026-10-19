using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("Smoothing")]
    [ActionDescription("Applies frame-independent smoothing to the Transform's rotation after other actions have modified it. Optionally caps turn speed or uses Rigidbody/Rigidbody2D for physics-safe rotation.")]
    [HelpURL("actions/transform-actions/smoothing-actions/")]
    public sealed class TransformSmoothRotation : BaseAction
    {
        // Run every frame in LateUpdate so we naturally execute after producers in Update
        public override UpdateMode DefaultUpdateMode => UpdateMode.LateUpdate | UpdateMode.EveryFrame;

        [OwnerDefaultValue, Tooltip("Transform to smooth (full 3D rotation).")]
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

        [Tooltip("Use Rigidbody or Rigidbody2D if present (physics-safe MoveRotation). " +
                 "Hint: Set interpolation to Interpolate on the rigidbody.")]
        [SerializeField] private BoolVar _useRigidbody;

        [Tooltip("Lock the target on the first frame (if upstream actions don't update every frame). " +
                 "Turn off to follow the current value every-frame.")]
        [SerializeField] private BoolVar _lockTargetOnStart;

        // State
        private Quaternion _prev;        // pre-snap (seeded on enter)
        private Quaternion _target;      // fixed target when locking
        private bool _hasTarget;

        public override bool CanExecute() => CheckParameters(_transform, _smoothTime);

        public override void OnStateEnter()
        {
            var t = _transform.Value;
            _prev = t ? t.rotation : Quaternion.identity;
            _hasTarget = false; // capture on first Execute (post-producer)
        }

        public override void Execute()
        {
            var t = _transform.Value;
            if (!t) return;

            // On first tick, after producers have written, capture the desired target.
            if (!_hasTarget)
            {
                _target = t.rotation;
                _hasTarget = true;
            }

            // Choose the goal to chase
            var goal = _lockTargetOnStart.Value ? _target : t.rotation;

            // Optional snap on big jumps relative to our filtered value
            if (_teleportAngle.Value > 0f && Quaternion.Angle(_prev, goal) > _teleportAngle.Value)
            {
                Write(t, goal);
                _prev = goal;
                return;
            }

            var dt = DeltaTime > 0f ? DeltaTime : Time.deltaTime;
            const float ln2 = 0.69314718056f;
            var alpha = 1f - Mathf.Exp(-ln2 * dt / Mathf.Max(1e-4f, _smoothTime.Value));

            var filtered = Quaternion.Slerp(_prev, goal, alpha);

            if (_maxAngularSpeed.Value > 0f)
                filtered = Quaternion.RotateTowards(t.rotation, filtered, _maxAngularSpeed.Value * dt);

            Write(t, filtered);
            _prev = filtered;
        }

        private void Write(Transform t, Quaternion q)
        {
            if (_useRigidbody.Value && t.TryGetComponent<Rigidbody>(out var rb) && !rb.isKinematic)
                rb.MoveRotation(q);
            else if (_useRigidbody.Value && t.TryGetComponent<Rigidbody2D>(out var rb2d))
                rb2d.MoveRotation(q.eulerAngles.z);
            else
                t.rotation = q;
        }

        public override string GetSummary()
        {
            var s = "Smooth {_transform} rotation {_smoothTime}s";
            //if (_lockTargetOnStart.Value) s += " (Lock Target)";
            if (_maxAngularSpeed.Value > 0f) s += " max {_maxAngularSpeed}°/s";
            //if (_teleportAngle.Value > 0f) s += " Teleport>{_teleportAngle}°";
            s += " {_useRigidbody:option}";
            return s;
        }
    }
}
