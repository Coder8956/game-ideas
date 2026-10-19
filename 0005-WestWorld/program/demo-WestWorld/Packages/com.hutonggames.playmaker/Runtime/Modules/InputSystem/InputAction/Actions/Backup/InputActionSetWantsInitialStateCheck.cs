/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Sets Wants Initial State Check on Input Action.")]
	[HelpURL(HelpUrls.InputSystem+"")]
	public sealed class InputActionSetWantsInitialStateCheck : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("Set InputAction Wants Initial State Check")]
		[SerializeField]
		private BoolVar _setWantsInitialStateCheck;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _setWantsInitialStateCheck);
		}
		
		public override void Execute()
		{
			_inputAction.Value.wantsInitialStateCheck = _setWantsInitialStateCheck.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputAction} Wants Initial State Check to {_setWantsInitialStateCheck}";
		}
	}
}

#endif
*/