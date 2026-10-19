
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter the results to only include contacts with colli" +
		"sion normal angles that are greater than this angle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-minNormalAngle.html")]
	public sealed class ContactFilter2DSetMinNormalAngle : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Set ContactFilter2D Min Normal Angle")]
		[SerializeField]
		private FloatVar _setMinNormalAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _setMinNormalAngle);
		}
		
		public override void Execute()
		{
			var value = _contactFilter2D.Value;
			value.minNormalAngle = _setMinNormalAngle.Value;
			_contactFilter2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_contactFilter2D} Min Normal Angle to {_setMinNormalAngle}";
		}
	}
}
