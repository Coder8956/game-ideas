
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Retrieves all contact points for this Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.GetContacts.html")]
	public sealed class Collider2DGetContactsWithColliders : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate;
		
		[Tooltip("The Collider2D.")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
			" Z depth, or normal angle.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[WriteOnly]
		[Tooltip("A list of Collider2D used to receive the results.")]
		[SerializeField]
		private Collider2DListRef _colliders;
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _contactFilter, _colliders);
		}
		
		public override void Execute()
		{
			//UnityEngine.Collider2D.GetContacts(UnityEngine.ContactFilter2D, System.Collections.Generic.List`1[[UnityEngine.Collider2D, UnityEngine.Physics2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]);
			var resultCount = _collider2D.Value.GetContacts(_contactFilter.Value, _colliders.Value);
			if (_resultCount.IsAssigned) _resultCount.Value = resultCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} contacts {_contactFilter} -> {_colliders} -> {_resultCount}";
		}
	}
}
