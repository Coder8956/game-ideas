
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Retrieves all contact points for all of the Collider(s) attached to this Rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.GetContacts.html")]
	public sealed class Rigidbody2DGetContacts : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
			" Z depth, or normal angle.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[Tooltip("A list of ContactPoint2D used to receive the results.")]
		[SerializeField]
		private ContactPoint2DListVar _contacts;
		
		[OptionalField]
		[Tooltip("Store the number of contacts placed in the contacts array.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _contactFilter, _contacts);
		}
		
		public override void Execute()
		{
			var result = _rigidbody2D.Value.GetContacts(_contactFilter.Value, _contacts.Value);
			if (_result.IsAssigned) _result.Value = result;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} contacts {_contactFilter} -> {_contacts}"
				+ (_result.IsAssigned ? " -> {_result}" : "");
		}
	}
}
