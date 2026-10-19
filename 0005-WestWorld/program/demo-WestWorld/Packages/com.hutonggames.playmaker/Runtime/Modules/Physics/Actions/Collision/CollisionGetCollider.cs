
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision)]
	[ActionDescription("The Collider we hit (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision-collider.html")]
	public sealed class CollisionGetCollider : BaseAction
	{
		
		[Tooltip("The Collision")]
		[SerializeField]
		private CollisionRef _collision;
		
		[Tooltip("Get Collision Collider")]
		[SerializeField]
		[WriteOnly]
		private ColliderRef _getCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision, _getCollider);
		}
		
		public override void Execute()
		{
			_getCollider.Value = _collision.Value.collider;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision} collider -> {_getCollider}";
		}
	}
}
