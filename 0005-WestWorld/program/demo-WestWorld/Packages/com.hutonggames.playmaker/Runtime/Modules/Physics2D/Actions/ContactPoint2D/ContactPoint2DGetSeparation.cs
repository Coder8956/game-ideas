
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint2D)]
	[ActionDescription("Gets the distance between the colliders at the contact point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint2D-separation.html")]
	public sealed class ContactPoint2DGetSeparation : BaseAction
	{
		
		[Tooltip("The ContactPoint2D")]
		[SerializeField]
		private ContactPoint2DRef _contactPoint2D;
		
		[Tooltip("Get ContactPoint2D Separation")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSeparation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint2D, _getSeparation);
		}
		
		public override void Execute()
		{
			_getSeparation.Value = _contactPoint2D.Value.separation;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint2D} separation -> {_getSeparation}";
		}
	}
}
