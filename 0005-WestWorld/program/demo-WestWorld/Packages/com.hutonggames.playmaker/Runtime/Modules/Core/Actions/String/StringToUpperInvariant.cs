
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a copy of this String object converted to uppercase using the casing rule" +
		"s of the invariant culture. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.toupperinvariant")]
	public sealed class StringToUpperInvariant : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _result);
		}
		
		public override void Execute()
		{
			//System.String.ToUpperInvariant();
			_result.Value = _string.Value.ToUpperInvariant();
		}
		
		public override string GetSummary()
		{
			return "To Upper Invariant {_string} -> {_result}";
		}
	}
}
