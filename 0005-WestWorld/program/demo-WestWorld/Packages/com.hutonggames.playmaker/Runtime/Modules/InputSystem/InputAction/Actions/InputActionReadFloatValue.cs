#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Read the current float value of the control that is driving this action. " +
	                   "If no bound control is actuated, returns 0.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_ReadValue__1")]
	public sealed class InputActionReadFloatValue : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The InputAction to read from." + Strings.InputActionEnabledNote)]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		[Tooltip("Multiply the value by this value.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _multiplier;
		
		[Tooltip("Read the current float value of the control that is driving this action.")]
		[SerializeField, WriteOnly]
		private FloatRef _floatValue;
		
		public override bool CanExecute() => CheckParameters(_inputAction, _floatValue);
		
		public override void Execute()
		{
			var action = _inputAction.Value.action;
			if (action is not { enabled: true })
			{
				_floatValue.Value = 0;
				return;
			}
			
			_floatValue.Value = action.ReadValue<float>() * _multiplier.Value;
		}

		public override string GetSummary() => 
			"Read {_inputAction} " +
			(_multiplier.IsNotDefault(1f) ? " * {_multiplier}" : string.Empty) +
			" -> {_floatValue}";
	}
}

#endif
