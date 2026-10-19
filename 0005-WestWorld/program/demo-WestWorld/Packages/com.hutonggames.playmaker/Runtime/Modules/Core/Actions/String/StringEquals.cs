
using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{


	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Determines whether two String objects have the same value. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.equals")]
	public sealed class StringEquals : BaseAction
	{
		[Tooltip("The string to check.")] [SerializeField]
		private StringRef _string;

		[Tooltip("The other string value.")] [SerializeField] 
		private StringVar _value;

		[Tooltip("Store the result in Bool variable.")]
		[SerializeField, WriteOnly]
		[FormerlySerializedAs("StoreResult")]
		private BoolRef _result;
		
		public override bool CanExecute() => CheckParameters(_string, _value, _result);

		public override void Execute() => 
			_result.Value = _string.Value.Equals(_value.Value, StringComparison.Ordinal);

		public override string GetSummary() => "{_string} equals {_value} -> {_result}";
	}
}
