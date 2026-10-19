
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision)]
	[ActionDescription("Retrieves all contact points for this collision.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision.GetContacts.html")]
	public sealed class CollisionGetContacts__NonAlloc : BaseAction
	{
		
		[Tooltip("The Collision.")]
		[SerializeField]
		private CollisionRef _collision;
		
		[Tooltip("A list of ContactPoint used to receive the results.")]
		[SerializeField]
		private ContactPointListRef _contacts;
		
		[Tooltip("Store the number of contacts in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _storeCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision, _contacts, _storeCount);
		}
		
		public override void Execute()
		{
			//UnityEngine.Collision.GetContacts(System.Collections.Generic.List`1[[UnityEngine.ContactPoint, UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]);
			var count = _collision.Value.GetContacts(_contacts.Value);
			if (_storeCount.IsAssigned) _storeCount.Value = count;
		}
		
		public override string GetSummary() => "{_collision} Get Contacts -> {_contacts} -> count: {_storeCount}";
	}
}
