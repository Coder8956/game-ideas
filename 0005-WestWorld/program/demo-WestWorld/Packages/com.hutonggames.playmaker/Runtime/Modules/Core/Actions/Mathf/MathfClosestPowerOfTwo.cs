
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MathUtilities)]
	[ActionDescription("Returns the closest power of two value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.ClosestPowerOfTwo.html")]
	public sealed class MathfClosestPowerOfTwo : BaseAction
	{
		
		[Tooltip("Value.")]
		[SerializeField]
		private IntegerVar _value;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_value, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.ClosestPowerOfTwo(System.Int32);
			_result.Value = Mathf.ClosestPowerOfTwo(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Get closest power of 2 to {_value} -> {_result}";
		}
	}
}
