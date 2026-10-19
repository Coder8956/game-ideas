/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Gets Wants Initial State Check from Input Action.")]
	[HelpURL(HelpUrls.InputSystem+"")]
	public sealed class InputActionGetWantsInitialStateCheck : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("Get InputAction Wants Initial State Check")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getWantsInitialStateCheck;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _getWantsInitialStateCheck);
		}
		
		public override void Execute()
		{
			_getWantsInitialStateCheck.Value = _inputAction.Value.wantsInitialStateCheck;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputAction} Wants Initial State Check -> {_getWantsInitialStateCheck}";
		}
	}
}

#endif
*/