
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
	public sealed class ContactFilter2DGetUseNormalAngle : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Use Normal Angle")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseNormalAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getUseNormalAngle);
		}
		
		public override void Execute()
		{
			_getUseNormalAngle.Value = _contactFilter2D.Value.useNormalAngle;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} useNormalAngle -> {_getUseNormalAngle}";
		}
	}
}
