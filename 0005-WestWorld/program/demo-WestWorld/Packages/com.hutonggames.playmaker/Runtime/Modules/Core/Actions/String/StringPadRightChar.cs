
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a new string of a specified length in which the end of the current string" +
		" is padded with a specified Unicode character. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.padright")]
	public sealed class StringPadRightChar : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Total Width.")]
		[SerializeField]
		private IntegerVar _totalWidth;
		
		[Tooltip("Padding Char.")]
		[SerializeField]
		private CharVar _paddingChar;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _totalWidth, _paddingChar, _result);
		}
		
		public override void Execute()
		{
			//System.String.PadRight(System.Int32, System.Char);
			_result.Value = _string.Value.PadRight(_totalWidth.Value, _paddingChar.Value);
		}
		
		public override string GetSummary()
		{
			return "Pad Right {_string} {_totalWidth} {_paddingChar} -> {_result}";
		}
	}
}
