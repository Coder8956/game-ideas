
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Override the random seed used for the Particle System emission.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-randomSeed.html")]
	public sealed class ParticleSystemSetRandomSeed : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Set ParticleSystem Random Seed")]
		[SerializeField]
		private UIntVar _setRandomSeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _setRandomSeed);
		}
		
		public override void Execute()
		{
			_particleSystem.Value.randomSeed = _setRandomSeed.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_particleSystem} random seed to {_setRandomSeed}";
		}
	}
}
