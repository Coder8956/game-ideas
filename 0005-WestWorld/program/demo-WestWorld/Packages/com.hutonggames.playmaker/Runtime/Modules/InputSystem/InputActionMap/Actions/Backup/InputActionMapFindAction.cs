/* NOT USED
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.InputActionMap
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputActionMap)]
	[ActionDescription("Find an action in the map by name or ID.")]
	[HelpURL(HelpUrls.InputActionMap +"#UnityEngine_InputSystem_InputActionMap_FindAction_System_String_System_Boolean_")]
	public sealed class InputActionMapFindAction : BaseAction
	{
		
		[Tooltip("The InputActionMap.")]
		[SerializeField]
		private InputActionMapRef _inputActionMap;
		
		[Tooltip("Action Name Or Id.")]
		[SerializeField]
		private StringVar _actionNameOrId;
		
		[Tooltip("Throw If Not Found.")]
		[SerializeField]
		private BoolVar _throwIfNotFound;
		
		[Tooltip("Store the result in InputAction variable.")]
		[SerializeField]
		[WriteOnly]
		private InputActionRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputActionMap, _actionNameOrId, _throwIfNotFound, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.InputSystem.InputActionMap.FindAction(System.String, System.Boolean);
			_result.Value = _inputActionMap.Value.FindAction(_actionNameOrId.Value, _throwIfNotFound.Value);
		}
		
		public override string GetSummary()
		{
			return "Find {_actionNameOrId} in {_inputActionMap} -> {_result}";
		}
	}
}

#endif
*/