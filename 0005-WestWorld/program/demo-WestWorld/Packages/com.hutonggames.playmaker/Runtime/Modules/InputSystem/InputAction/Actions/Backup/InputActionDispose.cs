/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Release internal state held on to by the action.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_Dispose")]
	public sealed class InputActionDispose : BaseAction
	{
		
		[Tooltip("The InputAction.")]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		public override bool CanExecute() => CheckParameters(_inputAction);

		public override void Execute() => _inputAction.Value.action?.Dispose();
		
		public override string GetSummary() => "Dispose {_inputAction}";
	}
}

#endif
*/