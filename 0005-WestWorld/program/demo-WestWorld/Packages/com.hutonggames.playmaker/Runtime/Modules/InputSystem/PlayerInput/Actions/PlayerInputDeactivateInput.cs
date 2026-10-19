#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Disable input on the player, by disabling the current action map.")]
	[HelpURL(HelpUrls.PlayerInput+"#UnityEngine_InputSystem_PlayerInput_DeactivateInput")]
	public sealed class PlayerInputDeactivateInput : BaseAction
	{
		
		[Tooltip("The PlayerInput.")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		public override bool CanExecute() => CheckParameters(_playerInput);

		public override void Execute() => _playerInput.Value.DeactivateInput();

		public override string GetSummary()
		{
			return "Deactivate input on {_playerInput}";
		}
	}
}

#endif
