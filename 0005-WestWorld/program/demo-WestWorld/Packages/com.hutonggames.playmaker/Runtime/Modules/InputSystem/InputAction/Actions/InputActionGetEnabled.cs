#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Whether the action is currently enabled, i.e. responds to input, or not.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_enabled")]
	public sealed class InputActionGetEnabled : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		[Tooltip("True if the action is currently enabled.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _getEnabled);
		}
		
		public override void Execute()
		{
			_getEnabled.Value = _inputAction.Value.action?.enabled ?? false;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputAction} enabled -> {_getEnabled}";
		}
	}
}

#endif