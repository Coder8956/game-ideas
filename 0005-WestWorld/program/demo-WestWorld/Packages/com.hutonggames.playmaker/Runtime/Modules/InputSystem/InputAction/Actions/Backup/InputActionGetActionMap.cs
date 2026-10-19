/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Get the map the action belongs to.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_actionMap")]
	public sealed class InputActionGetActionMap : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("InputActionMap that the action belongs to or null.")]
		[SerializeField, WriteOnly]
		private InputActionMapRef _getActionMap;
		
		public override bool CanExecute() => CheckParameters(_inputAction, _getActionMap);

		public override void Execute() => _getActionMap.Value = _inputAction.Value.actionMap;

		public override string GetSummary() => "Get {_inputAction} action map -> {_getActionMap}";
	}
}

#endif
*/