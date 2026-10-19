
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Retrieves all Colliders in contact with the Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.GetContacts.html")]
	public sealed class Physics2DGetRigidbodyContacts : BaseAction
	{
		
		[Tooltip("The rigidbody to retrieve contacts for.  All Colliders attached to this rigidbody" +
			" will be checked.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
			" Z depth, or normal angle.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[WriteOnly]
		[Tooltip("An array of ContactPoint2D used to receive the results.")]
		[SerializeField]
		private ContactPoint2DListRef _contacts;
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _contactFilter, _contacts);
		}
		
		public override void Execute()
		{
			//UnityEngine.Physics2D.GetContacts(UnityEngine.Rigidbody2D, UnityEngine.ContactFilter2D, System.Collections.Generic.List`1[[UnityEngine.ContactPoint2D, UnityEngine.Physics2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]);
			var resultCount = Physics2D.GetContacts(_rigidbody.Value, _contactFilter.Value, _contacts.Value);
			if (_resultCount.IsAssigned) _resultCount.Value = resultCount;
		}
		
		public override string GetSummary()
		{
			return "Physics2D Get Contacts: {_rigidbody} {_contactFilter} -> {_contacts} -> {_resultCount}";
		}
	}
}
