#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Determines how the component notifies listeners about input actions " +
	                   "and other input-related events pertaining to the player.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_notificationBehavior")]
	public sealed class PlayerInputSetNotificationBehavior : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("How to trigger notifications on events.")]
		[SerializeField]
		private PlayerNotifications _setNotificationBehavior;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput);
		}
		
		public override void Execute()
		{
			_playerInput.Value.notificationBehavior = _setNotificationBehavior;
		}
		
		public override string GetSummary()
		{
			return "Set {_playerInput} notification behavior to {_setNotificationBehavior}";
		}
	}
}

#endif