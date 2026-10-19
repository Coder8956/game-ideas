
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPairHeader)]
	[ActionDescription("The first Rigidbody or ArticulationBody in the pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPairHeader.html")]
	public sealed class ContactPairHeaderGetBody : BaseAction
	{
		
		[Tooltip("The ContactPairHeader")]
		[SerializeField]
		private ContactPairHeaderRef _contactPairHeader;
		
		[Tooltip("Get ContactPairHeader Body")]
		[SerializeField]
		[WriteOnly]
		private ComponentRef _getBody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPairHeader, _getBody);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getBody.Value = _contactPairHeader.Value.body;
#else
			_getBody.Value = _contactPairHeader.Value.Body;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPairHeader} Body -> {_getBody}";
		}
	}
}

