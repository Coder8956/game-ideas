
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Integer)]
	[ActionDescription("Converts the numeric value of this instance to its equivalent string representation.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.int32.tostring")]
	public sealed class IntegerToString__Format : BaseAction
	{
		
		[Tooltip("The Integer.")]
		[SerializeField]
		private IntegerRef _integer;
		
		[Tooltip("Format. For example, 0000 formats the number as four digits. See help for all options.")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _format;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute() => CheckParameters(_integer, _format, _result);

		public override void Execute()
		{
			//System.Int32.ToString(System.String);
			_result.Value = _integer.Value.ToString(_format.Value);
		}
		
		public override string GetSummary()
		{
			return "{_integer} To String {_format} -> {_result}";
		}
	}
}
