
using JetBrains.Annotations;
using System;
using System.Globalization;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Determines whether the end of this string instance matches a specified string. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith")]
	public sealed class StringEndsWith__IgnoreCase : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Value.")]
		[SerializeField]
		private StringVar _value;
		
		[Tooltip("Ignore Case.")]
		[SerializeField]
		private BoolVar _ignoreCase;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _value, _ignoreCase, _result);
		}
		
		public override void Execute()
		{
			//System.String.EndsWith(System.String, System.Boolean, System.Globalization.CultureInfo);
			_result.Value = _string.Value.EndsWith(_value.Value, _ignoreCase.Value, CultureInfo.CurrentCulture);
		}
		
		public override string GetSummary()
		{
			return "Ends With {_string} {_value} {_ignoreCase} -> {_result}";
		}
	}
}
