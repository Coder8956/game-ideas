
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("Indicates whether the collision response or reaction is enabled or disabled.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D-enabled.html")]
	public sealed class Collision2DGetEnabled : BaseAction
	{
		
		[Tooltip("The Collision2D")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("Get Collision2D Enabled")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision2D, _getEnabled);
		}
		
		public override void Execute()
		{
			_getEnabled.Value = _collision2D.Value.enabled;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision2D} enabled -> {_getEnabled}";
		}
	}
}
