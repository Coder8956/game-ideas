using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.AnimateVariables)]
    [System.Serializable]
    public abstract class BaseFloatAnimationFunctionAction : BaseAction
    {
        public abstract float Evaluate(float t);
        
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        public override bool CanFinish => true;

        [WriteOnly]
        [Tooltip("The float variable to animate.")] 
        [SerializeField]
        protected FloatRef Float;

        [Tooltip("The starting value of the animation.")] 
        [SerializeField, DefaultValue(0f)]
        protected FloatVar StartValue;
        
        [Tooltip("The ending value of the animation")]
        [SerializeField, DefaultValue(1f)]
        protected FloatVar EndValue;
        
        [Tooltip("How long the animation should last in seconds.")] 
        [SerializeField]
        [DefaultValue(1f)]
        protected FloatVar Duration;

        [Tooltip("Use unscaled realtime.")] 
        [SerializeField]
        [DefaultValue(true)]
        [FormerlySerializedAs("RealTime")]
        protected BoolVar UseRealtime;
        
        [SerializeField]
        protected LoopSettings Loop;
        
        [NonSerialized] private float _currentTime;
        [NonSerialized] private float _lastUpdateTime;
        [NonSerialized] private float _normalizedTime;
        [NonSerialized] private bool _reverse;
        [NonSerialized] private int _count;

        protected virtual string AnimationName => "Animate";

        private float CurrentTime => UseRealtime.Value
            ? TimeHelper.RealtimeSinceStartup
            : BaseAction.CurrentUpdateMode == UpdateMode.FixedUpdate ? Time.fixedTime : Time.time;

        public override bool CanExecute() => CheckParameters(Float, StartValue, EndValue, Duration, UseRealtime);
        
        public override void OnStart()
        {
            _currentTime = 0f;
            _lastUpdateTime = CurrentTime;
            _reverse = false;
            _count = 0;
        }

        public override void Execute()
        {
            var currentTime = CurrentTime;
            _currentTime += Mathf.Max(0f, currentTime - _lastUpdateTime);
            _lastUpdateTime = currentTime;

            var duration = Mathf.Max(0f, Duration.Value);
            
            if (_currentTime >= duration)
            {
                switch (Loop.Loop)
                {
                    case LoopSettings.LoopMode.NoLoop:
                        _currentTime = duration;
                        Float.Value = EndValue.Value;
                        Progress = 1;
                        Finish();
                        break;
                    case LoopSettings.LoopMode.Loop:
                        _currentTime = duration > 0f ? _currentTime - duration : 0f;
                        IncrementCount();
                        break;
                    case LoopSettings.LoopMode.PingPong:
                        _currentTime = duration > 0f ? _currentTime - duration : 0f;
                        _reverse = !_reverse;
                        if (!_reverse) // One full cycle
                        {
                            IncrementCount();
                        }

                        break;
                }
            }
            
            if (!_reverse)
            {
                _normalizedTime = duration > 0f ? _currentTime / duration : 1f;
            }
            else
            {
                _normalizedTime = duration > 0f ? 1 - _currentTime / duration : 0f;
            }

            Progress = _normalizedTime;

            // Scale and shift the animation function output
            var animationValue = Evaluate(_normalizedTime);
            Float.Value = Mathf.LerpUnclamped(StartValue.Value, EndValue.Value, animationValue);
        }

        private void IncrementCount()
        {
            if (Loop.Repeat == LoopSettings.RepeatMode.Times)
            {
                _count += 1;
                if (_count >= Loop.Count.Value)
                {
                    _normalizedTime = 1;
                    Finish();
                }
            }
        }

        public override string GetSummary()
        {
            var summary = "Animate {Float} " + AnimationName + " from {StartValue} to {EndValue} over {Duration:seconds}";

            var loopSummary = Loop.GetSummary();
            if (!string.IsNullOrEmpty(loopSummary))
            {
                summary += " (" + loopSummary + ")";
            }
            
            return summary;
        }
    }
}
