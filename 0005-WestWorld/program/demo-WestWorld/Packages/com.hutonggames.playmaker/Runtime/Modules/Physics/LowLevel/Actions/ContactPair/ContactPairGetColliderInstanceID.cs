/* Changing in 6.3+
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.ContactPair)]
	[ActionDescription("Instance ID of the first Collider in the ContactPair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPair-ColliderInstanceID.html")]
	public sealed class ContactPairGetColliderInstanceID : BaseAction
	{
		
		[Tooltip("The ContactPair")]
		[SerializeField]
		private ContactPairRef _contactPair;
		
		[Tooltip("Get ContactPair Collider Instance ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getColliderInstanceID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPair, _getColliderInstanceID);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getColliderInstanceID.Value = _contactPair.Value.colliderInstanceID;
#else
			_getColliderInstanceID.Value = _contactPair.Value.ColliderInstanceID;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPair} ColliderInstanceID -> {_getColliderInstanceID}";
		}
	}
}
*/