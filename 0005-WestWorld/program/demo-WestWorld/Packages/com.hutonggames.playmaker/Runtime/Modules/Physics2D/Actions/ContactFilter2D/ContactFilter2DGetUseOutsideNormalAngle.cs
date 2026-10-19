
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter within the minNormalAngle and maxNormalAngle ra" +
		"nge, or outside that range.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-useOutsideNormalAngle.ht" +
		"ml")]
	public sealed class ContactFilter2DGetUseOutsideNormalAngle : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Use Outside Normal Angle")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseOutsideNormalAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getUseOutsideNormalAngle);
		}
		
		public override void Execute()
		{
			_getUseOutsideNormalAngle.Value = _contactFilter2D.Value.useOutsideNormalAngle;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} useOutsideNormalAngle -> {_getUseOutsideNormalAngle}";
		}
	}
}
