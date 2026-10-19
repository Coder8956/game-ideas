
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Removes all the leading occurrences of a specified character from the current string.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.trimstart")]
	public sealed class StringTrimStartChar : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Trim Char.")]
		[SerializeField]
		private CharVar _trimChar;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _trimChar, _result);
		}
		
		public override void Execute()
		{
			//System.String.TrimStart(System.Char);
			_result.Value = _string.Value.TrimStart(_trimChar.Value);
		}
		
		public override string GetSummary()
		{
			return "Trim Start {_string} {_trimChar} -> {_result}";
		}
	}
}
