
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The mass-normalized energy threshold, below which objects start going to sleep.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-sleepThreshold.html")]
	public sealed class RigidbodyGetSleepThreshold : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Sleep Threshold")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSleepThreshold;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getSleepThreshold);
		}
		
		public override void Execute()
		{
			_getSleepThreshold.Value = _rigidbody.Value.sleepThreshold;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} sleep threshold -> {_getSleepThreshold}";
		}
	}
}
