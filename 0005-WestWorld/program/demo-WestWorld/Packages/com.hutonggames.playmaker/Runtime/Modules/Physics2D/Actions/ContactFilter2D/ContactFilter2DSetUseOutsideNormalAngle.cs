
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
	public sealed class ContactFilter2DSetUseOutsideNormalAngle : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Set ContactFilter2D Use Outside Normal Angle")]
		[SerializeField]
		private BoolVar _setUseOutsideNormalAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _setUseOutsideNormalAngle);
		}
		
		public override void Execute()
		{
			var value = _contactFilter2D.Value;
			value.useOutsideNormalAngle = _setUseOutsideNormalAngle.Value;
			_contactFilter2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_contactFilter2D} Use Outside Normal Angle to {_setUseOutsideNormalAngle}";
		}
	}
}
