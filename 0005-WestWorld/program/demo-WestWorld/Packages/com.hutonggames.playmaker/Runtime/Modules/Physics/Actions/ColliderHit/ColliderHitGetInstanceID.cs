
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
#if UNITY_6000_5_OR_NEWER
	[Obsolete("ColliderHit.instanceID is deprecated in Unity 6.5+. A replacement action using EntityId is required.")]
#endif
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ColliderHit)]
#if UNITY_6000_4_OR_NEWER
	[ActionDescription("The instance ID of the Collider that was hit. Note: on Unity 6.4+ this uses the legacy instanceID API and may be removed in a future update.")]
#else
	[ActionDescription("The instance ID of the Collider that was hit.")]
#endif
	[HelpURL("https://docs.unity3d.com/ScriptReference/ColliderHit-instanceID.html")]
	public sealed class ColliderHitGetInstanceID : BaseAction
	{
		
		[Tooltip("The ColliderHit")]
		[SerializeField]
		private ColliderHitRef _colliderHit;
		
		[Tooltip("Get ColliderHit Instance ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getInstanceID;
		
		public override bool CanExecute()
		{
#if UNITY_6000_5_OR_NEWER
			return false;
#else
			return CheckParameters(_colliderHit, _getInstanceID);
#endif
		}
		
		public override void Execute()
		{
#if !UNITY_6000_5_OR_NEWER
#pragma warning disable CS0618, CS0619
			_getInstanceID.Value = _colliderHit.Value.instanceID;
#pragma warning restore CS0618, CS0619
#endif
		}
		
		public override string GetSummary()
		{
#if UNITY_6000_5_OR_NEWER
			return null;
#else
			return "Get {_colliderHit} instanceID -> {_getInstanceID}";
#endif
		}
	}
}
