
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Integer)]
	[ActionDescription("Get the absolute value of an integer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Abs.html")]
	public sealed class MathfAbs__Int : BaseAction
	{
		
		[Tooltip("The Integer Value.")]
		[SerializeField]
		private IntegerVar _value;
		
		[Tooltip("Store the result in an Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_value, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Abs(System.Int32);
			_result.Value = Mathf.Abs(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Abs {_value} -> {_result}";
		}
	}
}
