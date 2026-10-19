#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("The default control scheme to try to activate when the PlayerInput component is enabled")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_defaultControlScheme")]
	public sealed class PlayerInputSetDefaultControlScheme : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Name of the default control scheme.")]
		[SerializeField]
		private StringVar _setDefaultControlScheme;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _setDefaultControlScheme);
		}
		
		public override void Execute()
		{
			_playerInput.Value.defaultControlScheme = _setDefaultControlScheme.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playerInput} default control scheme to {_setDefaultControlScheme}";
		}
	}
}

#endif
