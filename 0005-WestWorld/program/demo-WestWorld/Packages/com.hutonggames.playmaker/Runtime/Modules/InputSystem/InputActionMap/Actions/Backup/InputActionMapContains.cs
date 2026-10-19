/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.InputActionMap
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputActionMap)]
	[ActionDescription("Return true if the action map contains the given action.")]
	[HelpURL(HelpUrls.InputActionMap +"#UnityEngine_InputSystem_InputActionMap_Contains_UnityEngine_InputSystem_InputAction_")]
	public sealed class InputActionMapContains : BaseAction
	{
		
		[Tooltip("The InputActionMap.")]
		[SerializeField]
		private InputActionMapRef _inputActionMap;
		
		[Tooltip("Action.")]
		[SerializeField]
		private InputActionVar _action;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputActionMap, _action, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.InputSystem.InputActionMap.Contains(UnityEngine.InputSystem.InputAction);
			_result.Value = _inputActionMap.Value.Contains(_action.Value);
		}
		
		public override string GetSummary()
		{
			return "{_inputActionMap} contains {_action} -> {_result}";
		}
	}
}
#endif
*/