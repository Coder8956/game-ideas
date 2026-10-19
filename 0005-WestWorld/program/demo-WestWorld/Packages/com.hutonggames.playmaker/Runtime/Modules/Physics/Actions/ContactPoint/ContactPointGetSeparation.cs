
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint)]
	[ActionDescription("The distance between the colliders at the contact point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint-separation.html")]
	public sealed class ContactPointGetSeparation : BaseAction
	{
		
		[Tooltip("The ContactPoint")]
		[SerializeField]
		private ContactPointRef _contactPoint;
		
		[Tooltip("Get ContactPoint Separation")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSeparation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint, _getSeparation);
		}
		
		public override void Execute()
		{
			_getSeparation.Value = _contactPoint.Value.separation;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint} separation -> {_getSeparation}";
		}
	}
}
