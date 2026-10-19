
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Playback position in seconds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-time.html")]
	public sealed class ParticleSystemSetTime : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Set ParticleSystem Time")]
		[SerializeField]
		private FloatVar _setTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _setTime);
		}
		
		public override void Execute()
		{
			_particleSystem.Value.time = _setTime.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_particleSystem} time to {_setTime}";
		}
	}
}
