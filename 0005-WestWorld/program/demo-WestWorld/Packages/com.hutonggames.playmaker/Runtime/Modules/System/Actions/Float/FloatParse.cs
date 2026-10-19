
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Converts the string representation of a number to its single-precision floating-p" +
		"oint number equivalent. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.parse")]
	public sealed class FloatParse : BaseAction
	{
		
		[Tooltip("String to parse.")]
		[SerializeField]
		private StringVar _string;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _result);
		}
		
		public override void Execute()
		{
			//System.Single.Parse(System.String);
			_result.Value = float.Parse(_string.Value);
		}
		
		public override string GetSummary()
		{
			return "Float Parse: {_string} -> {_result}";
		}
	}
}
