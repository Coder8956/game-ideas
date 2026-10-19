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
	[ActionDescription("If notificationBehavior is InvokeCSharpEvents, " +
	                   "this event is triggered when the controls used by the players are changed.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_onControlsChanged")]

	public sealed class PlayerInputOnControlsChanged : BaseOnEventAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Event to send when the controls used by the players are changed.")]
		[SerializeField]
		private EventRef _onControlsChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput);
		}
		
		public override void OnStart()
		{
			_playerInput.Value.onControlsChanged += OnOnControlsChanged;;
		}
		
		public override void OnStop()
		{
			_playerInput.Value.onControlsChanged -= OnOnControlsChanged;;
		}
		
		private void OnOnControlsChanged(PlayerInput obj)
		{
			SendEvent(_onControlsChanged);;
		}
	}
}

#endif