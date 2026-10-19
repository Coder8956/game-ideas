
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Reports the zero-based index position of the last occurrence of a specified Unico" +
		"de character or string within this instance. The method returns -1 if the charac" +
		"ter or string is not found in this instance. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.lastindexof")]
	public sealed class StringLastIndexOf__Comparison : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Value.")]
		[SerializeField]
		private StringVar _value;
		
		[Tooltip("Start Index.")]
		[SerializeField]
		private IntegerVar _startIndex;
		
		[Tooltip("Comparison Type.")]
		[SerializeField]
		private StringComparison _comparisonType;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _value, _startIndex, _result);
		}
		
		public override void Execute()
		{
			//System.String.LastIndexOf(System.String, System.Int32, System.StringComparison);
			_result.Value = _string.Value.LastIndexOf(_value.Value, _startIndex.Value, _comparisonType);
		}
		
		public override string GetSummary()
		{
			return "Last Index Of {_string} {_value} {_startIndex} {_comparisonType} -> {_result}";
		}
	}
}
