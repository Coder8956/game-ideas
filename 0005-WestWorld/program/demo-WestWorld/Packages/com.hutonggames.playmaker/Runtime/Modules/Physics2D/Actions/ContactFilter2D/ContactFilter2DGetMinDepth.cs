
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter the results to only include Collider2D with a Z" +
		" coordinate (depth) greater than this value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-minDepth.html")]
	public sealed class ContactFilter2DGetMinDepth : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Min Depth")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMinDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getMinDepth);
		}
		
		public override void Execute()
		{
			_getMinDepth.Value = _contactFilter2D.Value.minDepth;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} minDepth -> {_getMinDepth}";
		}
	}
}
