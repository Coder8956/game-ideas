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
	public sealed class PlayerInputGetAction : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("The name of the action to get.")]
		[SerializeField]
		private StringVar _actionName;
		
		[Tooltip("Store the result.")]
		[SerializeField, WriteOnly]
		private InputActionRef _result;
		
		public override bool CanExecute() => CheckParameters(_playerInput, _actionName, _result);

		public override void Execute() => _result.Value = _playerInput.Value.actions[_actionName.Value];

		public override string GetSummary() => "Get {_playerInput} {_actionName} action -> {_result}";
	}
}

#endif