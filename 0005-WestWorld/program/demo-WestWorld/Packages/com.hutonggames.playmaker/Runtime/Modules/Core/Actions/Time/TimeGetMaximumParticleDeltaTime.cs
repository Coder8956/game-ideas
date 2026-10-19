
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
	public sealed class TimeGetMaximumParticleDeltaTime : BaseAction
	{
		
		[Tooltip("Get Time Maximum Particle Delta Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaximumParticleDeltaTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getMaximumParticleDeltaTime);
		}
		
		public override void Execute()
		{
			_getMaximumParticleDeltaTime.Value = Time.maximumParticleDeltaTime;
		}
		
		public override string GetSummary()
		{
			return "Get maximum particle delta time -> {_getMaximumParticleDeltaTime}";
		}
	}
}
