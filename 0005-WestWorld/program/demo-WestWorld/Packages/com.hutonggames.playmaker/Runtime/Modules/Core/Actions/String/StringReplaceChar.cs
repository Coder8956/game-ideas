
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a new string in which all occurrences of a specified Unicode character " +
		"are replaced with another specified Unicode character. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.replace")]
	public sealed class StringReplaceChar : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Old Char.")]
		[SerializeField]
		private CharVar _oldChar;
		
		[Tooltip("New Char.")]
		[SerializeField]
		private CharVar _newChar;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _oldChar, _newChar, _result);
		}
		
		public override void Execute()
		{
			//System.String.Replace(System.Char, System.Char);
			_result.Value = _string.Value.Replace(_oldChar.Value, _newChar.Value);
		}
		
		public override string GetSummary()
		{
			return "Replace {_string} {_oldChar} {_newChar} -> {_result}";
		}
	}
}
