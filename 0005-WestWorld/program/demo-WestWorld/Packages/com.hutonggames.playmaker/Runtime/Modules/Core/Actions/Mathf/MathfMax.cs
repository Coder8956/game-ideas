
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Returns the largest of two or more values. When comparing negative values, values" +
		" closer to zero are considered larger.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Max.html")]
	public sealed class MathfMax : BaseAction
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
			//UnityEngine.Mathf.Max(System.Single, System.Single);
			_result.Value = Mathf.Max(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Max({_a}, {_b}) -> {_result}";
		}
	}
}
