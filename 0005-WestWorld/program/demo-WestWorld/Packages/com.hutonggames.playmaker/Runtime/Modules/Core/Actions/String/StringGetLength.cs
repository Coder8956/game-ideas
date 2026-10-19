
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Gets the number of characters in the current String object. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.length")]
	public sealed class StringGetLength : BaseAction
	{
		
		[Tooltip("The String")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Get String Length")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getLength;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _getLength);
		}
		
		public override void Execute()
		{
			_getLength.Value = _string.Value.Length;
		}
		
		public override string GetSummary()
		{
			return "Get {_string} Length -> {_getLength}";
		}
	}
}
