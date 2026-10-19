/* Changing in 6.3+
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.ContactPairHeader)]
	[ActionDescription("Instance ID of the first Rigidbody or the ArticualtionBody in the pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPairHeader-BodyInstanceID.html")]
	public sealed class ContactPairHeaderGetBodyInstanceID : BaseAction
	{
		
		[Tooltip("The ContactPairHeader")]
		[SerializeField]
		private ContactPairHeaderRef _contactPairHeader;
		
		[Tooltip("Get ContactPairHeader Body Instance ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getBodyInstanceID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPairHeader, _getBodyInstanceID);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getBodyInstanceID.Value = _contactPairHeader.Value.bodyInstanceID;
#else
			_getBodyInstanceID.Value = _contactPairHeader.Value.BodyInstanceID;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPairHeader} BodyInstanceID -> {_getBodyInstanceID}";
		}
	}
}
*/