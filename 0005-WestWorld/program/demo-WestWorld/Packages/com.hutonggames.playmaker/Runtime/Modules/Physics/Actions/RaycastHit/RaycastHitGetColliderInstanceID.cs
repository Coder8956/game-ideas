/* Changing in 6.3+
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("Instance ID of the Collider that was hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-colliderInstanceID.html")]
	public sealed class RaycastHitGetColliderInstanceID : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Collider Instance ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getColliderInstanceID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getColliderInstanceID);
		}
		
		public override void Execute()
		{
			_getColliderInstanceID.Value = _raycastHit.Value.colliderInstanceID;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Collider InstanceID -> {_getColliderInstanceID}";
		}
	}
}
*/