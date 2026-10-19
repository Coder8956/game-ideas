#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Reset the action state to default.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_Reset")]
	public sealed class InputActionReset : BaseAction
	{
		
		[Tooltip("The InputAction.")]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		public override bool CanExecute() => CheckParameters(_inputAction);

		public override void Execute() => _inputAction.Value.action?.Reset();

		public override string GetSummary() => "Reset {_inputAction}";
	}
}

#endif