#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("If split-screen is enabled, this is the index of the screen area used by the player.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_splitScreenIndex")]
	public sealed class PlayerInputGetSplitScreenIndex : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Get PlayerInput split screen index")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSplitScreenIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _getSplitScreenIndex);
		}
		
		public override void Execute()
		{
			_getSplitScreenIndex.Value = _playerInput.Value.splitScreenIndex;
		}
		
		public override string GetSummary()
		{
			return "Get {_playerInput} split screen index -> {_getSplitScreenIndex}";
		}
	}
}

#endif