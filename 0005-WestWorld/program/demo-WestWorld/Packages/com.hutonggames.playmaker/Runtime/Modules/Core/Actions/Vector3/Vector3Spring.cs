using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Vector3)]
    [ActionDescription("Animate a Vector3 with a damped spring around a resting value.")]
    public sealed class Vector3Spring : BaseAction, IHasGraphPreview
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
        public override bool CanFinish => true;

        [Tooltip("The value the spring settles on.")]
        [SerializeField, DefaultValue("Vector3.zero")]
        private Vector3Var _restingValue;

        [Tooltip("Offset from the resting value when the spring starts.")]
        [SerializeField, DefaultValue("Vector3.one")]
        private Vector3Var _initialOffset;

        [Tooltip("How long the spring should take in seconds.")]
        [SerializeField, DefaultValue(0.5f)]
        private FloatVar _duration;

        [Tooltip("How much the spring overshoots and oscillates.")]
        [SerializeField, DefaultValue(0.8f), VarSlider(0f, 1f)]
        private FloatVar _bounciness;

        [Tooltip("Use unscaled realtime.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _useRealtime;

        [Tooltip("Store the spring value.")]
        [SerializeField]
        [WriteOnly]
        private Vector3Ref _result;

        private Vector3 _value;
        private Vector3 _velocity;
        private float _elapsedTime;

        public float MinY => GetPreviewBounds().x;
        public float MaxY => GetPreviewBounds().y;
        public float MaxX => Mathf.Max(0.1f, _duration.Value);

        public override bool CanExecute()
        {
            return CheckParameters(_restingValue, _initialOffset, _duration, _bounciness, _useRealtime, _result);
        }

        public override void OnStart()
        {
            _value = _restingValue.Value + _initialOffset.Value;
            _velocity = Vector3.zero;
            _elapsedTime = 0f;
            _result.Value = _value;
        }

        public override void Execute()
        {
            var dt = _useRealtime.Value ? UnscaledDeltaTime : DeltaTime;
            if (dt <= 0f) return;

            var rest = _restingValue.Value;
            var duration = Mathf.Max(0f, _duration.Value);
            _elapsedTime += dt;

            if (duration <= 0f || _elapsedTime >= duration)
            {
                _value = rest;
                _velocity = Vector3.zero;
                _result.Value = _value;
                Progress = 1f;
                Finish();
                return;
            }

            GetSpringParameters(out var stiffness, out var damping);
            SpringUtility.Step(ref _value, ref _velocity, rest, stiffness, damping, dt);
            Progress = Mathf.Clamp01(_elapsedTime / duration);
            _result.Value = _value;
        }

        public float Evaluate(float t)
        {
            var duration = Mathf.Max(0f, _duration.Value);
            if (duration <= 0f || t >= duration) return 0f;

            GetSpringParameters(out var stiffness, out var damping);
            var value = SpringUtility.Evaluate(_restingValue.Value, _initialOffset.Value, stiffness, damping, t);
            return GetSignedDisplacement(value);
        }

        private Vector2 GetPreviewBounds()
        {
            var min = Evaluate(0f);
            var max = min;
            var maxTime = MaxX;
            var step = maxTime / 100f;

            for (var t = step; t <= maxTime; t += step)
            {
                var value = Evaluate(t);
                min = Mathf.Min(min, value);
                max = Mathf.Max(max, value);
            }

            var padding = Mathf.Max(0.1f, (max - min) * 0.1f);
            return new Vector2(min - padding, max + padding);
        }

        private float GetSignedDisplacement(Vector3 value)
        {
            var initialOffset = _initialOffset.Value;
            var initialMagnitude = initialOffset.magnitude;
            if (initialMagnitude <= Mathf.Epsilon)
            {
                return 0f;
            }

            return Vector3.Dot(value - _restingValue.Value, initialOffset / initialMagnitude);
        }

        private void GetSpringParameters(out float stiffness, out float damping)
        {
            SpringUtility.GetSpringParameters(_duration.Value, _bounciness.Value, _initialOffset.Value.magnitude,
                out stiffness, out damping);
        }

        public override string GetSummary()
        {
            return "Spring offset {_initialOffset} back to {_restingValue} over {_duration:seconds} bounce {_bounciness} -> {_result}";
        }
    }
}
