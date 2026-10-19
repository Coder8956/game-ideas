#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Get the input actions associated with the player.")]
	[HelpURL(HelpUrls.PlayerInput+"#UnityEngine_InputSystem_PlayerInput_actions")]
	public sealed class PlayerInputGetActions : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Get PlayerInput Actions")]
		[SerializeField]
		[WriteOnly]
		private InputActionAssetRef _getActions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _getActions);
		}
		
		public override void Execute()
		{
			_getActions.Value = _playerInput.Value.actions;
		}
		
		public override string GetSummary()
		{
			return "Get {_playerInput} actions -> {_getActions}";
		}
	}
}

#endif