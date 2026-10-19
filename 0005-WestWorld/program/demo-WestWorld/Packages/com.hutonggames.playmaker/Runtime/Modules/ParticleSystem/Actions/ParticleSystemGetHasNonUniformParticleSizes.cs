
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Determines whether the Particle System uses a single value for the width and heig" +
		"ht (and depth, when using meshes), or if the system specifies different values f" +
		"or each axis.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-hasNonUniformParticleSize" +
		"s.html")]
	public sealed class ParticleSystemGetHasNonUniformParticleSizes : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Has Non Uniform Particle Sizes")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getHasNonUniformParticleSizes;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getHasNonUniformParticleSizes);
		}
		
		public override void Execute()
		{
			_getHasNonUniformParticleSizes.Value = _particleSystem.Value.hasNonUniformParticleSizes;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} has non-uniform particle sizes -> {_getHasNonUniformParticleSizes}";
		}
	}
}
