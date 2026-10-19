
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Concatenates one or more strings.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.concat")]
	public sealed class StringConcatMultiple : BaseAction
	{
		
		[Tooltip("Values.")]
		[SerializeField]
		private List<StringVar> _values;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_values, _result);
		}
		
		public override void Execute()
		{
			using var sb = StringBuilderPool.GetPooled();
			foreach (var value in _values)
			{
				sb.Append(value?.Value);
			}
			_result.Value = sb.ToString();
		}
		
		public override string GetSummary()
		{
			return "String Concat: {_values} -> {_result}";
		}
	}
}
