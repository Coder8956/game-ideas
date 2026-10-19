
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a value indicating whether a specified string occurs within this string, " +
		"using the specified comparison rules. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.contains")]
	public sealed class StringContainsChar__Comparison : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Value.")]
		[SerializeField]
		private CharVar _value;
		
		[Tooltip("Comparison Type.")]
		[SerializeField]
		private StringComparison _comparisonType;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _value, _result);
		}
		
		public override void Execute()
		{
			//System.String.Contains(System.Char, System.StringComparison);
			_result.Value = _string.Value.Contains(_value.Value, _comparisonType);
		}
		
		public override string GetSummary()
		{
			return "Contains {_string} {_value} {_comparisonType} -> {_result}";
		}
	}
}
