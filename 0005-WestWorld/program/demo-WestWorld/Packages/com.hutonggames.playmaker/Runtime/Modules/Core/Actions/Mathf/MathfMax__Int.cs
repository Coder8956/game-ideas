
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Integer)]
	[ActionDescription("Returns the largest value. When comparing negative values, values closer to zero " +
		"are considered larger.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Max.html")]
	public sealed class MathfMax__Int : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private IntegerVar _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private IntegerVar _b;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField, WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute() => CheckParameters(_a, _b, _result);

		public override void Execute() => _result.Value = Mathf.Max(_a.Value, _b.Value);

		public override string GetSummary() => "Max({_a}, {_b}) -> {_result}";
	}
}
