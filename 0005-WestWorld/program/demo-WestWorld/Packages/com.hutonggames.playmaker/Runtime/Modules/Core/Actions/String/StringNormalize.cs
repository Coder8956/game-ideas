
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a new string whose binary representation is in a particular Unicode norma" +
		"lization form. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.normalize")]
	public sealed class StringNormalize : BaseAction
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
			//System.String.Normalize();
			_result.Value = _string.Value.Normalize();
		}
		
		public override string GetSummary()
		{
			return "Normalize {_string} -> {_result}";
		}
	}
}
