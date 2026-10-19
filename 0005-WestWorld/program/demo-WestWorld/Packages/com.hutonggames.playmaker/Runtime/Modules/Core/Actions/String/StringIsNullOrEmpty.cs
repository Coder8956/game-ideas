
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Indicates whether the specified string is null or an empty string (&amp;quot;&amp" +
		";quot;). ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorempty")]
	public sealed class StringIsNullOrEmpty : BaseAction
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
			//System.String.IsNullOrEmpty(System.String);
			_result.Value = string.IsNullOrEmpty(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "String Is Null Or Empty: {_value} -> {_result}";
		}
	}
}
