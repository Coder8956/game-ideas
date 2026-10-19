#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Read the current Vector3 value of the control that is driving this action. " +
	                   "If no bound control is actuated, returns Vector3.zero.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_ReadValue__1")]
	public sealed class InputActionReadVector3Value : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The InputAction to read from." + Strings.InputActionEnabledNote)]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		[Tooltip("Read the current Vector3 value of the control that is driving this action.")]
		[SerializeField, WriteOnly]
		private Vector3Ref _vector3Value;
		
		public override bool CanExecute() => CheckParameters(_inputAction, _vector3Value);

		public override void Execute()
		{
			var action = _inputAction.Value.action;
			if (action is not { enabled: true })
			{
				_vector3Value.Value = Vector3.zero;
				return;
			}
			
			_vector3Value.Value = action.ReadValue<Vector3>();
		}

		public override string GetSummary() => "Read {_inputAction} -> {_vector3Value}";
	}
}

#endif
