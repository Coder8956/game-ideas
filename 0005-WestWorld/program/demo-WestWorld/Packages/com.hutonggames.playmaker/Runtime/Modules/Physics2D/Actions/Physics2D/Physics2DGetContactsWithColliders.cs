
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Retrieves all Colliders in contact with the Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.GetContacts.html")]
	public sealed class Physics2DGetContactsWithColliders : BaseAction
	{
		
		[Tooltip("Collider.")]
		[SerializeField]
		private Collider2DVar _collider;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
			" Z depth, or normal angle.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[WriteOnly]
		[Tooltip("Colliders.")]
		[SerializeField]
		private Collider2DListRef _colliders;
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _contactFilter, _colliders);
		}
		
		public override void Execute()
		{
			//UnityEngine.Physics2D.GetContacts(UnityEngine.Collider2D, UnityEngine.ContactFilter2D, System.Collections.Generic.List`1[[UnityEngine.Collider2D, UnityEngine.Physics2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]);
			var resultCount = Physics2D.GetContacts(_collider.Value, _contactFilter.Value, _colliders.Value);
			if (_resultCount.IsAssigned) _resultCount.Value = resultCount;
		}
		
		public override string GetSummary()
		{
			return "Physics2D Get Contacts: {_collider} {_contactFilter} {_colliders} -> {_resultCount}";
		}
	}
}
