/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Gets Expected Control Type from Input Action.")]
	[HelpURL(HelpUrls.InputSystem+"")]
	public sealed class InputActionGetExpectedControlType : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("Get InputAction Expected Control Type")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getExpectedControlType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _getExpectedControlType);
		}
		
		public override void Execute()
		{
			_getExpectedControlType.Value = _inputAction.Value.expectedControlType;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputAction} Expected Control Type -> {_getExpectedControlType}";
		}
	}
}

#endif
*/