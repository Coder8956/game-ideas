
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("Whether or not this Collider generates contacts for Physics.ContactEvent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-providesContacts.html")]
	public sealed class ColliderGetProvidesContacts : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Provides Contacts")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getProvidesContacts;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getProvidesContacts);
		}
		
		public override void Execute()
		{
			_getProvidesContacts.Value = _collider.Value.providesContacts;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} provides contacts -> {_getProvidesContacts}";
		}
	}
}
