
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter the results by the collision\'s normal angle usi" +
		"ng minNormalAngle and maxNormalAngle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-useNormalAngle.html")]
	public sealed class ContactFilter2DSetUseNormalAngle : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Set ContactFilter2D Use Normal Angle")]
		[SerializeField]
		private BoolVar _setUseNormalAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _setUseNormalAngle);
		}
		
		public override void Execute()
		{
			var value = _contactFilter2D.Value;
			value.useNormalAngle = _setUseNormalAngle.Value;
			_contactFilter2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_contactFilter2D} Use Normal Angle to {_setUseNormalAngle}";
		}
	}
}
