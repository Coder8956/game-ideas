#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Set the input actions associated with the player..")]
	[HelpURL(HelpUrls.PlayerInput+"#UnityEngine_InputSystem_PlayerInput_actions")]	public sealed class PlayerInputSetActions : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Set PlayerInput Actions")]
		[SerializeField, CanBeNullOrEmpty]
		private InputActionAssetVar _setActions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput);
		}
		
		public override void Execute()
		{
			_playerInput.Value.actions = _setActions.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playerInput} actions to {_setActions}";
		}
	}
}
#endif