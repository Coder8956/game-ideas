
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
	public sealed class ContactFilter2DGetMaxNormalAngle : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Max Normal Angle")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaxNormalAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getMaxNormalAngle);
		}
		
		public override void Execute()
		{
			_getMaxNormalAngle.Value = _contactFilter2D.Value.maxNormalAngle;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} maxNormalAngle -> {_getMaxNormalAngle}";
		}
	}
}
