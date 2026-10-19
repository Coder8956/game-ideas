#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Switch the player to use the given action map")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_SwitchCurrentActionMap_System_String_")]
	public sealed class PlayerInputSwitchCurrentActionMap : BaseAction
	{
		
		[Tooltip("The PlayerInput.")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Name of the action map or its ID.")]
		[SerializeField]
		private StringVar _mapNameOrId;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _mapNameOrId);
		}
		
		public override void Execute()
		{
			_playerInput.Value.SwitchCurrentActionMap(_mapNameOrId.Value);
		}
		
		public override string GetSummary()
		{
			return "Switch {_playerInput} action map to {_mapNameOrId}";
		}
	}
}

#endif
