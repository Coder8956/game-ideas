
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
	public sealed class ColliderSetHasModifiableContacts : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Set Collider Has Modifiable Contacts")]
		[SerializeField]
		private BoolVar _setHasModifiableContacts;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _setHasModifiableContacts);
		}
		
		public override void Execute()
		{
			_collider.Value.hasModifiableContacts = _setHasModifiableContacts.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider} has modifiable contacts to {_setHasModifiableContacts}";
		}
	}
}
