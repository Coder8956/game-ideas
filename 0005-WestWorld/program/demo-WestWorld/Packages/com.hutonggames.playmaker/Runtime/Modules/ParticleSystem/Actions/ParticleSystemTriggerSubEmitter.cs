
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Triggers the specified sub emitter on all particles of the Particle System.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.TriggerSubEmitter.html")]
	public sealed class ParticleSystemTriggerSubEmitter : BaseAction
	{
		
		[Tooltip("The ParticleSystem.")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Index of the sub emitter to trigger.")]
		[SerializeField]
		private IntegerVar _subEmitterIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _subEmitterIndex);
		}
		
		public override void Execute()
		{
			//UnityEngine.ParticleSystem.TriggerSubEmitter(System.Int32);
			_particleSystem.Value.TriggerSubEmitter(_subEmitterIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "Trigger {_particleSystem} sub emitter {_subEmitterIndex}";
		}
	}
}
