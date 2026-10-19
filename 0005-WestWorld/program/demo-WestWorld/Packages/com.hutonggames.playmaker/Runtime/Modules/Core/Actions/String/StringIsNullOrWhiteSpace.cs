
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Indicates whether a specified string is null, empty, or consists only of white-sp" +
		"ace characters. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace")]
	public sealed class StringIsNullOrWhiteSpace : BaseAction
	{
		
		[Tooltip("Value.")]
		[SerializeField]
		private StringVar _value;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_value, _result);
		}
		
		public override void Execute()
		{
			//System.String.IsNullOrWhiteSpace(System.String);
			_result.Value = string.IsNullOrWhiteSpace(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "String Is Null Or White Space: {_value} -> {_result}";
		}
	}
}
