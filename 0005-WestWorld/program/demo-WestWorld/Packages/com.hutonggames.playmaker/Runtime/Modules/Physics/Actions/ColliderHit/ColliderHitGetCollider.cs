
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ColliderHit)]
	[ActionDescription("The Collider that was hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ColliderHit-collider.html")]
	public sealed class ColliderHitGetCollider : BaseAction
	{
		
		[Tooltip("The ColliderHit")]
		[SerializeField]
		private ColliderHitRef _colliderHit;
		
		[Tooltip("Get ColliderHit Collider")]
		[SerializeField]
		[WriteOnly]
		private ColliderVar _getCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_colliderHit, _getCollider);
		}
		
		public override void Execute()
		{
			_getCollider.Value = _colliderHit.Value.collider;
		}
		
		public override string GetSummary()
		{
			return "Get {_colliderHit} collider -> {_getCollider}";
		}
	}
}
