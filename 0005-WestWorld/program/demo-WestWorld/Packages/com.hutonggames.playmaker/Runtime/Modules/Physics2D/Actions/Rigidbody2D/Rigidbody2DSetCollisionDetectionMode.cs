
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The method used by the physics engine to check if two objects have collided.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-collisionDetectionMode.html")]
	public sealed class Rigidbody2DSetCollisionDetectionMode : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Collision Detection Mode")]
		[SerializeField]
		private CollisionDetectionMode2DVar _setCollisionDetectionMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setCollisionDetectionMode);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.collisionDetectionMode = _setCollisionDetectionMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} collision detection mode to {_setCollisionDetectionMode}";
		}
	}
}
