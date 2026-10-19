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
	public sealed class PlayerInputSetCurrentActionMap : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Set the currently enabled action map.")]
		[SerializeField]
		private InputActionMapVar _setCurrentActionMap;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _setCurrentActionMap);
		}
		
		public override void Execute()
		{
			_playerInput.Value.currentActionMap = _setCurrentActionMap.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playerInput} action map to {_setCurrentActionMap}";
		}
	}
}

#endif