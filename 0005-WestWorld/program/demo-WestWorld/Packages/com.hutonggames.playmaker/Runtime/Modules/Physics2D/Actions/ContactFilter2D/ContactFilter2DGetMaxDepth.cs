
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter the results to only include Collider2D with a Z" +
		" coordinate (depth) less than this value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-maxDepth.html")]
	public sealed class ContactFilter2DGetMaxDepth : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Max Depth")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaxDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getMaxDepth);
		}
		
		public override void Execute()
		{
			_getMaxDepth.Value = _contactFilter2D.Value.maxDepth;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} maxDepth -> {_getMaxDepth}";
		}
	}
}
