/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Gets Processors from Input Action.")]
	[HelpURL(HelpUrls.InputSystem+"")]
	public sealed class InputActionGetProcessors : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("Get InputAction Processors")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getProcessors;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _getProcessors);
		}
		
		public override void Execute()
		{
			_getProcessors.Value = _inputAction.Value.processors;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputAction} Processors -> {_getProcessors}";
		}
	}
}

#endif
*/