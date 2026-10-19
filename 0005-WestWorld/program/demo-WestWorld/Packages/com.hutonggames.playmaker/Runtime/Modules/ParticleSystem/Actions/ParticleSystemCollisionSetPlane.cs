
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Sets a collision plane used by the Particle System Collision module.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.CollisionModule.SetPlane.html")]
	public sealed class ParticleSystemCollisionSetPlane : BaseAction
	{
		
		[Tooltip("The ParticleSystem.")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("The collision plane index.")]
		[SerializeField]
		private IntegerVar _planeIndex;
		
		[Tooltip("The Transform to use as the collision plane.")]
		[SerializeField]
		private TransformVar _plane;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _planeIndex, _plane);
		}
		
		public override void Execute()
		{
			var collision = _particleSystem.Value.collision;
			collision.SetPlane(_planeIndex.Value, _plane.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_particleSystem} collision plane {_planeIndex} to {_plane}";
		}
	}
}
