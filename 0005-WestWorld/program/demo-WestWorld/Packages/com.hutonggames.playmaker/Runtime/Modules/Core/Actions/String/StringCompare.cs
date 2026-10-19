
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ConvertibleGroup("StringCompare")]
	[ActionDescription("Compares two specified String objects and returns an integer that indicates their" +
		" relative position in the sort order. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.compare")]
	public sealed class StringCompare : BaseAction
	{
		
		[Tooltip("The first string.")]
		[SerializeField]
		private StringVar _stringA;
		
		[Tooltip("The second string.")]
		[SerializeField]
		private StringVar _stringB;
		
		[Tooltip("Comparison Type.")]
		[SerializeField]
		private StringComparison _comparisonType;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_stringA, _stringB, _result);
		}
		
		public override void Execute()
		{
			//System.String.Compare(System.String, System.String, System.StringComparison);
			_result.Value = string.Compare(_stringA.Value, _stringB.Value, _comparisonType);
		}
		
		public override string GetSummary()
		{
			return "String Compare: {_stringA} {_stringB} {_comparisonType} -> {_result}";
		}
	}
}
