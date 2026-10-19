
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPair)]
	[ActionDescription("Whether or not this pair is equivalent to a pair reported in MonoBehaviour.OnColl" +
		"isionStay events.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPair.html")]
	public sealed class ContactPairGetIsCollisionStay : BaseAction
	{
		
		[Tooltip("The ContactPair")]
		[SerializeField]
		private ContactPairRef _contactPair;
		
		[Tooltip("Get ContactPair Is Collision Stay")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsCollisionStay;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPair, _getIsCollisionStay);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getIsCollisionStay.Value = _contactPair.Value.isCollisionStay;
#else
			_getIsCollisionStay.Value = _contactPair.Value.IsCollisionStay;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPair} IsCollisionStay -> {_getIsCollisionStay}";
		}
	}
}

