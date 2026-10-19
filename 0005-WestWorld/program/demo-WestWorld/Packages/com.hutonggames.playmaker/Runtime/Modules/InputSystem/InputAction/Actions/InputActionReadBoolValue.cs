#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Read the current bool value of the control that is driving this action. " +
	                   "If no bound control is actuated, returns false.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_ReadValue__1")]
	public sealed class InputActionReadBoolValue : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The InputAction to read from." + Strings.InputActionEnabledNote)]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		[Tooltip("Read the current bool value of the control that is driving this action.")]
		[SerializeField, WriteOnly]
		private BoolRef _boolValue;

		public override bool CanExecute() => CheckParameters(_inputAction, _boolValue);

		public override void Execute()
		{
			var action = _inputAction.Value.action;
			if (action is not { enabled: true })
			{
				_boolValue.Value = false;
				return;
			}
			
			_boolValue.Value = action.ReadValue<bool>();
		}

		public override string GetSummary() => "Read {_inputAction} -> {_boolValue}";
	}
}

#endif
