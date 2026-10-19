#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Check if the action's value crossed the press threshold at any point in the frame.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_WasPressedThisFrame")]
	public sealed class InputActionCheckWasPressedThisFrame : BaseTrueFalseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The InputAction to check." + Strings.InputActionEnabledNote)]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		public override bool CanExecute() => CheckParameters(_inputAction) && base.CanExecute();

		protected override bool Test()
		{
			var action = _inputAction.Value.action;
			return action is { enabled: true } && action.WasPressedThisFrame();
		}

		protected override string TrueSummary => "{_inputAction} was pressed";
		protected override string FalseSummary => "{_inputAction} was not pressed";
	}
}

#endif
