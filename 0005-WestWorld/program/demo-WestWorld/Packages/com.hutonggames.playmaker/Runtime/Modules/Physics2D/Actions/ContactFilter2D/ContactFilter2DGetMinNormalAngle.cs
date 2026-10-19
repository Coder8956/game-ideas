
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
	public sealed class ContactFilter2DGetMinNormalAngle : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Min Normal Angle")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMinNormalAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getMinNormalAngle);
		}
		
		public override void Execute()
		{
			_getMinNormalAngle.Value = _contactFilter2D.Value.minNormalAngle;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} minNormalAngle -> {_getMinNormalAngle}";
		}
	}
}
