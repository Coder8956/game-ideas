
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision)]
	[ActionDescription("The relative linear velocity of the two colliding objects (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision-relativeVelocity.html")]
	public sealed class CollisionGetRelativeVelocity : BaseAction
	{
		
		[Tooltip("The Collision")]
		[SerializeField]
		private CollisionRef _collision;
		
		[Tooltip("Get Collision Relative Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getRelativeVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision, _getRelativeVelocity);
		}
		
		public override void Execute()
		{
			_getRelativeVelocity.Value = _collision.Value.relativeVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision} relativeVelocity -> {_getRelativeVelocity}";
		}
	}
}
