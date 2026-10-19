
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPair)]
	[ActionDescription("The number of ContactPairPoints that this pair contains.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPair.html")]
	public sealed class ContactPairGetContactCount : BaseAction
	{
		
		[Tooltip("The ContactPair")]
		[SerializeField]
		private ContactPairRef _contactPair;
		
		[Tooltip("Get ContactPair Contact Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getContactCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPair, _getContactCount);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getContactCount.Value = _contactPair.Value.contactCount;
#else
			_getContactCount.Value = _contactPair.Value.ContactCount;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPair} ContactCount -> {_getContactCount}";
		}
	}
}

