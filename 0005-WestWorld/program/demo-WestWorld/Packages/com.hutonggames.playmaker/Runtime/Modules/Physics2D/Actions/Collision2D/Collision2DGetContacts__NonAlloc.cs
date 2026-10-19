
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("Retrieves all contact points for contacts between collider and otherCollider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D.GetContacts.html")]
	public sealed class Collision2DGetContacts__NonAlloc : BaseAction
	{
		
		[Tooltip("The Collision2D.")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("A list of ContactPoint2D used to receive the results.")]
		[SerializeField]
		private ContactPoint2DListVar _contacts;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision2D, _contacts, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Collision2D.GetContacts(System.Collections.Generic.List`1[[UnityEngine.ContactPoint2D, UnityEngine.Physics2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]);
			_result.Value = _collision2D.Value.GetContacts(_contacts.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Contacts {_collision2D} {_contacts} -> {_result}";
		}
	}
}
