
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a new string in which a specified string is inserted at a specified index" +
		" position in this instance. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.insert")]
	public sealed class StringInsert : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Start Index.")]
		[SerializeField]
		private IntegerVar _startIndex;
		
		[Tooltip("Value.")]
		[SerializeField]
		private StringVar _value;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _startIndex, _value, _result);
		}
		
		public override void Execute()
		{
			//System.String.Insert(System.Int32, System.String);
			_result.Value = _string.Value.Insert(_startIndex.Value, _value.Value);
		}
		
		public override string GetSummary()
		{
			return "Insert {_string} {_startIndex} {_value} -> {_result}";
		}
	}
}
