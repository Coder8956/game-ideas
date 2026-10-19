#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem.UI;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("UI InputModule that should have it's input actions synchronized to this PlayerInput's actions.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_uiInputModule")]
	public sealed class PlayerInputSetUiInputModule : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Set PlayerInput Ui Input Module")]
		[SerializeField, CanBeNullOrEmpty]
		private InputSystemUIInputModuleVar _setUiInputModule;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput);
		}
		
		public override void Execute()
		{
			_playerInput.Value.uiInputModule = _setUiInputModule.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playerInput} UI input module to {_setUiInputModule}";
		}
	}
}

#endif
