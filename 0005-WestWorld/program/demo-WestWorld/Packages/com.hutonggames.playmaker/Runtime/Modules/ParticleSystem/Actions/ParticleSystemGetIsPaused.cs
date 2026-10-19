
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Determines whether the Particle System is paused.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-isPaused.html")]
	public sealed class ParticleSystemGetIsPaused : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Is Paused")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsPaused;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getIsPaused);
		}
		
		public override void Execute()
		{
			_getIsPaused.Value = _particleSystem.Value.isPaused;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} is paused -> {_getIsPaused}";
		}
	}
}
