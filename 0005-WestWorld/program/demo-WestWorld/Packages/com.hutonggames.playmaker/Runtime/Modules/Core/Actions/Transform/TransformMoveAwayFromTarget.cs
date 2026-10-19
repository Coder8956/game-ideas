using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [Serializable]
    [ActionCategory(Category.GameplayMovementTransform)]
    [ConvertibleGroup("TransformMove")]
    [ActionDescription("Moves a Transform away from a target Transform, with optional smoothing and max speed.")]
    [HelpURL("actions/transform-actions/move-towards-actions/")]
    public sealed class TransformMoveAwayFromTarget : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
        public override bool CanFinish => true;

        [OwnerDefaultValue]
        [Tooltip("The Transform to move.")]
        [SerializeField] private TransformVar _transform;

        [Tooltip("The Target to move away from.")]
        [SerializeField] private TransformVar _target;

        [Tooltip("The axis to move along.")]
        [SerializeField] private MoveAxisVar _axis;

        [VarSlider(0.0f, 1.0f)]
        [Tooltip("Smooth Time in seconds (roughly the time to halve the distance to the moving aim point). " +
                 "0 = no smoothing (instant if Max Speed fallback is used).")]
        [SerializeField] private FloatVar _smoothTime;

        [VarSlider(0, 20)]
        [Tooltip("Maximum movement speed (Unity units per second). 0 = uncapped.")]
        [SerializeField, DefaultValue(1f)] private FloatVar _maxSpeed;

        [Tooltip("Finish when the distance to the target is greater than this value. Set to -1 to never finish." +
                 "\n\nNote: Axis settings are used in the distance calculation.")]
        [SerializeField, DefaultValue(-1)] private FloatVar _finishDistance;

        [OptionalField]
        [Tooltip("Event to send when the move has finished.")]
        [SerializeField] private EventRef _finishedEvent;

        [NonSerialized] private float _distanceToTarget;
        [NonSerialized] private Vector3 _lastAwayDir = Vector3.right; // fallback if overlapping

        // Reuse family smoother (keeps internal velocity for SmoothDamp)
        private readonly SmoothMoveToHelper _smoother = new SmoothMoveToHelper();

        public override bool CanStart() => CheckParameters(_transform, _target);

        public override bool CanExecute() => CheckParameters(_transform);

        public override void OnStart()
        {
            _smoother.Reset();
        }

        public override void Execute()
        {
            var moveTransform = _transform.Value;
            var targetTf = _target.Value;
            if (moveTransform == null) return;
            if (targetTf == null)
            {
                Finish();
                return;
            }

            var current = moveTransform.position;

            // Project target onto allowed axes relative to current position, for consistent semantics:
            var targetProjected = MoveAxisHelper.Apply(_axis.Value, current, targetTf.position);

            // Direction away from target (guard when overlapping)
            var rawDir = current - targetProjected;
            Vector3 awayDir;
            if (rawDir.sqrMagnitude < 1e-8f)
            {
                awayDir = _lastAwayDir; // preserve last heading when overlapped
            }
            else
            {
                awayDir = rawDir.normalized;
                _lastAwayDir = awayDir;
            }

            // Per-frame "aim" point one unit ahead along awayDir.
            // Smoother will turn this into a smoothed / speed-limited step.
            var aimPoint = current + awayDir;

            // Guard: if both SmoothTime and MaxSpeed are zero, define a sane default speed (1 u/s)
            var smoothTime = Mathf.Max(0f, _smoothTime.Value);
            var maxSpeed   = _maxSpeed.Value;
            if (smoothTime <= 0f && maxSpeed <= 0f)
                maxSpeed = 1f;

            // Update position using shared smoother (applies Axis internally)
            var next = _smoother.Update(
                _axis.Value,
                current,
                aimPoint,
                smoothTime,
                maxSpeed
            );

            moveTransform.position = next;

            // --- Finish logic: distance to the axis-consistent target ---
            var finishedDistance = _finishDistance.Value;
            if (finishedDistance < 0f) return;

            var axisTargetNow = MoveAxisHelper.Apply(_axis.Value, moveTransform.position, targetTf.position);
            _distanceToTarget = Vector3.Distance(moveTransform.position, axisTargetNow);

            if (_distanceToTarget > finishedDistance)
            {
                SendEvent(_finishedEvent);
                Finish();
            }
        }

        public override string GetSummary() =>
            "Move {_transform} away from {_target}" +
            (_smoothTime.IsNotDefault() ? " in {_smoothTime}s" : "") +
            (_maxSpeed.IsNotDefault() ? " at {_maxSpeed}/s" : " (1 u/s)") +
            (_axis.Value != MoveAxis.XYZ ? " in {_axis}" : "") +
            (_finishDistance.IsNotDefault() ? " until > {_finishDistance}" : "") +
            (_finishedEvent.IsSet ? " {_finishedEvent}" : "");

#if UNITY_EDITOR
        public override bool HasDebugInfo => true;
        public override string GetDebugInfo() => $"Distance: {_distanceToTarget:0.##}";
#endif
    }
}
