/*
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
	public sealed class InputActionIsPressed : BaseAction
	{
		
		[Tooltip("The InputAction.")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("True if the action is considered to be in \"pressed\" state, false otherwise.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _result);
		}

		public override void OnStart()
		{
			_inputAction.Value.Enable();
		}

		public override void Execute()
		{
			_result.Value = _inputAction.Value.IsPressed();
		}
		
		public override string GetSummary()
		{
			return "{_inputAction} is pressed -> {_result}";
		}
	}
}

#endif
*/