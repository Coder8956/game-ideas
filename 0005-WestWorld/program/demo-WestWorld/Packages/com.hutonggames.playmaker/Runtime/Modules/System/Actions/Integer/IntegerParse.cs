
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Integer)]
	[ActionDescription("Converts the string representation of a number to its Integer equivalent.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.int32.parse")]
	public sealed class IntegerParse : BaseAction
	{
		
		[Tooltip("String to parse.")]
		[SerializeField]
		private StringVar _string;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute() => CheckParameters(_string, _result);

		public override void Execute()
		{
			//System.Int32.Parse(System.String);
			_result.Value = int.Parse(_string.Value);
		}
		
		public override string GetSummary() => "Integer Parse: {_string} -> {_result}";
	}
}
