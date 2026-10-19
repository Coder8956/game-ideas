
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint2D)]
	[ActionDescription("Gets the impulse applied at the contact point along the ContactPoint2D.normal.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint2D-normalImpulse.html")]
	public sealed class ContactPoint2DGetNormalImpulse : BaseAction
	{
		
		[Tooltip("The ContactPoint2D")]
		[SerializeField]
		private ContactPoint2DRef _contactPoint2D;
		
		[Tooltip("Get ContactPoint2D Normal Impulse")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getNormalImpulse;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint2D, _getNormalImpulse);
		}
		
		public override void Execute()
		{
			_getNormalImpulse.Value = _contactPoint2D.Value.normalImpulse;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint2D} normalImpulse -> {_getNormalImpulse}";
		}
	}
}
