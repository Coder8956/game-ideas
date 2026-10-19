
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("Returns true if called inside a fixed time step callback (like MonoBehaviour\'s Mo" +
		"noBehaviour.FixedUpdate), otherwise returns false (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-inFixedTimeStep.html")]
	public sealed class TimeGetInFixedTimeStep : BaseAction
	{
		
		[Tooltip("Get Time In Fixed Time Step")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getInFixedTimeStep;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getInFixedTimeStep);
		}
		
		public override void Execute()
		{
			_getInFixedTimeStep.Value = Time.inFixedTimeStep;
		}
		
		public override string GetSummary()
		{
			return "Get in fixed time step -> {_getInFixedTimeStep}";
		}
	}
}
