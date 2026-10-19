#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Switch the current control scheme to one that fits the given set of devices.")]
	[HelpURL(HelpUrls.PlayerInput+"#UnityEngine_InputSystem_PlayerInput_SwitchCurrentControlScheme_UnityEngine_InputSystem_InputDevice___")]

	public sealed class PlayerInputSwitchCurrentControlScheme : BaseAction
	{
		
		[Tooltip("The PlayerInput.")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("A list of input devices. Note that if any of the devices is already paired to another player, " +
		         "the device will end up paired to both players.")]
		[SerializeField]
		private InputDeviceListVar _devices;
		
		[OptionalField]
		[Tooltip("True if the switch was successful, false otherwise. The latter can happen, for example, if actions does not have a control scheme that fits the given set of devices.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _devices);
		}
		
		public override void Execute()
		{
			var result = _playerInput.Value.SwitchCurrentControlScheme(_devices.Values);
			if (_result.IsAssigned)
			{
				_result.Value = result;
			}
		}
		
		public override string GetSummary()
		{
			return "Switch {_playerInput} control scheme to {_devices}";
		}
	}
}

#endif
