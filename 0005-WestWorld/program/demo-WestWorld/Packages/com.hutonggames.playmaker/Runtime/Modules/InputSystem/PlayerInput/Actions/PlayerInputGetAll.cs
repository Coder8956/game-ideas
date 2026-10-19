#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("List of all players that are currently joined.")]
	[HelpURL(HelpUrls.PlayerInput+"#UnityEngine_InputSystem_PlayerInput_all")]
	public sealed class PlayerInputGetAll : BaseAction
	{
		
		[Tooltip("Get PlayerInput Controls Changed Message")]
		[SerializeField]
		[WriteOnly]
		private PlayerInputListRef _getALl;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getALl);
		}
		
		public override void Execute()
		{
			_getALl.Value = new List<PlayerInput>(PlayerInput.all);
		}
		
		public override string GetSummary()
		{
			return "Get all players -> {_getALl}";
		}
	}
}

#endif
