
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Integer)]
	[ActionDescription("Returns the smallest of two or more values.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Min.html")]
	public sealed class MathfMin__Int : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private IntegerVar _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private IntegerVar _b;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_a, _b, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Min(System.Int32, System.Int32);
			_result.Value = Mathf.Min(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Min({_a}, {_b}) -> {_result}";
		}
	}
}
