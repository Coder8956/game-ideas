
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Determines whether two String objects have the same value. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.equals")]
	public sealed class StringEquals__Comparison : BaseAction
	{
		[Tooltip("The string to check.")] [SerializeField]
		private StringRef _string;

		[Tooltip("The other string value.")] [SerializeField] 
		private StringVar _value;
		
		[Tooltip("Comparison Type.")]
		[SerializeField]
		private StringComparison _comparisonType;

		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute() => CheckParameters(_string, _value, _result);

		public override void Execute() => 
			_result.Value = _string.Value.Equals(_value.Value, StringComparison.Ordinal);

		public override string GetSummary() => "{_string} equals {_value} ({_comparisonType}) -> {_result}";

	}
}
