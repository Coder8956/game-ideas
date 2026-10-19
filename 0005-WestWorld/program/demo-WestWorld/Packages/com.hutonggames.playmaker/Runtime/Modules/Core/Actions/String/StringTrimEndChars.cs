
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Removes all the trailing white-space characters from the current string. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.trimend")]
	public sealed class StringTrimEndChars : BaseAction
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
			//System.String.TrimEnd(System.Char[]);
			_result.Value = _string.Value.TrimEnd(_trimChars.Values);
		}
		
		public override string GetSummary()
		{
			return "Trim End {_string} {_trimChars} -> {_result}";
		}
	}
}
