
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a new string in which all leading and trailing occurrences of a set of sp" +
		"ecified characters from the current string are removed. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.trim")]
	public sealed class StringTrimChars : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Trim Chars.")]
		[SerializeField]
		private CharListVar _trimChars;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _trimChars, _result);
		}
		
		public override void Execute()
		{
			//System.String.Trim(System.Char[]);
			_result.Value = _string.Value.Trim(_trimChars.Values);
		}
		
		public override string GetSummary()
		{
			return "Trim {_string} {_trimChars} -> {_result}";
		}
	}
}
