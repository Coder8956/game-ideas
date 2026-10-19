/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Whether the action has been Started or Performed.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_IsInProgress")]
	public sealed class InputActionIsInProgress : BaseAction
	{
		
		[Tooltip("The InputAction.")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("True if the action has been Started or Performed.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _result);
		}
		
		public override void Execute()
		{
			_result.Value = _inputAction.Value.IsInProgress();
		}
		
		public override string GetSummary()
		{
			return "{_inputAction} is in progress -> {_result}";
		}
	}
}

#endif
*/