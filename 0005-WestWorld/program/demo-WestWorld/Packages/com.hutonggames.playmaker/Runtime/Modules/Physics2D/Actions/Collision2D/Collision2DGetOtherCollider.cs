
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("The other Collider2D involved in the collision with the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D-otherCollider.html")]
	public sealed class Collision2DGetOtherCollider : BaseAction
	{
		
		[Tooltip("The Collision2D")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("Get Collision2D Other Collider")]
		[SerializeField]
		[WriteOnly]
		private Collider2DRef _getOtherCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision2D, _getOtherCollider);
		}
		
		public override void Execute()
		{
			_getOtherCollider.Value = _collision2D.Value.otherCollider;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision2D} otherCollider -> {_getOtherCollider}";
		}
	}
}
