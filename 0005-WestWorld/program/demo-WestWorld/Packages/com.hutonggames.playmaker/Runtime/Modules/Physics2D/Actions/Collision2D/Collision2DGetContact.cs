
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("Gets the contact point at the specified index.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D.GetContact.html")]
	public sealed class Collision2DGetContact : BaseAction
	{
		
		[Tooltip("The Collision2D")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("The index of the contact point to get.")]
		[SerializeField]
		private IntegerVar _index;
		
		[Tooltip("Get Collision2D Contacts")]
		[SerializeField]
		[WriteOnly]
		private ContactPoint2DRef _getContact;
		
		public override bool CanExecute() => CheckParameters(_collision2D, _index, _getContact);

		public override void Execute() => _getContact.Value = _collision2D.Value.GetContact(_index.Value);

		public override string GetSummary() => "Get {_collision2D} contact {_index} -> {_getContact}";
	}
}
