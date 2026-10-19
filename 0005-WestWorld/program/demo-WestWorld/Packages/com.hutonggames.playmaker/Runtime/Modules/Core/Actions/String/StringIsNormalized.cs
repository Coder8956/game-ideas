
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Indicates whether this string is in a particular Unicode normalization form. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.isnormalized")]
	public sealed class StringIsNormalized : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _result);
		}
		
		public override void Execute()
		{
			//System.String.IsNormalized();
			_result.Value = _string.Value.IsNormalized();
		}
		
		public override string GetSummary()
		{
			return "Is Normalized {_string} -> {_result}";
		}
	}
}
