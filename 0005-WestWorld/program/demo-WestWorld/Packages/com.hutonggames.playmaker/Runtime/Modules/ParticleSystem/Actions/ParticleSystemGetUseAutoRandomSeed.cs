
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Controls whether the Particle System uses an automatically-generated random numbe" +
		"r to seed the random number generator.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-useAutoRandomSeed.html")]
	public sealed class ParticleSystemGetUseAutoRandomSeed : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Use Auto Random Seed")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseAutoRandomSeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getUseAutoRandomSeed);
		}
		
		public override void Execute()
		{
			_getUseAutoRandomSeed.Value = _particleSystem.Value.useAutoRandomSeed;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} use auto random seed -> {_getUseAutoRandomSeed}";
		}
	}
}
