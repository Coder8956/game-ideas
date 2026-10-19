#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Disable the action such that is stop listening/responding to input.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_Disable")]
	public sealed class InputActionDisable : BaseAction
	{
		
		[Tooltip("The InputAction.")]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		public override bool CanExecute() => CheckParameters(_inputAction);

		public override void Execute() => _inputAction.Value.action?.Disable();

		public override string GetSummary() => "Disable {_inputAction}";
	}
}

#endif