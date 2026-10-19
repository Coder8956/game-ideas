
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Creates a new instance of String with the same value as a specified String. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.copy")]
	public sealed class StringCopy : BaseAction
	{
		
		[Tooltip("The String to copy.")]
		[SerializeField]
		private StringVar _string;
		
		[Tooltip("Store the copy in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _result);
		}
		
		public override void Execute()
		{
			//System.String.Copy(System.String);
			_result.Value = string.Copy(_string.Value);
		}
		
		public override string GetSummary()
		{
			return "Copy {_string} -> {_result}";
		}
	}
}
