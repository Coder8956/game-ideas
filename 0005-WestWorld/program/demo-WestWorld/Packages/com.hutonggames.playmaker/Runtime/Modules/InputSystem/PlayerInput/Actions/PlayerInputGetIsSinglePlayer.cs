#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSystem.PlayerInput)]
	[ActionDescription("Whether PlayerInput operates in single-player mode.")]
	[HelpURL(HelpUrls.InputSystem+"#UnityEngine_InputSystem_PlayerInput_isSinglePlayer")]

	public sealed class PlayerInputGetIsSinglePlayer : BaseAction
	{
		
		[Tooltip("If true, there is at most a single PlayerInput.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsSinglePlayer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getIsSinglePlayer);
		}
		
		public override void Execute()
		{
			_getIsSinglePlayer.Value = UnityEngine.InputSystem.PlayerInput.isSinglePlayer;
		}
		
		public override string GetSummary()
		{
			return "Get PlayerInput single player -> {_getIsSinglePlayer}";
		}
	}
}

#endif
