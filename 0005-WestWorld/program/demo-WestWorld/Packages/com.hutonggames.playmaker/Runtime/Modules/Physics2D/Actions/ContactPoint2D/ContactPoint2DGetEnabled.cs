
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint2D)]
	[ActionDescription("Indicates whether the collision response or reaction is enabled or disabled.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint2D-enabled.html")]
	public sealed class ContactPoint2DGetEnabled : BaseAction
	{
		
		[Tooltip("The ContactPoint2D")]
		[SerializeField]
		private ContactPoint2DRef _contactPoint2D;
		
		[Tooltip("Get ContactPoint2D Enabled")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint2D, _getEnabled);
		}
		
		public override void Execute()
		{
			_getEnabled.Value = _contactPoint2D.Value.enabled;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint2D} enabled -> {_getEnabled}";
		}
	}
}
