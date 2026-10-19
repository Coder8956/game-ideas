
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Joins strings in a list using the specified separator between each string. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.join")]
	public sealed class StringJoin : BaseAction
	{
		[FormerlySerializedAs("_value")]
		[Tooltip("Strings to join.")]
		[SerializeField]
		private StringListVar _strings;
		
		[Tooltip("Separator.")]
		[SerializeField]
		private StringVar _separator;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_separator, _strings, _result);
		}
		
		public override void Execute()
		{
			_result.Value = string.Join(_separator.Value, _strings.Values);
		}
		
		public override string GetSummary()
		{
			return "Join {_strings} with {_separator} -> {_result}";
		}
	}
}
