
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("The incoming Collider2D involved in the collision with the otherCollider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D-collider.html")]
	public sealed class Collision2DGetCollider : BaseAction
	{
		
		[Tooltip("The Collision2D")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("Get Collision2D Collider")]
		[SerializeField]
		[WriteOnly]
		private Collider2DRef _getCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision2D, _getCollider);
		}
		
		public override void Execute()
		{
			_getCollider.Value = _collision2D.Value.collider;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision2D} collider -> {_getCollider}";
		}
	}
}
