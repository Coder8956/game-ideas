
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MathUtilities)]
	[ActionDescription("Returns the next power of two that is equal to, or greater than, the argument.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.NextPowerOfTwo.html")]
	public sealed class MathfNextPowerOfTwo : BaseAction
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
			//UnityEngine.Mathf.NextPowerOfTwo(System.Int32);
			_result.Value = Mathf.NextPowerOfTwo(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Get next power of 2 for {_value} -> {_result}";
		}
	}
}
