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
	public sealed class PlayerInputSetDefaultActionMap : BaseAction
	{
		
		[Tooltip("The PlayerInput")]
		[SerializeField]
		private PlayerInputVar _playerInput;
		
		[Tooltip("Set PlayerInput Default Action Map")]
		[SerializeField]
		private StringVar _setDefaultActionMap;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playerInput, _setDefaultActionMap);
		}
		
		public override void Execute()
		{
			_playerInput.Value.defaultActionMap = _setDefaultActionMap.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playerInput} default action map to {_setDefaultActionMap}";
		}
	}
}

#endif
