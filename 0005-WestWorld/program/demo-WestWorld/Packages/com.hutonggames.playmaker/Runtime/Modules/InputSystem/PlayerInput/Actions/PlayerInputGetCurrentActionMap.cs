#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("The currently enabled action map on the PlayerInput component.")]
	[HelpURL(HelpUrls.InputSystem + "#UnityEngine_InputSystem_PlayerInput_currentActionMap")]
	public sealed class PlayerInputGetCurrentActionMap : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Reference to the currently enabled action map or null if no action map has been enabled by PlayerInput.")]
		[SerializeField]
		[WriteOnly]
		private InputActionMapRef _getCurrentActionMap;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _getCurrentActionMap);
		}
		
		public override void Execute()
		{
			_getCurrentActionMap.Value = _playerInput.Value.currentActionMap;
		}
		
		public override string GetSummary()
		{
			return "Get {_playerInput} action map -> {_getCurrentActionMap}";
		}
	}
}

#endif