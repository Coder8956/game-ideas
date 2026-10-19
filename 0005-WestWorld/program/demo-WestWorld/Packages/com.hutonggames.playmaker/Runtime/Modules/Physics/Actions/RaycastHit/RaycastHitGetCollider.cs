
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The Collider that was hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-collider.html")]
	public sealed class RaycastHitGetCollider : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Collider")]
		[SerializeField]
		[WriteOnly]
		private ColliderRef _getCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getCollider);
		}
		
		public override void Execute()
		{
			_getCollider.Value = _raycastHit.Value.collider;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Collider -> {_getCollider}";
		}
	}
}
