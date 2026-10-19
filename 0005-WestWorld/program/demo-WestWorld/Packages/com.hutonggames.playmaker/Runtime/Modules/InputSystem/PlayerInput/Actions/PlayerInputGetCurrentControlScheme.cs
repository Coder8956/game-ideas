#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Get the name of the currently active control scheme.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_currentControlScheme")]
	public sealed class PlayerInputGetCurrentControlScheme : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Name of the currently active control scheme or null.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getCurrentControlScheme;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _getCurrentControlScheme);
		}
		
		public override void Execute()
		{
			_getCurrentControlScheme.Value = _playerInput.Value.currentControlScheme;
		}
		
		public override string GetSummary()
		{
			return "Get {_playerInput} current control scheme -> {_getCurrentControlScheme}";
		}
	}
}

#endif