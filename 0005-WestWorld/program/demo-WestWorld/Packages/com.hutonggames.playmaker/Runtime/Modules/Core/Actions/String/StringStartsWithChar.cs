
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Determines whether the beginning of this string instance matches the specified st" +
		"ring when compared using the specified culture. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.startswith")]
	public sealed class StringStartsWithChar : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Value.")]
		[SerializeField]
		private CharVar _value;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _value, _result);
		}
		
		public override void Execute()
		{
			//System.String.StartsWith(System.Char);
			_result.Value = _string.Value.StartsWith(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Starts With {_string} {_value} -> {_result}";
		}
	}
}
