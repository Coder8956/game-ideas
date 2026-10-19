#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Read the current float value of the control that is driving this action with smoothing. " +
	                   "If no bound control is actuated, returns 0.")]
	[HelpURL("actions/input-system-actions/input-action-actions/read-float-value-smooth/")]
	public sealed class InputActionReadFloatValueSmooth : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The InputAction to read from." + Strings.InputActionEnabledNote)]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		[Tooltip("Multiply the value by this value.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _multiplier;
		
		[Tooltip("The approximate time it takes for the current value to reach the target value. " +
		         "The lower the smoothTime, the faster the current value reaches the target value. " +
		         "The minimum smoothTime is 0.0001. If a lower value is specified, it is clamped to the minimum value.")]
		[SerializeField, DefaultValue(0.1f)]
		private FloatVar _smoothTime;
		
		[Tooltip("Use this optional parameter to specify a maximum speed. By default, the maximum speed is set to infinity.")]
		[SerializeField, DefaultValue("~MathfInfinity")]
		private FloatVar _maxSpeed;
		
		[Tooltip("Read the current float value of the control that is driving this action.")]
		[SerializeField, WriteOnly]
		private FloatRef _floatValue;
		
		public override bool CanExecute() => CheckParameters(_inputAction, _floatValue);
		
		private float _velocity;
		
		public override void Execute()
		{
			var action = _inputAction.Value.action;
			if (action is not { enabled: true })
			{
				_floatValue.Value = 0;
				return;
			}
			
			var inputValue = action.ReadValue<float>() * _multiplier.Value;
			var smoothValue = Mathf.SmoothDamp(_floatValue.Value, inputValue, ref _velocity, _smoothTime.Value, _maxSpeed.Value);
			_floatValue.Value = smoothValue;
		}

		public override string GetSummary() => 
			"Read {_inputAction} " +
			(_multiplier.IsNotDefault(1f) ? " * {_multiplier}" : string.Empty) +
			" smooth {_smoothTime:seconds}" +
			(_maxSpeed.IsNotDefault(Mathf.Infinity) ? "max {_maxSpeed}" : string.Empty)+
			" -> {_floatValue}";
	}
}

#endif
