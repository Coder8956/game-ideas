/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Sets Binding Mask on Input Action.")]
	[HelpURL(HelpUrls.InputSystem+"")]
	public sealed class InputActionSetBindingMask : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("Set InputAction Binding Mask")]
		[SerializeField]
		private UnityEngine.InputSystem.InputBinding? _setBindingMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _setBindingMask);
		}
		
		public override void Execute()
		{
			_inputAction.Value.bindingMask = _setBindingMask;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputAction} Binding Mask to {_setBindingMask}";
		}
	}
}

#endif
*/