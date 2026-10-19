
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
	public sealed class RigidbodySetSleepThreshold : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Sleep Threshold")]
		[SerializeField]
		private FloatVar _setSleepThreshold;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setSleepThreshold);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.sleepThreshold = _setSleepThreshold.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} sleep threshold to {_setSleepThreshold}";
		}
	}
}
