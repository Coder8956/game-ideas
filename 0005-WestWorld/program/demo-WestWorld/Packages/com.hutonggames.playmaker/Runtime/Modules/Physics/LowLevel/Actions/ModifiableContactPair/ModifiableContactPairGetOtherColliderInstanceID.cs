
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
#if UNITY_6000_5_OR_NEWER
	[Obsolete("ModifiableContactPair.otherColliderInstanceID is deprecated in Unity 6.5+. Use otherColliderEntityId instead.")]
#endif
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
#if UNITY_6000_4_OR_NEWER
	[ActionDescription("Instance ID of the second collider in this contact pair. Note: on Unity 6.4+ this uses a legacy instance ID API and may be removed in a future update.")]
#else
	[ActionDescription("Instance ID of the second collider in this contact pair.")]
#endif
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-otherColliderInsta" +
		"nceID.html")]
	public sealed class ModifiableContactPairGetOtherColliderInstanceID : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Other Collider Instance ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getOtherColliderInstanceID;
		
		public override bool CanExecute()
		{
#if UNITY_6000_5_OR_NEWER
			return false;
#else
			return CheckParameters(_modifiableContactPair, _getOtherColliderInstanceID);
#endif
		}
		
		public override void Execute()
		{
#if !UNITY_6000_5_OR_NEWER
#pragma warning disable CS0618, CS0619
			_getOtherColliderInstanceID.Value = _modifiableContactPair.Value.otherColliderInstanceID;
#pragma warning restore CS0618, CS0619
#endif
		}
		
		public override string GetSummary()
		{
#if UNITY_6000_5_OR_NEWER
			return null;
#else
			return "Get {_modifiableContactPair} otherColliderInstanceID -> {_getOtherColliderInstanceID}";
#endif
		}
	}
}
