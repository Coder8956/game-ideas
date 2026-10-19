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
	                   "this event is triggered when the player previously lost a device and has now regained it or an equivalent device.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_onDeviceRegained")]

	public sealed class PlayerInputOnDeviceRegained : BaseOnEventAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Event sent when the player regains a device.")]
		[SerializeField]
		private EventRef _onDeviceRegained;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput);
		}
		
		public override void OnStart()
		{
			_playerInput.Value.onDeviceRegained += OnOnDeviceRegained;;
		}
		
		public override void OnStop()
		{
			_playerInput.Value.onDeviceRegained -= OnOnDeviceRegained;;
		}
		
		private void OnOnDeviceRegained(PlayerInput obj)
		{
			SendEvent(_onDeviceRegained);;
		}
	}
}

#endif