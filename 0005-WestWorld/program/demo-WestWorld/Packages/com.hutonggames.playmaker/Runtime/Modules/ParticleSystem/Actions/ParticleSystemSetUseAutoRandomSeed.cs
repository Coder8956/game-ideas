
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Controls whether the Particle System uses an automatically-generated random numbe" +
		"r to seed the random number generator.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-useAutoRandomSeed.html")]
	public sealed class ParticleSystemSetUseAutoRandomSeed : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Set ParticleSystem Use Auto Random Seed")]
		[SerializeField]
		private BoolVar _setUseAutoRandomSeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _setUseAutoRandomSeed);
		}
		
		public override void Execute()
		{
			_particleSystem.Value.useAutoRandomSeed = _setUseAutoRandomSeed.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_particleSystem} use auto random seed to {_setUseAutoRandomSeed}";
		}
	}
}
