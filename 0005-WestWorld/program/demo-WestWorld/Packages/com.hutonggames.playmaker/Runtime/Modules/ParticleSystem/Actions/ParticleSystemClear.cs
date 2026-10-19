
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Remove all particles in the Particle System.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.Clear.html")]
	public sealed class ParticleSystemClear : BaseAction
	{
		
		[Tooltip("The ParticleSystem.")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Clear all child Particle Systems as well.")]
		[SerializeField]
		private BoolVar _withChildren;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _withChildren);
		}
		
		public override void Execute()
		{
			//UnityEngine.ParticleSystem.Clear(System.Boolean);
			_particleSystem.Value.Clear(_withChildren.Value);
		}
		
		public override string GetSummary()
		{
			return "Clear {_particleSystem} {_withChildren:option}";
		}
	}
}
