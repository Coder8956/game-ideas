
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPair)]
	[ActionDescription("Whether or not this pair is equivalent to a pair reported in MonoBehaviour.OnColl" +
		"isionExit events.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPair.html")]
	public sealed class ContactPairGetIsCollisionExit : BaseAction
	{
		
		[Tooltip("The ContactPair")]
		[SerializeField]
		private ContactPairRef _contactPair;
		
		[Tooltip("Get ContactPair Is Collision Exit")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsCollisionExit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPair, _getIsCollisionExit);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getIsCollisionExit.Value = _contactPair.Value.isCollisionExit;
#else
			_getIsCollisionExit.Value = _contactPair.Value.IsCollisionExit;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPair} IsCollisionExit -> {_getIsCollisionExit}";
		}
	}
}

