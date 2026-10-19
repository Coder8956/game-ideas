using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [Serializable]
    [ActionCategory(Category.GameplayMovementTransform)]
    [ConvertibleGroup("TransformMove")]
    [ActionDescription("Moves a Transform towards a target Transform with optional smoothing and max speed.")]
    [HelpURL("actions/transform-actions/move-towards-actions/")]
    public sealed class TransformMoveTowardsTarget : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
        public override bool CanFinish => true;

        [OwnerDefaultValue]
        [Tooltip("The Transform to move.")]
        [SerializeField] private TransformVar _transform;

        [Tooltip("The Target to move towards.")]
        [SerializeField] private TransformVar _target;

        [Tooltip("The axis to move along.")]
        [SerializeField] private MoveAxisVar _axis;

        [VarSlider(0.0f, 1.0f)]
        [Tooltip("Smooth Time in seconds (roughly the time to halve the distance to the target). " +
                 "Smaller = snappier. 0 = no smoothing (instant if Max Speed is 0).")]
        [SerializeField] private FloatVar _smoothTime;

        [VarSlider(0, 20)]
        [Tooltip("The maximum movement speed (Unity units per second). 0 = uncapped.")]
        [SerializeField, DefaultValue(1f)] private FloatVar _maxSpeed;

        [Tooltip("Finish when the distance to the target is less than this value. Set this to -1 to never finish." +
                 "\n\nNote: The Axis settings are used in the distance calculation.")]
        [SerializeField, DefaultValue(0.01f)] private FloatVar _finishDistance;

        [OptionalField]
        [Tooltip("Event to send when the move has finished.")]
        [SerializeField] private EventRef _finishedEvent;

        [NonSerialized] private float _distanceToTarget;

        // Keeps internal velocity for smooth damping
        private readonly SmoothMoveToHelper _smoother = new SmoothMoveToHelper();

        public override bool CanStart() => CheckParameters(_transform, _target, _maxSpeed);

        public override bool CanExecute() => CheckParameters(_transform, _maxSpeed);

        public override void OnStart()
        {
            _smoother.Reset(); // ensure a clean start for a new move
        }

        public override void Execute()
        {
            var moveTransform = _transform.Value;
            if (moveTransform == null) return;

            var target = _target.Value;
            if (target == null)
            {
                Finish();
                return;
            }

            var current = moveTransform.position;

            // Compute smoothed/capped movement toward target (axis-constrained)
            var next = _smoother.Update(
                _axis.Value,
                current,
                target.position,
                _smoothTime.Value,
                _maxSpeed.Value
            );

            moveTransform.position = next;

            // Finish condition: distance to axis-constrained target
            var finishedDistance = _finishDistance.Value;
            if (finishedDistance < 0f) return;

            var axisTarget = MoveAxisHelper.Apply(_axis.Value, moveTransform.position, target.position);
            _distanceToTarget = Vector3.Distance(moveTransform.position, axisTarget);

            if (_distanceToTarget < finishedDistance)
            {
                SendEvent(_finishedEvent);
                Finish();
            }
        }

        public override string GetSummary() =>
            "Move {_transform} towards {_target}" +
            (_smoothTime.IsNotDefault() ? " in {_smoothTime}s" : "") +
            (_maxSpeed.IsNotDefault() ? " at {_maxSpeed}/s" : " (instant)") +
            (_axis.Value != MoveAxis.XYZ ? " in {_axis}" : "") +
            (_finishDistance.IsNotDefault() ? " until < {_finishDistance}" : "") +
            (_finishedEvent.IsSet ? " {_finishedEvent}" : "");

#if UNITY_EDITOR
        public override bool HasDebugInfo => true;
        public override string GetDebugInfo() => $"Distance: {_distanceToTarget:0.##}";
#endif
    }
}
