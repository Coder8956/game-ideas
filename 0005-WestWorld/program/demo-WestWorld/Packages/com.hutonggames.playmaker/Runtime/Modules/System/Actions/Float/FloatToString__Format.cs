
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Converts the numeric value of this instance to its equivalent string representation.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.tostring")]
	public sealed class FloatToString__Format : BaseAction
	{
		
		[Tooltip("The Float.")]
		[SerializeField]
		private FloatRef _float;
		
		[Tooltip("Format. Common examples:\n" +
		         "\"F2\" -> Fixed-point, 2 decimals (e.g., 123.46)\n" +
		         "\"N1\" -> Number with commas, 1 decimal (e.g., 1,234.5)\n" +
		         "\"E2\" -> Scientific, 2 decimals (e.g., 1.23E+003)\n" +
		         "\"P0\" -> Percentage, no decimals (e.g., 12%)")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _format;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_float, _format, _result);
		}
		
		public override void Execute()
		{
			//System.Single.ToString(System.String);
			_result.Value = _float.Value.ToString(_format.Value);
		}
		
		public override string GetSummary()
		{
			return "{_float} To String ({_format}) -> {_result}";
		}
	}
}
