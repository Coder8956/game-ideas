
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a new string in which all the characters in the current instance, " +
	                   "beginning at a specified position and continuing through the last position, have been deleted.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.remove")]
	public sealed class StringRemove : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Start Index.")]
		[SerializeField]
		private IntegerVar _startIndex;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _startIndex, _result);
		}
		
		public override void Execute()
		{
			//System.String.Remove(System.Int32);
			_result.Value = _string.Value.Remove(_startIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "Remove {_string} {_startIndex} -> {_result}";
		}
	}
}
