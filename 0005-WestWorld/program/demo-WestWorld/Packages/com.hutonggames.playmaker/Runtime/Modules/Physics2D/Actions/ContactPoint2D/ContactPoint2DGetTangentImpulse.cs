
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint2D)]
	[ActionDescription("Gets the impulse applied at the contact point which is perpendicular to the Conta" +
		"ctPoint2D.normal.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint2D-tangentImpulse.html")]
	public sealed class ContactPoint2DGetTangentImpulse : BaseAction
	{
		
		[Tooltip("The ContactPoint2D")]
		[SerializeField]
		private ContactPoint2DRef _contactPoint2D;
		
		[Tooltip("Get ContactPoint2D Tangent Impulse")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTangentImpulse;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint2D, _getTangentImpulse);
		}
		
		public override void Execute()
		{
			_getTangentImpulse.Value = _contactPoint2D.Value.tangentImpulse;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint2D} tangentImpulse -> {_getTangentImpulse}";
		}
	}
}
