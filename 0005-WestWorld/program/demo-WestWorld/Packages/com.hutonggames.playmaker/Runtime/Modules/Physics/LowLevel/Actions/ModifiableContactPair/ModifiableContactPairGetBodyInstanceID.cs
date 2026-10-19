
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
#if UNITY_6000_5_OR_NEWER
	[Obsolete("ModifiableContactPair.bodyInstanceID is deprecated in Unity 6.5+. Use bodyEntityId instead.")]
#endif
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
#if UNITY_6000_4_OR_NEWER
	[ActionDescription("Instance ID of the first body in this contact pair. Note: on Unity 6.4+ this uses a legacy instance ID API and may be removed in a future update.")]
#else
	[ActionDescription("Instance ID of the first body in this contact pair.")]
#endif
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-bodyInstanceID.htm" +
		"l")]
	public sealed class ModifiableContactPairGetBodyInstanceID : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Body Instance ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getBodyInstanceID;
		
		public override bool CanExecute()
		{
#if UNITY_6000_5_OR_NEWER
			return false;
#else
			return CheckParameters(_modifiableContactPair, _getBodyInstanceID);
#endif
		}
		
		public override void Execute()
		{
#if !UNITY_6000_5_OR_NEWER
#pragma warning disable CS0618, CS0619
			_getBodyInstanceID.Value = _modifiableContactPair.Value.bodyInstanceID;
#pragma warning restore CS0618, CS0619
#endif
		}
		
		public override string GetSummary()
		{
#if UNITY_6000_5_OR_NEWER
			return null;
#else
			return "Get {_modifiableContactPair} bodyInstanceID -> {_getBodyInstanceID}";
#endif
		}
	}
}
