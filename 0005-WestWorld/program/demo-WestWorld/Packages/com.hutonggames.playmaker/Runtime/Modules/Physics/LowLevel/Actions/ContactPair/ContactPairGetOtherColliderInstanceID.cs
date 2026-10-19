/* Changing in 6.3+
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.ContactPair)]
	[ActionDescription("Instance ID of the second Collider in the ContactPair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPair-OtherColliderInstanceID.html" +
		"")]
	public sealed class ContactPairGetOtherColliderInstanceID : BaseAction
	{
		
		[Tooltip("The ContactPair")]
		[SerializeField]
		private ContactPairRef _contactPair;
		
		[Tooltip("Get ContactPair Other Collider Instance ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getOtherColliderInstanceID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPair, _getOtherColliderInstanceID);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getOtherColliderInstanceID.Value = _contactPair.Value.otherColliderInstanceID;
#else
			_getOtherColliderInstanceID.Value = _contactPair.Value.OtherColliderInstanceID;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPair} OtherColliderInstanceID -> {_getOtherColliderInstanceID}";
		}
	}
}
*/