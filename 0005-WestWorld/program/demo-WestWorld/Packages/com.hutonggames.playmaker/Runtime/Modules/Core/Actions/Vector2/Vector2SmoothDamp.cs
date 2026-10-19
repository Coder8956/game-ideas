
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Gradually changes a vector towards a desired goal over time." +
	                   "\n\nThe vector is smoothed by some spring-damper like function, which will never overshoot. " +
	                   "The most common use is for smoothing a follow camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.SmoothDamp.html")]
	public sealed class Vector2SmoothDamp : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
		
		[Tooltip("The current position.")]
		[SerializeField]
		private Vector2Var _current;
		
		[Tooltip("The position we are trying to reach.")]
		[SerializeField]
		private Vector2Var _target;
		
		[Tooltip("Approximately the time it will take to reach the target. A smaller value will reach the target faster.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _smoothTime;
		
		[Tooltip("Value used to interpolate between a and b.")]
		[SerializeField, DefaultValue("~MathfInfinity")]
		private FloatVar _maxSpeed;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;

		private Vector2 _velocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_current, _target, _smoothTime, _maxSpeed, _result);
		}

		public override void OnStart()
		{
			_velocity = Vector2.zero;
		}

		public override void Execute()
		{
			_result.Value = Vector2.SmoothDamp(_current.Value, _target.Value, ref _velocity, _smoothTime.Value, _maxSpeed.Value);
		}
		
		public override string GetSummary()
		{
			return "SmoothDamp {_current} To {_target} Time {_smoothTime} MaxSpeed {_maxSpeed} -> {_result}";
		}
	}
}
