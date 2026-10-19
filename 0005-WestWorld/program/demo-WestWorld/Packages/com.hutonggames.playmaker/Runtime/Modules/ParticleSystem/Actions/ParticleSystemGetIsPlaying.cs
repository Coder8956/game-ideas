
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Determines whether the Particle System is playing.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-isPlaying.html")]
	public sealed class ParticleSystemGetIsPlaying : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Is Playing")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsPlaying;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getIsPlaying);
		}
		
		public override void Execute()
		{
			_getIsPlaying.Value = _particleSystem.Value.isPlaying;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} is playing -> {_getIsPlaying}";
		}
	}
}
