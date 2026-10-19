
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Total playback time in seconds, including the Start Delay setting.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-totalTime.html")]
	public sealed class ParticleSystemGetTotalTime : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Total Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTotalTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getTotalTime);
		}
		
		public override void Execute()
		{
			_getTotalTime.Value = _particleSystem.Value.totalTime;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} total time -> {_getTotalTime}";
		}
	}
}
