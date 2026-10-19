
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Starts the Particle System.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.Play.html")]
	public sealed class ParticleSystemPlay : BaseAction
	{
		
		[Tooltip("The ParticleSystem.")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Play all child Particle Systems as well.")]
		[SerializeField]
		private BoolVar _withChildren;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _withChildren);
		}
		
		public override void Execute()
		{
			//UnityEngine.ParticleSystem.Play(System.Boolean);
			_particleSystem.Value.Play(_withChildren.Value);
		}
		
		public override string GetSummary()
		{
			return "Play {_particleSystem} {_withChildren:option}";
		}
	}
}
