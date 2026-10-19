
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter results by layer mask.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-useLayerMask.html")]
	public sealed class ContactFilter2DSetUseLayerMask : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Set ContactFilter2D Use Layer Mask")]
		[SerializeField]
		private BoolVar _setUseLayerMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _setUseLayerMask);
		}
		
		public override void Execute()
		{
			var value = _contactFilter2D.Value;
			value.useLayerMask = _setUseLayerMask.Value;
			_contactFilter2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_contactFilter2D} Use Layer Mask to {_setUseLayerMask}";
		}
	}
}
