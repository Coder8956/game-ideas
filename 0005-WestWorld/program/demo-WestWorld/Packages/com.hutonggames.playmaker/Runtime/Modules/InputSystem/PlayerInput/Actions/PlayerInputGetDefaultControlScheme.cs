#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("The default control scheme to try to activate when the PlayerInput component is enabled.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_defaultControlScheme")]
	public sealed class PlayerInputGetDefaultControlScheme : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Name of the default control scheme.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getDefaultControlScheme;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _getDefaultControlScheme);
		}
		
		public override void Execute()
		{
			_getDefaultControlScheme.Value = _playerInput.Value.defaultControlScheme;
		}
		
		public override string GetSummary()
		{
			return "Get {_playerInput} default control scheme -> {_getDefaultControlScheme}";
		}
	}
}

#endif
