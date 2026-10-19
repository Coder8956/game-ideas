using JetBrains.Annotations;
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Input)]
    [ActionDescription("Checks a 2D stick input against a threshold and returns an activation id for the dominant direction. " +
                       "Use this to map Horizontal and Vertical input axes to Up, Down, Left, or Right activation ids.")]
    public sealed class InputGetStickActivation : BaseAction
    {
        public enum StickState
        {
            EnteredThisFrame,
            Held,
            ReleasedThisFrame
        }

        public enum StickDirection
        {
            None,
            Up,
            Down,
            Left,
            Right
        }

        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        [Tooltip("The name of the horizontal input axis. Sets the X value of the stick input.")]
        [SerializeField, DefaultValue("Horizontal")]
        private StringVar _horizontalAxis;

        [Tooltip("The name of the vertical input axis. Sets the Y value of the stick input.")]
        [SerializeField, DefaultValue("Vertical")]
        private StringVar _verticalAxis;

        [Tooltip("Which stick transition to detect.")]
        [SerializeField, DefaultValue(StickState.EnteredThisFrame)]
        private StickState _stickState = StickState.EnteredThisFrame;

        [Tooltip("Minimum absolute axis value required before a direction counts as active.")]
        [SerializeField, DefaultValue(0.5f)]
        private FloatVar _threshold;

        [Tooltip("Activation id to return when left is the dominant direction.")]
        [SerializeField]
        private StringVar _leftActivationId;

        [Tooltip("Activation id to return when right is the dominant direction.")]
        [SerializeField]
        private StringVar _rightActivationId;

        [Tooltip("Activation id to return when up is the dominant direction.")]
        [SerializeField]
        private StringVar _upActivationId;

        [Tooltip("Activation id to return when down is the dominant direction.")]
        [SerializeField]
        private StringVar _downActivationId;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("True when the stick matches the selected state.")]
        [SerializeField, WriteOnly]
        private BoolRef _active;

        [OptionalField]
        [Tooltip("Activation id for the current direction, ready to pass into any system that routes input by id.")]
        [SerializeField, WriteOnly]
        private StringRef _activationId;

        [OptionalField]
        [Tooltip("Dominant stick direction.")]
        [SerializeField, WriteOnly]
        private EnumRef _direction = new EnumRef(typeof(StickDirection));

        [OptionalField]
        [Tooltip("Current stick vector.")]
        [SerializeField, WriteOnly]
        private Vector2Ref _stickValue;

        private StickDirection _previousDirection;

        public override void Reset()
        {
            _horizontalAxis = new StringVar();
            _horizontalAxis.Reset("Horizontal");
            _verticalAxis = new StringVar();
            _verticalAxis.Reset("Vertical");
            _stickState = StickState.EnteredThisFrame;
            _threshold = new FloatVar();
            _threshold.Reset(0.5f);
            _leftActivationId = new StringVar();
            _leftActivationId.Reset("Left");
            _rightActivationId = new StringVar();
            _rightActivationId.Reset("Right");
            _upActivationId = new StringVar();
            _upActivationId.Reset("Up");
            _downActivationId = new StringVar();
            _downActivationId.Reset("Down");
            _direction ??= new EnumRef(typeof(StickDirection));
            _direction.SetEnumType(typeof(StickDirection));
            _previousDirection = StickDirection.None;
        }

        public override void Execute()
        {
            var stickValue = new Vector2(
                _horizontalAxis?.HasValue() == true ? InputShim.GetAxis(_horizontalAxis.Value) : 0f,
                _verticalAxis?.HasValue() == true ? InputShim.GetAxis(_verticalAxis.Value) : 0f);

            var currentDirection = EvaluateCurrentDirection(stickValue, _threshold?.Value ?? 0.5f);
            var triggeredDirection = GetTriggeredDirection(_stickState, _previousDirection, currentDirection);

            if (_stickValue is { IsAssigned: true })
            {
                _stickValue.Value = stickValue;
            }

            if (triggeredDirection == StickDirection.None)
            {
                ClearOutputs();
                _previousDirection = currentDirection;
                return;
            }

            if (_active is { IsAssigned: true }) _active.Value = true;
            if (_activationId is { IsAssigned: true }) _activationId.Value = GetActivationId(triggeredDirection);
            if (_direction is { IsAssigned: true }) _direction.Value = triggeredDirection;

            _previousDirection = currentDirection;
        }

        public override string GetSummary() =>
            "Get stick activation {_active:output} {_activationId:output}";

        private void ClearOutputs()
        {
            if (_active is { IsAssigned: true }) _active.Value = false;
            if (_activationId is { IsAssigned: true }) _activationId.Value = string.Empty;
            if (_direction is { IsAssigned: true }) _direction.Value = StickDirection.None;
        }

        private string GetActivationId(StickDirection direction)
        {
            return direction switch
            {
                StickDirection.Left => _leftActivationId?.Value ?? string.Empty,
                StickDirection.Right => _rightActivationId?.Value ?? string.Empty,
                StickDirection.Up => _upActivationId?.Value ?? string.Empty,
                StickDirection.Down => _downActivationId?.Value ?? string.Empty,
                _ => string.Empty
            };
        }

        private static StickDirection EvaluateCurrentDirection(Vector2 stickValue, float threshold)
        {
            var normalizedThreshold = Mathf.Abs(threshold);
            var absX = Mathf.Abs(stickValue.x);
            var absY = Mathf.Abs(stickValue.y);

            if (absX <= normalizedThreshold && absY <= normalizedThreshold)
            {
                return StickDirection.None;
            }

            if (absX >= absY)
            {
                return stickValue.x > normalizedThreshold
                    ? StickDirection.Right
                    : stickValue.x < -normalizedThreshold
                        ? StickDirection.Left
                        : StickDirection.None;
            }

            return stickValue.y > normalizedThreshold
                ? StickDirection.Up
                : stickValue.y < -normalizedThreshold
                    ? StickDirection.Down
                    : StickDirection.None;
        }

        private static StickDirection GetTriggeredDirection(StickState stickState, StickDirection previousDirection, StickDirection currentDirection)
        {
            return stickState switch
            {
                StickState.Held => currentDirection,
                StickState.ReleasedThisFrame => previousDirection != StickDirection.None && previousDirection != currentDirection
                    ? previousDirection
                    : StickDirection.None,
                _ => currentDirection != StickDirection.None && currentDirection != previousDirection
                    ? currentDirection
                    : StickDirection.None
            };
        }
    }
}
