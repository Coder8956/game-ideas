
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Copies the characters in this instance to a Unicode character array. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.tochararray")]
	public sealed class StringToCharArray : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Store the result in Char List variable.")]
		[SerializeField]
		[WriteOnly]
		private CharListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _result);
		}
		
		public override void Execute()
		{
			//System.String.ToCharArray();
			_result.Values = _string.Value.ToCharArray();
		}
		
		public override string GetSummary()
		{
			return "To Char Array {_string} -> {_result}";
		}
	}
}
