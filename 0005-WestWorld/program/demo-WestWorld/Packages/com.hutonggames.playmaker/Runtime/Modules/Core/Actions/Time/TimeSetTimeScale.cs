
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
	public sealed class TimeSetTimeScale : BaseAction
	{
		
		[Tooltip("Set Time Time Scale")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _setTimeScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setTimeScale);
		}
		
		public override void Execute()
		{
			Time.timeScale = _setTimeScale.Value;
		}
		
		public override string GetSummary()
		{
			return "Set time scale to {_setTimeScale}";
		}
	}
}
