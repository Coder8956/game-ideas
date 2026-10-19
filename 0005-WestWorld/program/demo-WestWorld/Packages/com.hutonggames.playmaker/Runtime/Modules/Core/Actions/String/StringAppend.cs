
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Adds a String to the end of a String.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string")]
	public sealed class StringAppend : BaseAction
	{
		[WriteOnly]
		[Tooltip("The String to add to.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("String to append")]
		[SerializeField]
		private StringVar _appendString;
		
		public override bool CanExecute() => CheckParameters(_string, _appendString);

		public override void Execute() => _string.Value += _appendString.Value;

		public override string GetSummary() => "{_string} Append {_appendString}";
	}
}
