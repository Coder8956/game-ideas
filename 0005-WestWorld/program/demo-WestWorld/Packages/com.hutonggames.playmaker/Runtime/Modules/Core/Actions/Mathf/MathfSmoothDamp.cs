
using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Interpolation)]
	[ActionDescription("Gradually moves the current value towards a target value, over a specified time and at a specified velocity." +
	                   "\n\nThis method smoothes the current value towards a target value with a spring-damper like algorithm.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.SmoothDamp.html")]
	public sealed class MathfSmoothDamp : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

		[Tooltip("The current value.")]
		[SerializeField]
		private FloatVar _current;
		
		[Tooltip("The target value.")]
		[SerializeField]
		private FloatVar _target;
		
		[Tooltip("The approximate time it takes for the current value to reach the target value. " +
		         "The lower the smoothTime, the faster the current value reaches the target value. " +
		         "The minimum smoothTime is 0.0001. If a lower value is specified, it is clamped to the minimum value.")]
		[SerializeField, DefaultValue(0.1f)]
		private FloatVar _smoothTime;
		
		[Tooltip("Use this optional parameter to specify a maximum speed. By default, the maximum speed is set to infinity.")]
		[SerializeField, DefaultValue("~MathfInfinity")]
		private FloatVar _maxSpeed;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		private float _velocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_current, _target, _smoothTime, _maxSpeed, _result);
		}

		public override void OnStart()
		{
			_velocity = 0;
		}

		public override void Execute()
		{
			_result.Value = Mathf.SmoothDamp(_current.Value, _target.Value, ref _velocity, _smoothTime.Value, _maxSpeed.Value);
		}
		
		public override string GetSummary()
		{
			return "SmoothDamp {_current} to {_target} in {_smoothTime:seconds} " +
			       (_maxSpeed.IsNotDefault(Mathf.Infinity) ? "max {_maxSpeed}" : string.Empty)+
			       " -> {_result}";
		}
	}
}
