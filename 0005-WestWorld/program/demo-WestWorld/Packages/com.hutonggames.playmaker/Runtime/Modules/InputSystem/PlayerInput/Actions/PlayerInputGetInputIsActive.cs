#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using UnityEngine;
using System;

namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Get whether input on the player is active.")]
	[HelpURL(HelpUrls.PlayerInput+"#UnityEngine_InputSystem_PlayerInput_inputIsActive")]
	public sealed class PlayerInputGetInputIsActive : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("If true, the player is receiving input.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getInputIsActive;
		
		public override bool CanExecute() => CheckParameters(_playerInput, _getInputIsActive);

		public override void Execute() => _getInputIsActive.Value = _playerInput.Value.inputIsActive;

		public override string GetSummary() => "Get {_playerInput} input is active -> {_getInputIsActive}";
	}
}

#endif