
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Removes all the leading occurrences of a set of characters specified in an array from the current string.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.trimstart")]
	public sealed class StringTrimStartChars : BaseAction
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
			//System.String.TrimStart(System.Char[]);
			_result.Value = _string.Value.TrimStart(_trimChars.Values);
		}
		
		public override string GetSummary()
		{
			return "Trim Start {_string} {_trimChars} -> {_result}";
		}
	}
}
