
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter the results by depth using minDepth and maxDept" +
		"h.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-useDepth.html")]
	public sealed class ContactFilter2DGetUseDepth : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Use Depth")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getUseDepth);
		}
		
		public override void Execute()
		{
			_getUseDepth.Value = _contactFilter2D.Value.useDepth;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} useDepth -> {_getUseDepth}";
		}
	}
}
