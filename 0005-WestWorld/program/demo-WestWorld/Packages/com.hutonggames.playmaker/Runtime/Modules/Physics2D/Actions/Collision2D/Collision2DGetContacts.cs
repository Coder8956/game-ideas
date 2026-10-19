
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("The specific points of contact with the incoming Collider2D. You should avoid usi" +
		"ng this as it produces memory garbage. Use GetContact or GetContacts instead.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D-contacts.html")]
	public sealed class Collision2DGetContacts : BaseAction
	{
		
		[Tooltip("The Collision2D")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("Get Collision2D Contacts")]
		[SerializeField]
		[WriteOnly]
		private ContactPoint2DListRef _getContacts;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision2D, _getContacts);
		}
		
		public override void Execute()
		{
			_getContacts.Values = _collision2D.Value.contacts;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision2D} contacts -> {_getContacts}";
		}
	}
}
