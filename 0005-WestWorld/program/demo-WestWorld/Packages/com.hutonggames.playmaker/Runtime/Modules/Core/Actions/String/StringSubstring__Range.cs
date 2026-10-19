
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Retrieves a substring from this instance. This member is overloaded. For complete" +
		" information about this member, including syntax, usage, and examples, click a n" +
		"ame in the overload list. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.substring")]
	public sealed class StringSubstring__Range : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Start Index.")]
		[SerializeField]
		private IntegerVar _startIndex;
		
		[Tooltip("Length.")]
		[SerializeField]
		private IntegerVar _length;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _startIndex, _length, _result);
		}
		
		public override void Execute()
		{
			//System.String.Substring(System.Int32, System.Int32);
			_result.Value = _string.Value.Substring(_startIndex.Value, _length.Value);
		}
		
		public override string GetSummary()
		{
			return "Substring {_string} {_startIndex} {_length} -> {_result}";
		}
	}
}
