#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Whether the player is missed required devices. " +
	                   "This means that the player's input setup is probably at least partially non-functional.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_hasMissingRequiredDevices")]

	public sealed class PlayerInputGetHasMissingRequiredDevices : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("True if the player is missing devices required by the control scheme.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getHasMissingRequiredDevices;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _getHasMissingRequiredDevices);
		}
		
		public override void Execute()
		{
			_getHasMissingRequiredDevices.Value = _playerInput.Value.hasMissingRequiredDevices;
		}
		
		public override string GetSummary()
		{
			return "Get {_playerInput} has missing required devices -> {_getHasMissingRequiredDevices}";
		}
	}
}

#endif