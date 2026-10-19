using JetBrains.Annotations;
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Input)]
    [ActionDescription("Checks an input axis against a threshold and returns an activation id. " +
                       "Use direction mode to map positive and negative movement, or engaged mode to map any movement past the threshold.")]
    public sealed class InputGetAxisActivation : BaseAction
    {
        private enum AxisMatch
        {
            None,
            Positive,
            Negative,
            Engaged
        }

        public enum AxisMode
        {
            Direction,
            Engaged
        }

        public enum AxisState
        {
            EnteredThisFrame,
            Held,
            ReleasedThisFrame
        }

        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        [Tooltip("The name of the input axis to read. Defined in the Unity Input Manager or synthesized by the input shim.")]
        [SerializeField, DefaultValue("Horizontal")]
        private StringVar _axisName;

        [Tooltip("How to interpret the axis. Direction maps positive and negative movement separately. Engaged maps any movement whose absolute value passes the threshold.")]
        [SerializeField, DefaultValue(AxisMode.Direction)]
        private AxisMode _axisMode = AxisMode.Direction;

        [Tooltip("Which axis transition to detect.")]
        [SerializeField, DefaultValue(AxisState.EnteredThisFrame)]
        private AxisState _axisState = AxisState.EnteredThisFrame;

        [Tooltip("Minimum absolute axis value required to count as active.")]
        [SerializeField, DefaultValue(0.5f)]
        private FloatVar _threshold;

        [Tooltip("Activation id to return when the axis is above the positive threshold in direction mode.")]
        [SerializeField]
        private StringVar _positiveActivationId;

        [Tooltip("Activation id to return when the axis is below the negative threshold in direction mode.")]
        [SerializeField]
        private StringVar _negativeActivationId;

        [Tooltip("Activation id to return when the axis passes the threshold in engaged mode.")]
        [SerializeField]
        private StringVar _engagedActivationId;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("True when the axis matches the selected mode and state.")]
        [SerializeField, WriteOnly]
        private BoolRef _active;

        [OptionalField]
        [Tooltip("Activation id for the current match, ready to pass into any system that routes input by id.")]
        [SerializeField, WriteOnly]
        private StringRef _activationId;

        [OptionalField]
        [Tooltip("Current axis value.")]
        [SerializeField, WriteOnly]
        private FloatRef _axisValue;

        private AxisMatch _previousMatch;

        public override void Reset()
        {
            _axisName = new StringVar();
            _axisName.Reset("Horizontal");
            _axisMode = AxisMode.Direction;
            _axisState = AxisState.EnteredThisFrame;
            _threshold = new FloatVar();
            _threshold.Reset(0.5f);
            _positiveActivationId = new StringVar();
            _positiveActivationId.Reset("Right");
            _negativeActivationId = new StringVar();
            _negativeActivationId.Reset("Left");
            _engagedActivationId = new StringVar();
            _engagedActivationId.Reset("Move");
            _previousMatch = AxisMatch.None;
        }

        public override void Execute()
        {
            var axisValue = _axisName?.HasValue() == true ? InputShim.GetAxis(_axisName.Value) : 0f;
            var currentMatch = EvaluateCurrentMatch(_axisMode, axisValue, _threshold?.Value ?? 0.5f);
            var triggeredMatch = GetTriggeredMatch(_axisState, _previousMatch, currentMatch);

            if (_axisValue is { IsAssigned: true })
            {
                _axisValue.Value = axisValue;
            }

            if (triggeredMatch == AxisMatch.None)
            {
                ClearOutputs();
                _previousMatch = currentMatch;
                return;
            }

            if (_active is { IsAssigned: true }) _active.Value = true;
            if (_activationId is { IsAssigned: true }) _activationId.Value = GetActivationId(triggeredMatch);

            _previousMatch = currentMatch;
        }

        public override string GetSummary() =>
            "Get axis activation {_active:output} {_activationId:output}";

        private void ClearOutputs()
        {
            if (_active is { IsAssigned: true }) _active.Value = false;
            if (_activationId is { IsAssigned: true }) _activationId.Value = string.Empty;
        }

        private string GetActivationId(AxisMatch match)
        {
            return match switch
            {
                AxisMatch.Positive => _positiveActivationId?.Value ?? string.Empty,
                AxisMatch.Negative => _negativeActivationId?.Value ?? string.Empty,
                AxisMatch.Engaged => _engagedActivationId?.Value ?? string.Empty,
                _ => string.Empty
            };
        }

        private static AxisMatch EvaluateCurrentMatch(AxisMode axisMode, float axisValue, float threshold)
        {
            var normalizedThreshold = Mathf.Abs(threshold);

            return axisMode switch
            {
                AxisMode.Engaged => Mathf.Abs(axisValue) > normalizedThreshold
                    ? AxisMatch.Engaged
                    : AxisMatch.None,
                _ => axisValue > normalizedThreshold
                    ? AxisMatch.Positive
                    : axisValue < -normalizedThreshold
                        ? AxisMatch.Negative
                        : AxisMatch.None
            };
        }

        private static AxisMatch GetTriggeredMatch(AxisState axisState, AxisMatch previousMatch, AxisMatch currentMatch)
        {
            return axisState switch
            {
                AxisState.Held => currentMatch,
                AxisState.ReleasedThisFrame => previousMatch != AxisMatch.None && previousMatch != currentMatch
                    ? previousMatch
                    : AxisMatch.None,
                _ => currentMatch != AxisMatch.None && currentMatch != previousMatch
                    ? currentMatch
                    : AxisMatch.None
            };
        }
    }
}
