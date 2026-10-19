
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The maximum time a frame can spend on particle updates. If the frame takes longer" +
		" than this, then updates are split into multiple smaller updates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-maximumParticleDeltaTime.html")]
	public sealed class TimeSetMaximumParticleDeltaTime : BaseAction
	{
		
		[Tooltip("Set Time Maximum Particle Delta Time")]
		[SerializeField]
		private FloatVar _setMaximumParticleDeltaTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setMaximumParticleDeltaTime);
		}
		
		public override void Execute()
		{
			Time.maximumParticleDeltaTime = _setMaximumParticleDeltaTime.Value;
		}
		
		public override string GetSummary()
		{
			return "Set time maximum particle delta time to {_setMaximumParticleDeltaTime}";
		}
	}
}
