
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Retrieves a reference to a specified String. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.isinterned")]
	public sealed class StringIsInterned : BaseAction
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
			//System.String.IsInterned(System.String);
			_result.Value = string.IsInterned(_str.Value);
		}
		
		public override string GetSummary()
		{
			return "String Is Interned: {_str} -> {_result}";
		}
	}
}
