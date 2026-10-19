/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Interactions applied to every binding on the action.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_InputAction_interactions")]
	public sealed class InputActionGetInteractions : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionVar _inputAction;
		
		[Tooltip("Get InputAction Interactions")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getInteractions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction, _getInteractions);
		}
		
		public override void Execute()
		{
			_getInteractions.Value = _inputAction.Value.interactions;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputAction} Interactions -> {_getInteractions}";
		}
	}
}

#endif
*/