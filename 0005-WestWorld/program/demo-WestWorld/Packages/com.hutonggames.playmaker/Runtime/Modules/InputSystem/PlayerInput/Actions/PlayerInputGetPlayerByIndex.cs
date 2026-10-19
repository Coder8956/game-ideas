#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Return the player with specified player index.")]
	[HelpURL(HelpUrls.PlayerInput+"#UnityEngine_InputSystem_PlayerInput_GetPlayerByIndex_System_Int32_")]

	public sealed class PlayerInputGetPlayerByIndex : BaseAction
	{
		
		[Tooltip("Player Index.")]
		[SerializeField]
		private IntegerVar _playerIndex;
		
		[Tooltip("Store the result in PlayerInput variable.")]
		[SerializeField]
		[WriteOnly]
		private PlayerInputRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerIndex, _result);
		}
		
		public override void Execute()
		{
			_result.Value = UnityEngine.InputSystem.PlayerInput.GetPlayerByIndex(_playerIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "Get player at {_playerIndex} -> {_result}";
		}
	}
}

#endif
