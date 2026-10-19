#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Name or ID of the action map to enable by default.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_defaultActionMap")]

	public sealed class PlayerInputGetDefaultActionMap : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Get PlayerInput Default Action Map")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getDefaultActionMap;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _getDefaultActionMap);
		}
		
		public override void Execute()
		{
			_getDefaultActionMap.Value = _playerInput.Value.defaultActionMap;
		}
		
		public override string GetSummary()
		{
			return "Get {_playerInput} default action map -> {_getDefaultActionMap}";
		}
	}
}

#endif
