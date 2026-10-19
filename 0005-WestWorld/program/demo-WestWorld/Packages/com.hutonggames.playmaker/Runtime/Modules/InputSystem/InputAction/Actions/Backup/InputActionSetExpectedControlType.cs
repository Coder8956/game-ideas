/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Sets Expected Control Type on Input Action.")]
	[HelpURL(HelpUrls.InputSystem+"")]
	public sealed class InputActionSetExpectedControlType : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("Set InputAction Expected Control Type")]
		[SerializeField]
		private StringVar _setExpectedControlType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _setExpectedControlType);
		}
		
		public override void Execute()
		{
			_inputAction.Value.expectedControlType = _setExpectedControlType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputAction} Expected Control Type to {_setExpectedControlType}";
		}
	}
}

#endif
*/