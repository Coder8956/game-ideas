/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Performs Input Action Clone.")]
	[HelpURL(HelpUrls.InputSystem+"")]
	public sealed class InputActionClone : BaseAction
	{
		
		[Tooltip("The InputAction.")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("Store the result in InputAction variable.")]
		[SerializeField]
		[WriteOnly]
		private InputActionVar _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.InputSystem.InputAction.Clone();
			_result.Value = _inputAction.Value.Clone();
		}
		
		public override string GetSummary()
		{
			return "Clone {_inputAction} -> {_result}";
		}
	}
}

#endif
*/