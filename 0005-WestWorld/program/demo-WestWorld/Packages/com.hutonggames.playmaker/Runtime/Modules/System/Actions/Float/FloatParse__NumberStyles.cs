
using JetBrains.Annotations;
using System;
using System.Globalization;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Converts the string representation of a number to its single-precision floating-p" +
		"oint number equivalent. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.parse")]
	public sealed class FloatParse__NumberStyles : BaseAction
	{
		
		[Tooltip("String to parse.")]
		[SerializeField]
		private StringVar _string;
		
		[Tooltip("Style.")]
		[SerializeField]
		private NumberStyles _style;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _style, _result);
		}
		
		public override void Execute()
		{
			//System.Single.Parse(System.String, System.Globalization.NumberStyles);
			_result.Value = float.Parse(_string.Value, _style);
		}
		
		public override string GetSummary()
		{
			return "Float Parse: {_string} style:{_style} -> {_result}";
		}
	}
}
