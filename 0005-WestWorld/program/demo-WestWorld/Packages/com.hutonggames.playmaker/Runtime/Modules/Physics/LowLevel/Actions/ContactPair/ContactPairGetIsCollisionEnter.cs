
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPair)]
	[ActionDescription("Whether or not this pair is equivalent to a pair reported in MonoBehaviour.OnColl" +
		"isionEnter events.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPair.html")]
	public sealed class ContactPairGetIsCollisionEnter : BaseAction
	{
		
		[Tooltip("The ContactPair")]
		[SerializeField]
		private ContactPairRef _contactPair;
		
		[Tooltip("Get ContactPair Is Collision Enter")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsCollisionEnter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPair, _getIsCollisionEnter);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getIsCollisionEnter.Value = _contactPair.Value.isCollisionEnter;
#else
			_getIsCollisionEnter.Value = _contactPair.Value.IsCollisionEnter;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPair} IsCollisionEnter -> {_getIsCollisionEnter}";
		}
	}
}

