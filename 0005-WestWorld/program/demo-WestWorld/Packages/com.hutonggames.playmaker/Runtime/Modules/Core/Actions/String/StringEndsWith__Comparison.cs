
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Determines whether the end of this string instance matches a specified string. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith")]
	public sealed class StringEndsWith__Comparison : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Value.")]
		[SerializeField]
		private StringVar _value;
		
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
			//System.String.EndsWith(System.String, System.StringComparison);
			_result.Value = _string.Value.EndsWith(_value.Value, _comparisonType);
		}
		
		public override string GetSummary()
		{
			return "Ends With {_string} {_value} {_comparisonType} -> {_result}";
		}
	}
}
