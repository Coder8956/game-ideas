
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Playback position in seconds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-time.html")]
	public sealed class ParticleSystemGetTime : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getTime);
		}
		
		public override void Execute()
		{
			_getTime.Value = _particleSystem.Value.time;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} time -> {_getTime}";
		}
	}
}
