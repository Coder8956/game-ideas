
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a string array that contains the substrings in this instance that are del" +
		"imited by elements of a specified string or Unicode character array. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.split")]
	public sealed class StringSplitStrings__MaxNumber : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Separator.")]
		[SerializeField]
		private StringListVar _separator;
		
		[Tooltip("Count.")]
		[SerializeField]
		private IntegerVar _count;
		
		[Tooltip("Options.")]
		[SerializeField]
		private StringSplitOptions _options;
		
		[Tooltip("Store the result in String List variable.")]
		[SerializeField]
		[WriteOnly]
		private StringListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _separator, _count, _result);
		}
		
		public override void Execute()
		{
			//System.String.Split(System.String[], System.Int32, System.StringSplitOptions);
			var options = StringSplitOptionsUtility.GetRuntimeOptions(_options);
			_result.Values = _string.Value.Split(_separator.Values, _count.Value, options);
		}
		
		public override string GetSummary()
		{
			return "Split {_string} {_separator} {_count} {_options} -> {_result}";
		}
	}
}
