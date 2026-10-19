
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Retrieves the system\'s reference to the specified String. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.intern")]
	public sealed class StringIntern : BaseAction
	{
		
		[Tooltip("Str.")]
		[SerializeField]
		private StringVar _str;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_str, _result);
		}
		
		public override void Execute()
		{
			//System.String.Intern(System.String);
			_result.Value = string.Intern(_str.Value);
		}
		
		public override string GetSummary()
		{
			return "String Intern: {_str} -> {_result}";
		}
	}
}
