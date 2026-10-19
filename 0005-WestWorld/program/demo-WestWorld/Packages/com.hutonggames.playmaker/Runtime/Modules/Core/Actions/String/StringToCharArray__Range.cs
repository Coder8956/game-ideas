
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Copies the characters in this instance to a Unicode character array. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.tochararray")]
	public sealed class StringToCharArray__Range : BaseAction
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
		
		[Tooltip("Store the result in Char List variable.")]
		[SerializeField]
		[WriteOnly]
		private CharListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _startIndex, _length, _result);
		}
		
		public override void Execute()
		{
			//System.String.ToCharArray(System.Int32, System.Int32);
			_result.Values = _string.Value.ToCharArray(_startIndex.Value, _length.Value);
		}
		
		public override string GetSummary()
		{
			return "To Char Array {_string} {_startIndex} {_length} -> {_result}";
		}
	}
}
