
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Determines whether the beginning of this string instance matches the specified string.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.startswith")]
	public sealed class StringStartsWith : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Value.")]
		[SerializeField]
		private StringVar _value;
		
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
			//System.String.StartsWith(System.String);
			_result.Value = _string.Value.StartsWith(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Starts With {_string} {_value} -> {_result}";
		}
	}
}
