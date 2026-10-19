#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Checks if the action has been Started or Performed.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_IsInProgress")]
	public sealed class InputActionCheckIsInProgress : BaseTrueFalseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The InputAction to check." + Strings.InputActionEnabledNote)]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		public override bool CanExecute() => CheckParameters(_inputAction) && base.CanExecute();

		protected override bool Test()
		{
			var action = _inputAction.Value.action;
			return action is { enabled: true } && action.IsInProgress();
		}

		protected override string TrueSummary => "{_inputAction} is in progress";
		protected override string FalseSummary => "{_inputAction} is not in progress";
	}
}

#endif
