
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeSystem)]
	[ActionDescription("Gets system date and time info and stores it in a string variable. " +
	                   "An optional format string gives you a lot of control over the formatting " +
	                   "(see online docs for format syntax).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-captureDeltaTime.html")]
	public sealed class GetSystemDateTime : BaseAction
	{
		[OptionalField]
		[Tooltip("Optional format string. E.g., MM/dd/yyyy HH:mm")]
		[SerializeField]
		private StringVar _format;
		
		[Tooltip("Store System DateTime as a string.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _output;
		
		public override bool CanExecute()
		{
			return CheckParameters(_output);
		}
		
		public override void Execute()
		{
			_output.Value = DateTime.Now.ToString(_format.Value);
		}
		
		public override string GetSummary()
		{
			return "Get system date time -> {_output}"
			       + (!string.IsNullOrEmpty(_format?.Value) ? "({_format})" : string.Empty);
		}
	}
}
