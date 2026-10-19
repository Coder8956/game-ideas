
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MathUtilities)]
	[ActionDescription("Returns true if the value is power of two.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.IsPowerOfTwo.html")]
	public sealed class MathfIsPowerOfTwo : BaseAction
	{
		
		[Tooltip("Value.")]
		[SerializeField]
		private IntegerVar _value;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_value, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.IsPowerOfTwo(System.Int32);
			_result.Value = Mathf.IsPowerOfTwo(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_value} is power of 2 -> {_result}";
		}
	}
}
