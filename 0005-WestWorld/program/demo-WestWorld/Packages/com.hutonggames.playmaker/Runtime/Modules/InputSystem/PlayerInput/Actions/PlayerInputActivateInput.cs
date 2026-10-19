#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Enable input on the player, by enabling the current action map.")]
	[HelpURL(HelpUrls.PlayerInput+"#UnityEngine_InputSystem_PlayerInput_ActivateInput")]
	public sealed class PlayerInputActivateInput : BaseAction
	{
		
		[Tooltip("The PlayerInput.")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		public override bool CanExecute() => CheckParameters(_playerInput);

		public override void Execute() => _playerInput.Value.ActivateInput();

		public override string GetSummary() => "Activate {_playerInput} input";
	}
}

#endif
