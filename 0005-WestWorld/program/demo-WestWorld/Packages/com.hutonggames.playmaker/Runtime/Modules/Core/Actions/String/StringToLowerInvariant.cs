
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a copy of this String object converted to lowercase using the casing rules " +
		"of the invariant culture. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.tolowerinvariant")]
	public sealed class StringToLowerInvariant : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute() => CheckParameters(_string, _result);

		public override void Execute() => _result.Value = _string.Value.ToLowerInvariant();

		public override string GetSummary() => "To Lower Invariant {_string} -> {_result}";
	}
}
