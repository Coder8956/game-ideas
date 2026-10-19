/* Changing in 6.3+
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.ContactPairHeader)]
	[ActionDescription("Instance ID of the second Rigidbody or the ArticualtionBody in the pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPairHeader-OtherBodyInstanceID.ht" +
		"ml")]
	public sealed class ContactPairHeaderGetOtherBodyInstanceID : BaseAction
	{
		
		[Tooltip("The ContactPairHeader")]
		[SerializeField]
		private ContactPairHeaderRef _contactPairHeader;
		
		[Tooltip("Get ContactPairHeader Other Body Instance ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getOtherBodyInstanceID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPairHeader, _getOtherBodyInstanceID);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getOtherBodyInstanceID.Value = _contactPairHeader.Value.otherBodyInstanceID;
#else
			_getOtherBodyInstanceID.Value = _contactPairHeader.Value.OtherBodyInstanceID;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPairHeader} OtherBodyInstanceID -> {_getOtherBodyInstanceID}";
		}
	}
}
*/