
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsSettings)]
	[ActionDescription("The mass-normalized energy threshold, below which objects start going to sleep.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics-sleepThreshold.html")]
	public sealed class PhysicsSetSleepThreshold : BaseAction
	{
		
		[Tooltip("Set Physics Sleep Threshold")]
		[SerializeField]
		private FloatVar _setSleepThreshold;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setSleepThreshold);
		}
		
		public override void Execute()
		{
			Physics.sleepThreshold = _setSleepThreshold.Value;
		}
		
		public override string GetSummary()
		{
			return "Set Physics Sleep Threshold to {_setSleepThreshold}";
		}
	}
}
