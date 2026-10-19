using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[ActionCategory(Category.String)]
	[ActionDescription("Joins strings using the specified separator between each string. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.join")]

	public sealed class BuildString : BaseAction
	{
		[Tooltip("Strings to join.")]
		[SerializeField]
		private StringVar[] _strings;
		
		[Tooltip("Separator to insert between strings.")]
		[SerializeField]
		private StringVar _separator;
		
		[Tooltip("Add Separator to end of built string.")]
		[SerializeField]
		private BoolVar _addToEnd;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_strings, _result);
		}

		public override void Execute()
		{
			var builder = new System.Text.StringBuilder();

			for (int i = 0; i < _strings.Length; i++)
			{
				builder.Append(_strings[i].Value);

				if (i < _strings.Length - 1 || _addToEnd.Value)
				{
					builder.Append(_separator.Value);
				}
			}

			_result.Value = builder.ToString();
		}
		
		public override string GetSummary()
		{
			return "Join {_strings} with {_separator} -> {_result}";
		}
	}
}
