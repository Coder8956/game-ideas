
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Concatenates one or more instances of String, or the String representations of th" +
		"e values of one or more instances of Object. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.concat")]
	public sealed class StringConcat : BaseAction
	{
		
		[Tooltip("The first string.")]
		[SerializeField]
		private StringVar _string0;
		
		[Tooltip("The second string.")]
		[SerializeField]
		private StringVar _string1;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string0, _string1, _result);
		}
		
		public override void Execute()
		{
			//System.String.Concat(System.String, System.String);
			_result.Value = string.Concat(_string0.Value, _string1.Value);
		}
		
		public override string GetSummary()
		{
			return "String Concat: {_string0} {_string1} -> {_result}";
		}
	}
}
