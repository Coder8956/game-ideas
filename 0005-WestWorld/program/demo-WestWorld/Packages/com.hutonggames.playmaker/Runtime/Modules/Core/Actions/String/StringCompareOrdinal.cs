
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ConvertibleGroup("StringCompare")]
	[ActionDescription("Compares two String objects by evaluating the numeric values of the corresponding" +
		" Char objects in each string. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.compareordinal")]
	public sealed class StringCompareOrdinal : BaseAction
	{
		
		[Tooltip("The first string.")]
		[SerializeField]
		private StringVar _stringA;
		
		[Tooltip("The second string.")]
		[SerializeField]
		private StringVar _stringB;
		
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
			//System.String.CompareOrdinal(System.String, System.String);
			_result.Value = string.CompareOrdinal(_stringA.Value, _stringB.Value);
		}
		
		public override string GetSummary()
		{
			return "String Compare Ordinal: {_stringA} {_stringB} -> {_result}";
		}
	}
}
