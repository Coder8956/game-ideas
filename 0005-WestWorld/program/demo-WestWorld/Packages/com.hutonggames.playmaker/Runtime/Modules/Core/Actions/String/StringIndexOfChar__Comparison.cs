
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Reports the zero-based index of the first occurrence of a specified Unicode chara" +
		"cter or string within this instance. The method returns -1 if the character or s" +
		"tring is not found in this instance. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.indexof")]
	public sealed class StringIndexOfChar__Comparison : BaseAction
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
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _value, _result);
		}
		
		public override void Execute()
		{
			//System.String.IndexOf(System.Char, System.StringComparison);
			_result.Value = _string.Value.IndexOf(_value.Value, _comparisonType);
		}
		
		public override string GetSummary()
		{
			return "Index Of {_string} {_value} {_comparisonType} -> {_result}";
		}
	}
}
