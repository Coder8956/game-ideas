
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a copy of this string converted to uppercase. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.toupper")]
	public sealed class StringToUpper : BaseAction
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
			//System.String.ToUpper();
			_result.Value = _string.Value.ToUpper();
		}
		
		public override string GetSummary()
		{
			return "To Upper {_string} -> {_result}";
		}
	}
}
