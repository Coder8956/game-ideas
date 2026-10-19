
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsSettings)]
	[ActionDescription("Makes the collision detection system ignore all collisions between collider1 and " +
		"collider2.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.IgnoreCollision.html")]
	public sealed class PhysicsIgnoreCollision : BaseAction
	{
		
		[Tooltip("Any collider.")]
		[SerializeField]
		private ColliderVar _collider1;
		
		[Tooltip("Another collider you want to have collider1 to start or stop ignoring collisions " +
			"with.")]
		[SerializeField]
		private ColliderVar _collider2;
		
		[Tooltip("Whether or not the collisions between the two colliders should be ignored or not." +
			"")]
		[SerializeField]
		[DefaultValue(true)]
		private BoolVar _ignore;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider1, _collider2, _ignore);
		}
		
		public override void Execute()
		{
			//UnityEngine.Physics.IgnoreCollision(UnityEngine.Collider, UnityEngine.Collider, System.Boolean);
			Physics.IgnoreCollision(_collider1.Value, _collider2.Value, _ignore.Value);
		}
		
		public override string GetSummary()
		{
			return "Physics Ignore Collision: {_collider1} {_collider2} {_ignore} ";
		}
	}
}
