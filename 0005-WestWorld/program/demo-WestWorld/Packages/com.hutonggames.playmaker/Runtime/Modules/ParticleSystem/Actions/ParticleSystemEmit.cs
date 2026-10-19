
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Emit count particles immediately.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.Emit.html")]
	public sealed class ParticleSystemEmit : BaseAction
	{
		
		[Tooltip("The ParticleSystem.")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Number of particles to emit.")]
		[SerializeField]
		private IntegerVar _count;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _count);
		}
		
		public override void Execute()
		{
			//UnityEngine.ParticleSystem.Emit(System.Int32);
			_particleSystem.Value.Emit(_count.Value);
		}
		
		public override string GetSummary()
		{
			return "Emit {_count} from {_particleSystem}";
		}
	}
}
