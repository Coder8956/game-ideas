using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [Serializable]
    [HasSceneGUI]
    [ActionCategory(Category.GameplayMovementTransform)]
    [ConvertibleGroup("TransformMove")]
    [ActionDescription("Moves a Transform away from a world position, with optional smoothing and max speed.")]
    [HelpURL("actions/transform-actions/move-towards-actions/")]
    public sealed class TransformMoveAwayFromPosition : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
        public override bool CanFinish => true;

        public Transform Transform => _transform.Value;
        public Vector3Var Position => _position;
        public MoveAxis Axis => _axis.Value;

        [OwnerDefaultValue]
        [Tooltip("The Transform to move.")]
        [SerializeField] private TransformVar _transform;

        [Tooltip("The Position to move away from.")]
        [SerializeField] private Vector3Var _position;

        [Tooltip("The axis to move along.")]
        [SerializeField] private MoveAxisVar _axis;

        [VarSlider(0.0f, 1.0f)]
        [Tooltip("Smooth Time in seconds (roughly the time to halve the distance to the moving aim point). " +
                 "0 = no smoothing (instant if Max Speed fallback is used).")]
        [SerializeField] private FloatVar _smoothTime;

        [VarSlider(0, 20)]
        [Tooltip("Maximum movement speed (Unity units per second). 0 = uncapped.")]
        [SerializeField, DefaultValue(1f)] private FloatVar _maxSpeed;

        [Tooltip("Finish when the distance to the position is greater than this value. Set to -1 to never finish." +
                 "\n\nNote: Axis settings are used in the distance calculation.")]
        [SerializeField, DefaultValue(-1)] private FloatVar _finishDistance;

        [OptionalField]
        [Tooltip("Event to send when the move has finished.")]
        [SerializeField] private EventRef _finishedEvent;

        [NonSerialized] private float _distanceToTarget;
        [NonSerialized] private Vector3 _lastAwayDir = Vector3.right;

        private readonly SmoothMoveToHelper _smoother = new SmoothMoveToHelper();

        public override bool CanExecute() => CheckParameters(_transform, _position);

        public override void OnStart()
        {
            _smoother.Reset();
            _lastAwayDir = GetFallbackDirection(_axis.Value);
        }

        public override void Execute()
        {
            var moveTransform = _transform.Value;
            if (moveTransform == null) return;

            var current = moveTransform.position;
            var targetProjected = MoveAxisHelper.Apply(_axis.Value, current, _position.Value);
            var rawDir = current - targetProjected;

            Vector3 awayDir;
            if (rawDir.sqrMagnitude < 1e-8f)
            {
                awayDir = _lastAwayDir;
            }
            else
            {
                awayDir = rawDir.normalized;
                _lastAwayDir = awayDir;
            }

            var aimPoint = current + awayDir;

            var smoothTime = Mathf.Max(0f, _smoothTime.Value);
            var maxSpeed = _maxSpeed.Value;
            if (smoothTime <= 0f && maxSpeed <= 0f)
                maxSpeed = 1f;

            moveTransform.position = _smoother.Update(
                _axis.Value,
                current,
                aimPoint,
                smoothTime,
                maxSpeed
            );

            var finishedDistance = _finishDistance.Value;
            if (finishedDistance < 0f) return;

            var axisTargetNow = MoveAxisHelper.Apply(_axis.Value, moveTransform.position, _position.Value);
            _distanceToTarget = Vector3.Distance(moveTransform.position, axisTargetNow);

            if (_distanceToTarget > finishedDistance)
            {
                SendEvent(_finishedEvent);
                Finish();
            }
        }

        private static Vector3 GetFallbackDirection(MoveAxis axis)
        {
            switch (axis)
            {
                case MoveAxis.Y:
                    return Vector3.up;
                case MoveAxis.Z:
                    return Vector3.forward;
                case MoveAxis.YZ:
                    return Vector3.up;
                case MoveAxis.XYZ:
                case MoveAxis.XY:
                case MoveAxis.XZ:
                case MoveAxis.X:
                default:
                    return Vector3.right;
            }
        }

        public override string GetSummary() =>
            "Move {_transform} away from {_position}" +
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
