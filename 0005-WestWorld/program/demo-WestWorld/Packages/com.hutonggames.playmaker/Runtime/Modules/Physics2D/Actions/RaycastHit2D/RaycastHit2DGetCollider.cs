
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit2D)]
	[ActionDescription("The collider hit by the ray.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit2D-collider.html")]
	public sealed class RaycastHit2DGetCollider : BaseAction
	{
		
		[Tooltip("The RaycastHit2D")]
		[SerializeField]
		private RaycastHit2DRef _raycastHit2D;
		
		[Tooltip("Get RaycastHit2D Collider")]
		[SerializeField]
		[WriteOnly]
		private Collider2DRef _getCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit2D, _getCollider);
		}
		
		public override void Execute()
		{
			_getCollider.Value = _raycastHit2D.Value.collider;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit2D} collider -> {_getCollider}";
		}
	}
}
