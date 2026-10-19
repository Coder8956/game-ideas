
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsSettings)]
	[ActionDescription(@"Makes the collision detection system ignore all collisions between any collider in layer1 and any collider in layer2. Note that IgnoreLayerCollision will reset the trigger state of affected colliders, so you might receive OnTriggerExit and OnTriggerEnter messages in response to calling this.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.IgnoreLayerCollision.html")]
	public sealed class PhysicsIgnoreLayerCollision : BaseAction
	{
		
		[Tooltip("Layer 1.")]
		[SerializeField]
		private LayerMaskVar _layer1;
		
		[Tooltip("Layer 2.")]
		[SerializeField]
		private LayerMaskVar _layer2;
		
		[Tooltip("Ignore.")]
		[SerializeField]
		[DefaultValue(true)]
		private BoolVar _ignore;
		
		public override bool CanExecute()
		{
			return CheckParameters(_layer1, _layer2, _ignore);
		}
		
		public override void Execute()
		{
			//UnityEngine.Physics.IgnoreLayerCollision(System.Int32, System.Int32, System.Boolean);
			Physics.IgnoreLayerCollision(_layer1.Value, _layer2.Value, _ignore.Value);
		}
		
		public override string GetSummary()
		{
			return "Physics Ignore Layer Collision: {_layer1} {_layer2} {_ignore} ";
		}
	}
}
