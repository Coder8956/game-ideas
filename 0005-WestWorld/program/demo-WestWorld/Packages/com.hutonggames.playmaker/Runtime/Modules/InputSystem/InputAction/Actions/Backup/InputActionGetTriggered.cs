/* Use WasPerformedThisFrame
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Gets Triggered from Input Action.")]
	[HelpURL(HelpUrls.InputSystem+"")]
	public sealed class InputActionGetTriggered : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("Get InputAction Triggered")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getTriggered;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _getTriggered);
		}
		
		public override void Execute()
		{
			_getTriggered.Value = _inputAction.Value.triggered;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputAction} Triggered -> {_getTriggered}";
		}
	}
}

#endif
*/