#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Check whether the current actuation of the action has crossed the button press threshold " +
	                   "and has not yet fallen back below the release threshold.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_IsPressed")]
	public sealed class InputActionCheckIsPressed : BaseTrueFalseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The InputAction to check." + Strings.InputActionEnabledNote)]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		public override bool CanExecute() => CheckParameters(_inputAction) && base.CanExecute();

		protected override bool Test()
		{
			var action = _inputAction.Value.action;
			return action is { enabled: true } && action.IsPressed();
		}

		protected override string TrueSummary => "{_inputAction} is pressed";
		protected override string FalseSummary => "{_inputAction} is not pressed";
	}
}

#endif
