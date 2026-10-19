
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The scale at which time passes.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-timeScale.html")]
	public sealed class TimeGetTimeScale : BaseAction
	{
		
		[Tooltip("Get Time Time Scale")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTimeScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getTimeScale);
		}
		
		public override void Execute()
		{
			_getTimeScale.Value = Time.timeScale;
		}
		
		public override string GetSummary()
		{
			return "Get time scale -> {_getTimeScale}";
		}
	}
}
