/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Performs Input Action To String.")]
	[HelpURL(HelpUrls.InputSystem+"")]
	public sealed class InputActionToString : BaseAction
	{
		
		[Tooltip("The InputAction.")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.InputSystem.InputAction.ToString();
			_result.Value = _inputAction.Value.ToString();
		}
		
		public override string GetSummary()
		{
			return "{_inputAction} to string -> {_result}";
		}
	}
}

#endif
*/