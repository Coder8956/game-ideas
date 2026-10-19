/* Kind of a weird action, because the local position moves with the transform, so intent is not clear
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [HasSceneGUI]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformMove")]
    [ActionDescription("Moves a Transform towards a target local position with optional smoothing and max speed.")]
    public class TransformMoveTowardsLocalPosition : BaseAction
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

        [Tooltip("The Position to move towards.")]
        [SerializeField] private Vector3Var _position;

        [Tooltip("The axis to move along.")]
        [SerializeField] private MoveAxisVar _axis;

        [VarSlider(0.0f, 1.0f)]
        [Tooltip("Smooth Time in seconds (roughly the time to halve the distance to the target). " +
                 "0 = no smoothing (instant if Max Speed is 0).")]
        [SerializeField] private FloatVar _smoothTime;

        [VarSlider(0, 20)]
        [Tooltip("The maximum movement speed (Unity units per second). 0 = uncapped.")]
        [SerializeField, DefaultValue(1f)] private FloatVar _maxSpeed;

        [Tooltip("Finish when the distance to the target is less than this value. Set to -1 to never finish." +
                 "\n\nNote: Axis settings are applied to the distance calculation.")]
        [SerializeField, DefaultValue(0.01f)] private FloatVar _finishDistance;

        [OptionalField]
        [Tooltip("Event to send when the move has finished.")]
        [SerializeField] private EventRef _finishedEvent;

        [NonSerialized] private float _distanceToTarget;

        // Reusable smoother keeps its velocity state across frames
        private readonly SmoothMoveToHelper _smoother = new();

        public override bool CanExecute() => CheckParameters(_transform, _position, _maxSpeed);

        public override void OnStart()
        {
            _smoother.Reset(); // ensure a clean start for a new move
        }

        public override void Execute()
        {
            var moveTransform = _transform.Value;
            if (moveTransform == null) return;

            var current = moveTransform.localPosition;

            // Compute the next position using smoothing helper (axis-constrained)
            var next = _smoother.Update(
                _axis.Value,
                current,
                _position.Value,
                _smoothTime.Value,
                _maxSpeed.Value
            );

            moveTransform.localPosition = next;

            // Finish logic: recompute the axis-constrained target relative to the *new* position,
            // then measure distance along the allowed axes only.
            var finishedDistance = _finishDistance.Value;
            if (finishedDistance < 0f) return;

            var axisTarget = MoveAxisHelper.Apply(_axis.Value, moveTransform.localPosition, _position.Value);
            _distanceToTarget = Vector3.Distance(moveTransform.localPosition, axisTarget);

            if (_distanceToTarget < finishedDistance)
            {
                SendEvent(_finishedEvent);
                Finish();
            }
        }

        public override string GetSummary() =>
            "Move {_transform} towards local {_position}" +
            (_smoothTime.IsVariable || _smoothTime.Value > 0f ? " in {_smoothTime}s" : "") +
            (_maxSpeed.IsVariable || _maxSpeed.Value > 0f ? " at {_maxSpeed}/s" : " (instant)") +
            (_axis.Value != MoveAxis.XYZ ? " in {_axis}" : "") +
            (_finishDistance.Value > 0 ? " until < {_finishDistance}" : "") +
            (_finishedEvent.IsSet ? " {_finishedEvent}" : "");

#if UNITY_EDITOR
        public override bool HasDebugInfo => true;
        public override string GetDebugInfo() => $"Distance: {_distanceToTarget:0.##}";
#endif
    }
}
*/