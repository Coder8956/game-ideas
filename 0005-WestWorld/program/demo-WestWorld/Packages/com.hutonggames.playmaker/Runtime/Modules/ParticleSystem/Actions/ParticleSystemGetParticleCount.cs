
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("The current number of particles (Read Only). The number doesn\'t include particles" +
		" of child Particle Systems")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-particleCount.html")]
	public sealed class ParticleSystemGetParticleCount : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Particle Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getParticleCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getParticleCount);
		}
		
		public override void Execute()
		{
			_getParticleCount.Value = _particleSystem.Value.particleCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} particle count -> {_getParticleCount}";
		}
	}
}
