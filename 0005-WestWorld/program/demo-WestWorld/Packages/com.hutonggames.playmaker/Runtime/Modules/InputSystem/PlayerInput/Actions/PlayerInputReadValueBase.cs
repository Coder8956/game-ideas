#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_ReadValue__1")]
	public abstract class PlayerInputReadValueBase : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[DisplayOrder(-1000)]
		[Tooltip("The PlayerInput.")]
		[SerializeField]
		protected PlayerInputVar _playerInput;
		
		[DisplayOrder(-999)]
		[Tooltip("The name of the action.")]
		[SerializeField]
		protected StringVar _actionName;

		private PlayerInput _cachedPlayerInput;
		private InputAction _cachedInputAction;
		
		public override bool CanExecute() => CheckParameters(_playerInput, _actionName);

		protected InputAction GetInputAction()
		{
			if (_playerInput.Value == null) return null;
			
			if (_cachedInputAction == null || _cachedPlayerInput != _playerInput.Value)
			{
				_cachedPlayerInput = _playerInput.Value;
				_cachedInputAction = _playerInput.Value.actions[_actionName.Value];
			}
			return _cachedInputAction;
		}

		public override string GetSummary() => "Read {_playerInput} {_actionName} -> {_value}";
	}
}

#endif
