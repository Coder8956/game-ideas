
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPairPoint)]
	[ActionDescription("The distance between the edges of Colliders at the contact point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPairPoint.html")]
	public sealed class ContactPairPointGetSeparation : BaseAction
	{
		
		[Tooltip("The ContactPairPoint")]
		[SerializeField]
		private ContactPairPointRef _contactPairPoint;
		
		[Tooltip("Get ContactPairPoint Separation")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSeparation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPairPoint, _getSeparation);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getSeparation.Value = _contactPairPoint.Value.separation;
#else
			_getSeparation.Value = _contactPairPoint.Value.Separation;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPairPoint} Separation -> {_getSeparation}";
		}
	}
}

