
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a new string in which all occurrences of a specified " +
		"String in the current string are replaced with another String. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.replace")]
	public sealed class StringReplace : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Old Value.")]
		[SerializeField]
		private StringVar _oldValue;
		
		[Tooltip("New Value.")]
		[SerializeField]
		private StringVar _newValue;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _oldValue, _newValue, _result);
		}
		
		public override void Execute()
		{
			//System.String.Replace(System.String, System.String);
			_result.Value = _string.Value.Replace(_oldValue.Value, _newValue.Value);
		}
		
		public override string GetSummary()
		{
			return "Replace {_string} {_oldValue} {_newValue} -> {_result}";
		}
	}
}
