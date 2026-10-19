#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Send an event when an action is triggered. " +
	                   "\n\nNOTE: NotificationBehavior should be set to InvokeCSharpEvents.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_onActionTriggered")]

	public sealed class PlayerInputOnActionTriggered__Named : BaseOnEventAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;

		[Tooltip("The name of the action to listen for.")]
		[SerializeField]
		private StringVar _actionName;
		
		[Tooltip("Event to send when the action is triggered.")]
		[SerializeField]
		private EventRef _event;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _actionName, _event);
		}
		
		public override void OnStart()
		{
			_playerInput.Value.onActionTriggered += OnOnActionTriggered;;
		}
		
		public override void OnStop()
		{
			_playerInput.Value.onActionTriggered -= OnOnActionTriggered;;
		}
		
		private void OnOnActionTriggered(InputAction.CallbackContext context)
		{
			if (string.Equals(context.action.name, _actionName.Value, StringComparison.Ordinal))
			{
				SendEvent(_event);
			};
		}
	}
}

#endif