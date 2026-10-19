#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Unique, zero-based index of the player. For example, 2 for the third player.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_playerIndex")]


	public sealed class PlayerInputGetPlayerIndex : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Get PlayerInput player index")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPlayerIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _getPlayerIndex);
		}
		
		public override void Execute()
		{
			_getPlayerIndex.Value = _playerInput.Value.playerIndex;
		}
		
		public override string GetSummary()
		{
			return "Get {_playerInput} player index -> {_getPlayerIndex}";
		}
	}
}

#endif