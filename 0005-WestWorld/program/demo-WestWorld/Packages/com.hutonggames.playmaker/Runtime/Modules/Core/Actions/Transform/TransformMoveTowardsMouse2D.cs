using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [HasSceneGUI]
    [ActionCategory(Category.GameplayMovementTransform)]
    [ConvertibleGroup("TransformMove")]
    [ActionDescription("Moves a Transform towards the mouse position in world space (2D), with optional smoothing and max speed.")]
    [HelpURL("actions/transform-actions/move-towards-actions/")]
    public sealed class TransformMoveTowardsMouse2D : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
        public override bool CanFinish => true;

        [OwnerDefaultValue]
        [Tooltip("The Transform to move.")]
        [SerializeField] private TransformVar _transform;

        [Tooltip("The Camera used to project the mouse position into world space.")]
        [DefaultValue("~MainCamera")]
        [SerializeField] private CameraVar _camera;

        [Tooltip("Which axes to move along. For 2D games, typically X and Y.")]
        [SerializeField] private MoveAxisVar _axis;

        [VarSlider(0.0f, 1.0f)]
        [Tooltip("Smooth Time in seconds (roughly the time to halve the distance to the target). " +
                 "Smaller = snappier. 0 = no smoothing (instant if Max Speed is 0).")]
        [SerializeField] private FloatVar _smoothTime;

        [VarSlider(0, 20)]
        [Tooltip("Maximum movement speed (Unity units per second). 0 = uncapped.")]
        [SerializeField, DefaultValue(5f)] private FloatVar _maxSpeed;

        [Tooltip("Stop moving when closer than this distance. Set to -1 to never finish.")]
        [SerializeField, DefaultValue(0.01f)] private FloatVar _finishDistance;

        [OptionalField]
        [Tooltip("Event to send when the move has finished.")]
        [SerializeField] private EventRef _finishedEvent;

        [NonSerialized] private float _distanceToTarget;

        // Internal velocity state for SmoothDamp
        private readonly SmoothMoveToHelper _smoother = new SmoothMoveToHelper();

        public override bool CanExecute() => CheckParameters(_transform, _camera);

        public override void OnStart()
        {
            _smoother.Reset(); // ensure consistent smoothing on start
        }

        public override void Execute()
        {
            var moveTransform = _transform.Value;
            if (moveTransform == null) return;

            var cam = _camera.Value;
            if (cam == null) return;

            // Get mouse world position
            var mousePos = (Vector3)InputShim.GetMousePosition();
            mousePos.z = moveTransform.position.z - cam.transform.position.z;
            var targetPos = cam.ScreenToWorldPoint(mousePos);
            targetPos.z = moveTransform.position.z; // stay in XY plane

            var current = moveTransform.position;

            // Compute next position using smoothing helper
            var next = _smoother.Update(
                _axis.Value,
                current,
                targetPos,
                _smoothTime.Value,
                _maxSpeed.Value
            );

            moveTransform.position = next;

            // Finish check
            var finishedDistance = _finishDistance.Value;
            if (finishedDistance < 0f) return;

            var axisTarget = MoveAxisHelper.Apply(_axis.Value, moveTransform.position, targetPos);
            _distanceToTarget = Vector3.Distance(moveTransform.position, axisTarget);

            if (_distanceToTarget < finishedDistance)
            {
                SendEvent(_finishedEvent);
                Finish();
            }
        }

        public override string GetSummary() =>
            "Move {_transform} towards mouse (2D)" +
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
