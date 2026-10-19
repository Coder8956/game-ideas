
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a new string of a specified length in which the end of the current string" +
		" is padded with spaces. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.padright")]
	public sealed class StringPadRight : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Total Width.")]
		[SerializeField]
		private IntegerVar _totalWidth;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _totalWidth, _result);
		}
		
		public override void Execute()
		{
			//System.String.PadRight(System.Int32);
			_result.Value = _string.Value.PadRight(_totalWidth.Value);
		}
		
		public override string GetSummary()
		{
			return "Pad Right {_string} {_totalWidth} -> {_result}";
		}
	}
}
