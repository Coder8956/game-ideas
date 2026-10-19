
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Stops playing the Particle System using the supplied stop behaviour.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.Stop.html")]
	public sealed class ParticleSystemStop : BaseAction
	{
		
		[Tooltip("The ParticleSystem.")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Stop all child Particle Systems as well.")]
		[SerializeField]
		private BoolVar _withChildren;
		
		[Tooltip("Stop emitting or stop emitting and clear the system.")]
		[SerializeField]
		private ParticleSystemStopBehaviorVar _stopBehavior;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _withChildren, _stopBehavior);
		}
		
		public override void Execute()
		{
			//UnityEngine.ParticleSystem.Stop(System.Boolean, UnityEngine.ParticleSystemStopBehavior);
			_particleSystem.Value.Stop(_withChildren.Value, _stopBehavior.Value);
		}
		
		public override string GetSummary()
		{
			return "Stop {_particleSystem} {_stopBehavior} {_withChildren:option}";
		}
	}
}
