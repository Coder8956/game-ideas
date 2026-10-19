
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Determines whether the beginning of this string instance matches the specified st" +
		"ring when compared using the specified culture. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.startswith")]
	public sealed class StringStartsWith__Comparison : BaseAction
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
			//System.String.StartsWith(System.String, System.StringComparison);
			_result.Value = _string.Value.StartsWith(_value.Value, _comparisonType);
		}
		
		public override string GetSummary()
		{
			return "Starts With {_string} {_value} {_comparisonType} -> {_result}";
		}
	}
}
