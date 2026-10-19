
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Fast-forwards the Particle System by simulating particles over the given period of time, then pauses it.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.Simulate.html")]
	public sealed class ParticleSystemSimulate : BaseAction
	{
		
		[Tooltip("The ParticleSystem.")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("T.")]
		[SerializeField]
		private FloatVar _t;
		
		[Tooltip("With Children.")]
		[SerializeField]
		private BoolVar _withChildren;
		
		[Tooltip("Restart.")]
		[SerializeField]
		private BoolVar _restart;
		
		[Tooltip("Fixed Time Step.")]
		[SerializeField]
		private BoolVar _fixedTimeStep;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _t, _withChildren, _restart, _fixedTimeStep);
		}
		
		public override void Execute()
		{
			//UnityEngine.ParticleSystem.Simulate(System.Single, System.Boolean, System.Boolean, System.Boolean);
			_particleSystem.Value.Simulate(_t.Value, _withChildren.Value, _restart.Value, _fixedTimeStep.Value);
		}
		
		public override string GetSummary()
		{
			return "Simulate {_particleSystem} {_t} {_withChildren:option} {_restart} {_fixedTimeStep}";
		}
	}
}
