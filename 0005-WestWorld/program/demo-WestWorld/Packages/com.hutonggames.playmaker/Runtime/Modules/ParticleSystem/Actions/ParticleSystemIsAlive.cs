
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Does the Particle System contain any live particles, or will it produce more?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.IsAlive.html")]
	public sealed class ParticleSystemIsAlive : BaseAction
	{
		
		[Tooltip("The ParticleSystem.")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Check all child Particle Systems as well.")]
		[SerializeField]
		private BoolVar _withChildren;
		
		[Tooltip("True if the Particle System contains live particles or is still creating new part" +
			"icles. False if the Particle System has stopped emitting particles and all parti" +
			"cles are dead.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _withChildren, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.ParticleSystem.IsAlive(System.Boolean);
			_result.Value = _particleSystem.Value.IsAlive(_withChildren.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_particleSystem} is alive {_withChildren:option} -> {_result}";
		}
	}
}
