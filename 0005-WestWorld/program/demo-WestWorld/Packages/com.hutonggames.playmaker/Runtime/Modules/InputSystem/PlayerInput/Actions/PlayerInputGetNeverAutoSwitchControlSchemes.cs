#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("If true, do not automatically switch control schemes even when there is only a single player. " +
	                   "By default, this property is false.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_neverAutoSwitchControlSchemes")]

	public sealed class PlayerInputGetNeverAutoSwitchControlSchemes : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("If true, do not switch control schemes when other devices are used.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getNeverAutoSwitchControlSchemes;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _getNeverAutoSwitchControlSchemes);
		}
		
		public override void Execute()
		{
			_getNeverAutoSwitchControlSchemes.Value = _playerInput.Value.neverAutoSwitchControlSchemes;
		}
		
		public override string GetSummary()
		{
			return "Get {_playerInput} never auto switch control schemes -> {_getNeverAutoSwitchControlSchemes}";
		}
	}
}

#endif
