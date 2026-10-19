
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPairHeader)]
	[ActionDescription("Number of ContactPairs that this header contains.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPairHeader.html")]
	public sealed class ContactPairHeaderGetPairCount : BaseAction
	{
		
		[Tooltip("The ContactPairHeader")]
		[SerializeField]
		private ContactPairHeaderRef _contactPairHeader;
		
		[Tooltip("Get ContactPairHeader Pair Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPairCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPairHeader, _getPairCount);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getPairCount.Value = _contactPairHeader.Value.pairCount;
#else
			_getPairCount.Value = _contactPairHeader.Value.PairCount;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPairHeader} PairCount -> {_getPairCount}";
		}
	}
}

