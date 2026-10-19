using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Shakes a transform's position with simple parameters.")]
	[HelpURL("actions/transform-actions/smoothing-actions/")]
	public sealed class TransformShakePosition : BaseAction
	{
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
		
		[OwnerDefaultValue]
		[Tooltip("The Transform to shake.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Duration of the shake effect in seconds.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _duration;
		
		[Tooltip("Maximum displacement magnitude for the shake.")]
		[SerializeField, DefaultValue(0.1f)]
		private FloatVar _magnitude;
		
		[Tooltip("Frequency of the shake oscillation.")]
		[SerializeField, DefaultValue(25f)]
		private FloatVar _frequency;
		
		[Tooltip("Use local space instead of world space.")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _useLocalSpace;

		[Tooltip("Use unscaled realtime. Useful if the game is paused.")]
		[SerializeField, DefaultValue(false)]
		private BoolVar _useRealtime;
		
		[Tooltip("Event to send when shake completes.")]
		[SerializeField, OptionalField]
		private EventRef _finishedEvent;
		
		private Vector3 _originalPosition;
		private float _elapsedTime;
		private float _startTime;
		private bool _isInitialized;
		private Vector3 _noiseOffset;
		
		private float CurrentTime => _useRealtime.Value
			? HutongGames.TimeHelper.RealtimeSinceStartup
			: InFixedUpdate ? Time.fixedTime : Time.time;

		public override bool CanFinish => true;

		public override bool CanExecute() => CheckParameters(_transform, _duration, _magnitude, _useRealtime);

		public override void Execute()
		{
			if (!_isInitialized)
			{
				Initialize();
			}
			
			_elapsedTime = Mathf.Max(0f, CurrentTime - _startTime);
			var normalizedTime = _elapsedTime / _duration.Value;

			if (_elapsedTime >= _duration.Value)
			{
				// Shake completed - restore original position
				RestoreOriginalPosition();
				
				if (_finishedEvent != null)
				{
					SendEvent(_finishedEvent);
				}
				
				Finish();
				return;
			}
			
			ApplyShake(normalizedTime);
		}
		
		private void Initialize()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			
			// Store original position
			_originalPosition = _useLocalSpace.Value 
				? transform.localPosition 
				: transform.position;
			
			// Generate random noise offset
			_noiseOffset = new Vector3(
				Random.Range(-1000f, 1000f),
				Random.Range(-1000f, 1000f),
				Random.Range(-1000f, 1000f)
			);
			
			_elapsedTime = 0f;
			_startTime = CurrentTime;
			_isInitialized = true;
		}
		
		private void ApplyShake(float normalizedTime)
		{
			var transform = _transform.Value;
			if (transform == null) return;
			
			var time = _elapsedTime * _frequency.Value;
			
			var shakeOffset = new Vector3(
				(Mathf.PerlinNoise(time + _noiseOffset.x, 0f) - 0.5f) * 2f * _magnitude.Value,
				(Mathf.PerlinNoise(0f, time + _noiseOffset.y) - 0.5f) * 2f * _magnitude.Value,
				(Mathf.PerlinNoise(time + _noiseOffset.z, time + _noiseOffset.z) - 0.5f) * 2f * _magnitude.Value
			);
			
			// Calculate fade out factor - starts at 1, smoothly goes to 0
			var fadeOutFactor = 1f - normalizedTime;
			shakeOffset *= fadeOutFactor;
			
			if (_useLocalSpace.Value)
			{
				transform.localPosition = _originalPosition + shakeOffset;
			}
			else
			{
				transform.position = _originalPosition + shakeOffset;
			}
		}
		
		private void RestoreOriginalPosition()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			
			if (_useLocalSpace.Value)
			{
				transform.localPosition = _originalPosition;
			}
			else
			{
				transform.position = _originalPosition;
			}
		}
		
		public override void OnStart()
		{
			_isInitialized = false;
			_elapsedTime = 0f;
			_startTime = CurrentTime;
			
			if (!CanExecute())
			{
				Finish();
				return;
			}
		}
		
		public override void OnStop()
		{
			if (_isInitialized)
			{
				RestoreOriginalPosition();
			}
		}

		public override string GetSummary()
		{
			return "Shake {_transform} position for {_duration:seconds} (magnitude: {_magnitude}) {_useRealtime:option}";
		}
	}
}
