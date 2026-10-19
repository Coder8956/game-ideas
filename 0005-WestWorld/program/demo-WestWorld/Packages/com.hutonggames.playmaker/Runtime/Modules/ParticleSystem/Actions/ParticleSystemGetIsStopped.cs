
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Determines whether the Particle System is in the stopped state.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-isStopped.html")]
	public sealed class ParticleSystemGetIsStopped : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Is Stopped")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsStopped;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getIsStopped);
		}
		
		public override void Execute()
		{
			_getIsStopped.Value = _particleSystem.Value.isStopped;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} is stopped -> {_getIsStopped}";
		}
	}
}
