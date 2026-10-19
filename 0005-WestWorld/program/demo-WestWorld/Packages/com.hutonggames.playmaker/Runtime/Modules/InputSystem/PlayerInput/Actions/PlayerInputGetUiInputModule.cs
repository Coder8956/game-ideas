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
	public sealed class PlayerInputGetUiInputModule : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Get PlayerInput Ui Input Module")]
		[SerializeField]
		[WriteOnly]
		private InputSystemUIInputModuleRef _getUiInputModule;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _getUiInputModule);
		}
		
		public override void Execute()
		{
			_getUiInputModule.Value = _playerInput.Value.uiInputModule;
		}
		
		public override string GetSummary()
		{
			return "Get {_playerInput} UI input module -> {_getUiInputModule}";
		}
	}
}

#endif