
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
	public sealed class ContactFilter2DSetUseOutsideDepth : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Set ContactFilter2D Use Outside Depth")]
		[SerializeField]
		private BoolVar _setUseOutsideDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _setUseOutsideDepth);
		}
		
		public override void Execute()
		{
			var value = _contactFilter2D.Value;
			value.useOutsideDepth = _setUseOutsideDepth.Value;
			_contactFilter2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_contactFilter2D} Use Outside Depth to {_setUseOutsideDepth}";
		}
	}
}
