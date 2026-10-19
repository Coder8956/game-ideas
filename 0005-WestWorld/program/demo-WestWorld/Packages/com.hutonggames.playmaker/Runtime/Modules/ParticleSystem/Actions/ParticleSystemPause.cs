
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Pauses the system so no new particles are emitted and the existing particles are " +
		"not updated.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.Pause.html")]
	public sealed class ParticleSystemPause : BaseAction
	{
		
		[Tooltip("The ParticleSystem.")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Pause all child Particle Systems as well.")]
		[SerializeField]
		private BoolVar _withChildren;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _withChildren);
		}
		
		public override void Execute()
		{
			//UnityEngine.ParticleSystem.Pause(System.Boolean);
			_particleSystem.Value.Pause(_withChildren.Value);
		}
		
		public override string GetSummary()
		{
			return "Pause {_particleSystem} {_withChildren:option}";
		}
	}
}
