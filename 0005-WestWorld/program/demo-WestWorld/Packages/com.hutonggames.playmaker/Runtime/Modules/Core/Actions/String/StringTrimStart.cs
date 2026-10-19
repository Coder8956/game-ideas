
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Removes all the leading white-space characters from the current string.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.trimstart")]
	public sealed class StringTrimStart : BaseAction
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
			//System.String.TrimStart();
			_result.Value = _string.Value.TrimStart();
		}
		
		public override string GetSummary()
		{
			return "Trim Start {_string} -> {_result}";
		}
	}
}
