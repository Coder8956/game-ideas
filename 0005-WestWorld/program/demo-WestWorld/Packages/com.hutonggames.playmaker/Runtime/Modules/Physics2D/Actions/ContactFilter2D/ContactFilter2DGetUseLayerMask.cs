
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
	public sealed class ContactFilter2DGetUseLayerMask : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Use Layer Mask")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseLayerMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getUseLayerMask);
		}
		
		public override void Execute()
		{
			_getUseLayerMask.Value = _contactFilter2D.Value.useLayerMask;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} useLayerMask -> {_getUseLayerMask}";
		}
	}
}
