
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
	public sealed class StringTrimChar : BaseAction
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
			//System.String.Trim(System.Char);
			_result.Value = _string.Value.Trim(_trimChar.Value);
		}
		
		public override string GetSummary()
		{
			return "Trim {_string} {_trimChar} -> {_result}";
		}
	}
}
