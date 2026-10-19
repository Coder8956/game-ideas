#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Get the optional camera associated with the player.")]
	[HelpURL(HelpUrls.PlayerInput+"#UnityEngine_InputSystem_PlayerInput_camera")]
	public sealed class PlayerInputGetCamera : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Get PlayerInput Camera")]
		[SerializeField]
		[WriteOnly]
		private CameraRef _getCamera;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _getCamera);
		}
		
		public override void Execute()
		{
			_getCamera.Value = _playerInput.Value.camera;
		}
		
		public override string GetSummary()
		{
			return "Get {_playerInput} camera -> {_getCamera}";
		}
	}
}
#endif