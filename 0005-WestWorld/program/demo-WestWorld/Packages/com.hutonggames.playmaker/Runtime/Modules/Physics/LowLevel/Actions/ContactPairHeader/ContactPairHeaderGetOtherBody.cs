
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPairHeader)]
	[ActionDescription("The second Rigidbody or ArticulationBody in the pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPairHeader.html")]
	public sealed class ContactPairHeaderGetOtherBody : BaseAction
	{
		
		[Tooltip("The ContactPairHeader")]
		[SerializeField]
		private ContactPairHeaderRef _contactPairHeader;
		
		[Tooltip("Get ContactPairHeader Other Body")]
		[SerializeField]
		[WriteOnly]
		private ComponentRef _getOtherBody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPairHeader, _getOtherBody);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getOtherBody.Value = _contactPairHeader.Value.otherBody;
#else
			_getOtherBody.Value = _contactPairHeader.Value.OtherBody;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPairHeader} OtherBody -> {_getOtherBody}";
		}
	}
}

