#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Check whether action was Performed at any point in the current frame.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_WasPerformedThisFrame")]
	public sealed class InputActionCheckWasPerformedThisFrame : BaseTrueFalseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The InputAction to check." + Strings.InputActionEnabledNote)]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		public override bool CanExecute() => CheckParameters(_inputAction) && base.CanExecute();

		protected override bool Test()
		{
			var action = _inputAction.Value.action;
			return action is { enabled: true } && action.WasPerformedThisFrame();
		}

		protected override string TrueSummary => "{_inputAction} was performed";
		protected override string FalseSummary => "{_inputAction} was not performed";
	}
}

#endif
