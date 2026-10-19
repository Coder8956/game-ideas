/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("True if the action is currently in Started or Performed phase. " +
	                   "False in all other cases.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_inProgress")]
	public sealed class InputActionGetInProgress : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("Get InputAction In Progress")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getInProgress;
		
		public override bool CanExecute() => CheckParameters(_inputAction, _getInProgress);

		public override void Execute() => _getInProgress.Value = _inputAction.Value.inProgress;

		public override string GetSummary() => "Get {_inputAction} in progress -> {_getInProgress}";
	}
}

#endif

*/