
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The method used by the physics engine to check if two objects have collided.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-collisionDetectionMode.html")]
	public sealed class Rigidbody2DGetCollisionDetectionMode : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Collision Detection Mode")]
		[SerializeField]
		[WriteOnly]
		private CollisionDetectionMode2DRef _getCollisionDetectionMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getCollisionDetectionMode);
		}
		
		public override void Execute()
		{
			_getCollisionDetectionMode.Value = _rigidbody2D.Value.collisionDetectionMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} collision detection mode -> {_getCollisionDetectionMode}";
		}
	}
}
