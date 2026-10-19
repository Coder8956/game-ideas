
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Retrieves all contact points in contact with the Collider, " +
	                   "with the results filtered by the ContactFilter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.GetContacts.html")]
	public sealed class Physics2DGetContacts : BaseAction
	{
		
		[Tooltip("Collider.")]
		[SerializeField]
		private Collider2DVar _collider;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
			" Z depth, or normal angle.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[WriteOnly]
		[Tooltip("A list of ContactPoint2D used to receive the results.")]
		[SerializeField]
		private ContactPoint2DListRef _contacts;
		
		[WriteOnly]
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		private IntegerRef _resultCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _contactFilter, _contacts);
		}
		
		public override void Execute()
		{
			var resultCount = Physics2D.GetContacts(_collider.Value, _contactFilter.Value, _contacts.Value);
			if (_resultCount.IsAssigned) _resultCount.Value = resultCount;
		}
		
		public override string GetSummary()
		{
			return "{_collider} Get Contacts: {_contactFilter} -> {_contacts} -> {_resultCount}";
		}
	}
}
