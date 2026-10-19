
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
	public sealed class PhysicsGetSleepThreshold : BaseAction
	{
		
		[Tooltip("Get Physics Sleep Threshold")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSleepThreshold;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getSleepThreshold);
		}
		
		public override void Execute()
		{
			_getSleepThreshold.Value = Physics.sleepThreshold;
		}
		
		public override string GetSummary()
		{
			return "Get Physics sleepThreshold -> {_getSleepThreshold} ";
		}
	}
}
