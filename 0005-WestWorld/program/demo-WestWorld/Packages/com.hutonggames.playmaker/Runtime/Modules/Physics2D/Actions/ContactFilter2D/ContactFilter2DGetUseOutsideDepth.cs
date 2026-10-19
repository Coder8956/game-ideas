
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter within the minDepth and maxDepth range, or outs" +
		"ide that range.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-useOutsideDepth.html")]
	public sealed class ContactFilter2DGetUseOutsideDepth : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Use Outside Depth")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseOutsideDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getUseOutsideDepth);
		}
		
		public override void Execute()
		{
			_getUseOutsideDepth.Value = _contactFilter2D.Value.useOutsideDepth;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} useOutsideDepth -> {_getUseOutsideDepth}";
		}
	}
}
