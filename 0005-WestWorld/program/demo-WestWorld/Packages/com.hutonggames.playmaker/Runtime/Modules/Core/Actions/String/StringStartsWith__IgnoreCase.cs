
using JetBrains.Annotations;
using System;
using System.Globalization;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Determines whether the beginning of this string instance matches the specified string, ignoring the case.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.startswith")]
	public sealed class StringStartsWith__IgnoreCase : BaseAction
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
		
		//[Tooltip("Culture.")]
		//[SerializeField]
		//private CultureInfo _culture;
		
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
			//System.String.StartsWith(System.String, System.Boolean, System.Globalization.CultureInfo);
			_result.Value = _string.Value.StartsWith(_value.Value, _ignoreCase.Value, CultureInfo.CurrentCulture);
		}
		
		public override string GetSummary()
		{
			return "Starts With {_string} {_value} {_ignoreCase} -> {_result}";
		}
	}
}
