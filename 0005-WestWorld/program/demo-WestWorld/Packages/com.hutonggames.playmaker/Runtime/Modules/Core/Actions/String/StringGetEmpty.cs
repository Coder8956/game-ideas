
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Represents the empty string. This field is read-only. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.empty")]
	public sealed class StringGetEmpty : BaseAction
	{
		
		[Tooltip("Get String Empty")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getEmpty;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getEmpty);
		}
		
		public override void Execute()
		{
			_getEmpty.Value = string.Empty;
		}
		
		public override string GetSummary()
		{
			return "Get System.String Empty -> {_getEmpty} ";
		}
	}
}
