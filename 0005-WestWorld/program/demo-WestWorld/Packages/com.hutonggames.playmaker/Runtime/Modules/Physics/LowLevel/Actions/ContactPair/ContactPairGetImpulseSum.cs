
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPair)]
	[ActionDescription("Total impulse sum of the pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPair.html")]
	public sealed class ContactPairGetImpulseSum : BaseAction
	{
		
		[Tooltip("The ContactPair")]
		[SerializeField]
		private ContactPairRef _contactPair;
		
		[Tooltip("Get ContactPair Impulse Sum")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getImpulseSum;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPair, _getImpulseSum);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getImpulseSum.Value = _contactPair.Value.impulseSum;
#else
			_getImpulseSum.Value = _contactPair.Value.ImpulseSum;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPair} ImpulseSum -> {_getImpulseSum}";
		}
	}
}

