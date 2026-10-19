
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPair)]
	[ActionDescription("The first Collider component of the ContactPair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPair.html")]
	public sealed class ContactPairGetCollider : BaseAction
	{
		
		[Tooltip("The ContactPair")]
		[SerializeField]
		private ContactPairRef _contactPair;
		
		[Tooltip("Get ContactPair Collider")]
		[SerializeField]
		[WriteOnly]
		private ColliderVar _getCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPair, _getCollider);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getCollider.Value = _contactPair.Value.collider;
#else
			_getCollider.Value = _contactPair.Value.Collider;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPair} Collider -> {_getCollider}";
		}
	}
}

