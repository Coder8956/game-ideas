#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Set the optional camera associated with the player.")]
	[HelpURL(HelpUrls.PlayerInput+"#UnityEngine_InputSystem_PlayerInput_camera")]
	public sealed class PlayerInputSetCamera : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Set PlayerInput Camera")]
		[SerializeField, CanBeNullOrEmpty]
		private CameraVar _setCamera;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput);
		}
		
		public override void Execute()
		{
			_playerInput.Value.camera = _setCamera.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playerInput} camera to {_setCamera}";
		}
	}
}

#endif