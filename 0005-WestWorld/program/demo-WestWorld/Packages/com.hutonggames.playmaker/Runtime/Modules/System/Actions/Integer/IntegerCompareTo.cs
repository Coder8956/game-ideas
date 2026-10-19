
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Integer)]
	[ActionDescription("Compares this instance to a specified Integer and returns an " +
	                   "indication of their relative values. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.int32.compareto")]
	public sealed class IntegerCompareTo : BaseAction
	{
		
		[Tooltip("The Integer.")]
		[SerializeField]
		private IntegerRef _integer;
		
		[Tooltip("Value.")]
		[SerializeField]
		private IntegerVar _value;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_integer, _value, _result);
		}
		
		public override void Execute()
		{
			//System.Int32.CompareTo(System.Int32);
			_result.Value = _integer.Value.CompareTo(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Compare {_integer} To {_value} -> {_result}";
		}
	}
}
