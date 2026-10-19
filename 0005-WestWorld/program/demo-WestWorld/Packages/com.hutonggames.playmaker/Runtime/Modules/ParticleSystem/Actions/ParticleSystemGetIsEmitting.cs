
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription(@"Determines whether the Particle System is emitting particles. A Particle System may stop emitting when its emission module has finished, it has been paused or if the system has been stopped using Stop with the StopEmitting flag. Resume emitting by calling Play.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-isEmitting.html")]
	public sealed class ParticleSystemGetIsEmitting : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Is Emitting")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsEmitting;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getIsEmitting);
		}
		
		public override void Execute()
		{
			_getIsEmitting.Value = _particleSystem.Value.isEmitting;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} is emitting -> {_getIsEmitting}";
		}
	}
}
