
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPair)]
	[ActionDescription("The second Collider component of the ContactPair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPair.html")]
	public sealed class ContactPairGetOtherCollider : BaseAction
	{
		
		[Tooltip("The ContactPair")]
		[SerializeField]
		private ContactPairRef _contactPair;
		
		[Tooltip("Get ContactPair Other Collider")]
		[SerializeField]
		[WriteOnly]
		private ColliderVar _getOtherCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPair, _getOtherCollider);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getOtherCollider.Value = _contactPair.Value.otherCollider;
#else
			_getOtherCollider.Value = _contactPair.Value.OtherCollider;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPair} OtherCollider -> {_getOtherCollider}";
		}
	}
}

