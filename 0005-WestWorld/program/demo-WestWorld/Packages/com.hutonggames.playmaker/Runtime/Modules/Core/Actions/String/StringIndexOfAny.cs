
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Reports the index of the first occurrence in this instance of any character in a " +
		"specified array of Unicode characters. The method returns -1 if the characters i" +
		"n the array are not found in this instance. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.indexofany")]
	public sealed class StringIndexOfAny : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Any Of.")]
		[SerializeField]
		private CharListVar _anyOf;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _anyOf, _result);
		}
		
		public override void Execute()
		{
			//System.String.IndexOfAny(System.Char[]);
			_result.Value = _string.Value.IndexOfAny(_anyOf.Values);
		}
		
		public override string GetSummary()
		{
			return "Index Of Any {_string} {_anyOf} -> {_result}";
		}
	}
}
