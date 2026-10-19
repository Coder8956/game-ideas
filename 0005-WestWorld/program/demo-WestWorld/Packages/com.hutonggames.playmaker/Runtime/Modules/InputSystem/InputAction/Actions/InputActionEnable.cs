#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Enable the action such that it actively listens for input and runs callbacks in response.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_Enable")]
	public sealed class InputActionEnable : BaseAction
	{
		[Tooltip("The InputAction.")]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		public override bool CanExecute() => CheckParameters(_inputAction);

		public override void Execute() => _inputAction.Value.action?.Enable();

		public override string GetSummary() => "Enable {_inputAction}";
	}
}

#endif