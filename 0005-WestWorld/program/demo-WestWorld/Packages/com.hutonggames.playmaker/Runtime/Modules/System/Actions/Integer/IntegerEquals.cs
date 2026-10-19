
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Integer)]
	[ActionDescription("Returns a value indicating whether this instance is equal to a specified Integer value.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.int32.equals")]
	public sealed class IntegerEquals : BaseAction
	{
		
		[Tooltip("The Integer.")]
		[SerializeField]
		private IntegerRef _integer;
		
		[Tooltip("The value to compare to.")]
		[SerializeField]
		private IntegerVar _value;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute() => CheckParameters(_integer, _value, _result);

		public override void Execute()
		{
			//System.Int32.Equals(System.Int32);
			_result.Value = _integer.Value.Equals(_value.Value);
		}
		
		public override string GetSummary() => "{_integer} Equals {_value} -> {_result}";
	}
}
