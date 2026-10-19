
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Compares a Float to another Float and " +
		"returns an integer that indicates whether the value is less than," +
		" equal to, or greater than the other Float. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.compareto")]
	public sealed class FloatCompareTo : BaseAction
	{
		
		[Tooltip("The Float.")]
		[SerializeField]
		private FloatRef _float;
		
		[Tooltip("Value.")]
		[SerializeField]
		private FloatVar _value;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField, WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_float, _value, _result);
		}
		
		public override void Execute()
		{
			//System.Single.CompareTo(System.Single);
			_result.Value = _float.Value.CompareTo(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Compare {_float} To {_value} -> {_result}";
		}
	}
}
