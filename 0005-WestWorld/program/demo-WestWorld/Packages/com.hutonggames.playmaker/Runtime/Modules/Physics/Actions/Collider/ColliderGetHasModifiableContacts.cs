
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("Specify whether this Collider\'s contacts are modifiable or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-hasModifiableContacts.html")]
	public sealed class ColliderGetHasModifiableContacts : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Has Modifiable Contacts")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getHasModifiableContacts;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getHasModifiableContacts);
		}
		
		public override void Execute()
		{
			_getHasModifiableContacts.Value = _collider.Value.hasModifiableContacts;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} has modifiable contacts -> {_getHasModifiableContacts}";
		}
	}
}
