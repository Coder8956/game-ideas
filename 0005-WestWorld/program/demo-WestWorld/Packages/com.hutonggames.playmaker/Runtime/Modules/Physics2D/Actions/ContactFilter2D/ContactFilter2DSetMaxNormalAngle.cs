
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter the results to only include contacts with colli" +
		"sion normal angles that are less than this angle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-maxNormalAngle.html")]
	public sealed class ContactFilter2DSetMaxNormalAngle : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Set ContactFilter2D Max Normal Angle")]
		[SerializeField]
		private FloatVar _setMaxNormalAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _setMaxNormalAngle);
		}
		
		public override void Execute()
		{
			var value = _contactFilter2D.Value;
			value.maxNormalAngle = _setMaxNormalAngle.Value;
			_contactFilter2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_contactFilter2D} Max Normal Angle to {_setMaxNormalAngle}";
		}
	}
}
