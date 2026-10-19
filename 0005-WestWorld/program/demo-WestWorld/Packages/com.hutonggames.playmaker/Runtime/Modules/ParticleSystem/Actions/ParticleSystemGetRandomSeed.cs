
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Override the random seed used for the Particle System emission.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-randomSeed.html")]
	public sealed class ParticleSystemGetRandomSeed : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Random Seed")]
		[SerializeField]
		[WriteOnly]
		private UIntRef _getRandomSeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getRandomSeed);
		}
		
		public override void Execute()
		{
			_getRandomSeed.Value = _particleSystem.Value.randomSeed;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} random seed -> {_getRandomSeed}";
		}
	}
}
