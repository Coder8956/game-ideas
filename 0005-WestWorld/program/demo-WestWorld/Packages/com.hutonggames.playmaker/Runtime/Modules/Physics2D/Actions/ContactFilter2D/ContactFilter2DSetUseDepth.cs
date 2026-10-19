
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
	public sealed class ContactFilter2DSetUseDepth : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Set ContactFilter2D Use Depth")]
		[SerializeField]
		private BoolVar _setUseDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _setUseDepth);
		}
		
		public override void Execute()
		{
			var value = _contactFilter2D.Value;
			value.useDepth = _setUseDepth.Value;
			_contactFilter2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_contactFilter2D} Use Depth to {_setUseDepth}";
		}
	}
}
