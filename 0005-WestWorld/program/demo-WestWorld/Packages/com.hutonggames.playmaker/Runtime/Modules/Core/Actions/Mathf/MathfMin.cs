
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Returns the smallest of two or more values.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Min.html")]
	public sealed class MathfMin : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private FloatVar _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private FloatVar _b;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_a, _b, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Min(System.Single, System.Single);
			_result.Value = Mathf.Min(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Min({_a}, {_b}) -> {_result}";
		}
	}
}
