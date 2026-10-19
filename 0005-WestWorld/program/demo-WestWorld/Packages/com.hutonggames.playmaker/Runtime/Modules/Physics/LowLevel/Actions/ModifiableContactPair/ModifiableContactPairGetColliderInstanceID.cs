
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
#if UNITY_6000_5_OR_NEWER
	[Obsolete("ModifiableContactPair.colliderInstanceID is deprecated in Unity 6.5+. Use colliderEntityId instead.")]
#endif
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
#if UNITY_6000_4_OR_NEWER
	[ActionDescription("Instance ID of the first Collider in this contact pair. Note: on Unity 6.4+ this uses a legacy instance ID API and may be removed in a future update.")]
#else
	[ActionDescription("Instance ID of the first Collider in this contact pair.")]
#endif
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-colliderInstanceID" +
		".html")]
	public sealed class ModifiableContactPairGetColliderInstanceID : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Collider Instance ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getColliderInstanceID;
		
		public override bool CanExecute()
		{
#if UNITY_6000_5_OR_NEWER
			return false;
#else
			return CheckParameters(_modifiableContactPair, _getColliderInstanceID);
#endif
		}
		
		public override void Execute()
		{
#if !UNITY_6000_5_OR_NEWER
#pragma warning disable CS0618, CS0619
			_getColliderInstanceID.Value = _modifiableContactPair.Value.colliderInstanceID;
#pragma warning restore CS0618, CS0619
#endif
		}
		
		public override string GetSummary()
		{
#if UNITY_6000_5_OR_NEWER
			return null;
#else
			return "Get {_modifiableContactPair} colliderInstanceID -> {_getColliderInstanceID}";
#endif
		}
	}
}
