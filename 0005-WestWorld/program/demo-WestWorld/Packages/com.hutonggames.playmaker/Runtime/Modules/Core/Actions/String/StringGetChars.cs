/*
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Gets the Char object at a specified position in the current String object. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.chars")]
	public sealed class StringGetChars : BaseAction
	{
		
		[Tooltip("The String")]
		[SerializeField]
		private HutongGames.PlayMaker.StringRef _string;
		
		[Tooltip("Get String Chars")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Actions.CharRef _getChars;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _getChars);
		}
		
		public override void Execute()
		{
			this._getChars.Value = this._string.Value.Chars;
		}
		
		public override string GetSummary()
		{
			return "Get {_string} Chars -> {_getChars}";
		}
	}
}
*/