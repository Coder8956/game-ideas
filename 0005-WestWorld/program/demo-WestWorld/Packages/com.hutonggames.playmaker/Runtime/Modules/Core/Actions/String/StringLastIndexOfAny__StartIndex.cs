
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Reports the zero-based index position of the last occurrence in this instance of " +
		"one or more characters specified in a Unicode array. The method returns -1 if th" +
		"e characters in the array are not found in this instance. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.lastindexofany")]
	public sealed class StringLastIndexOfAny__StartIndex : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Any Of.")]
		[SerializeField]
		private CharListVar _anyOf;
		
		[Tooltip("Start Index.")]
		[SerializeField]
		private IntegerVar _startIndex;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _anyOf, _startIndex, _result);
		}
		
		public override void Execute()
		{
			//System.String.LastIndexOfAny(System.Char[], System.Int32);
			_result.Value = _string.Value.LastIndexOfAny(_anyOf.Values, _startIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "Last Index Of Any {_string} {_anyOf} {_startIndex} -> {_result}";
		}
	}
}
