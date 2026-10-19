#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Switch the player to use the given control scheme together with the given devices.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_SwitchCurrentControlScheme_System_String_UnityEngine_InputSystem_InputDevice___")]

	public sealed class PlayerInputSwitchCurrentControlScheme__Named : BaseAction
	{
		
		[Tooltip("The PlayerInput.")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Name of the control scheme.")]
		[SerializeField]
		private StringVar _controlScheme;
		
		[Tooltip("A list of input devices to consider for pairing against")]
		[SerializeField]
		private InputDeviceListVar _devices;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _controlScheme, _devices);
		}
		
		public override void Execute()
		{
			_playerInput.Value.SwitchCurrentControlScheme(_controlScheme.Value, _devices.Values);
		}
		
		public override string GetSummary()
		{
			return "Switch {_playerInput} control scheme to {_controlScheme} {_devices}";
		}
	}
}

#endif
