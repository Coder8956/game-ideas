
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets to filter contact results based on trigger collider involvement.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-useTriggers.html")]
	public sealed class ContactFilter2DGetUseTriggers : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Use Triggers")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseTriggers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getUseTriggers);
		}
		
		public override void Execute()
		{
			_getUseTriggers.Value = _contactFilter2D.Value.useTriggers;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} useTriggers -> {_getUseTriggers}";
		}
	}
}
