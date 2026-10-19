
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Interpolation)]
	[ActionDescription("Linearly interpolates between a and b by t with no limit to t.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.LerpUnclamped.html")]
	public sealed class MathfLerpUnclamped : BaseAction
	{
		public override bool CanUsePerSecond => true;
		
		[Tooltip("The start value.")]
		[SerializeField]
		private FloatVar _a;
		
		[Tooltip("The end value.")]
		[SerializeField]
		private FloatVar _b;
		
		[Tooltip("Value used to interpolate between a and b. " + Strings.LerpPerSecondNode)]
		[SerializeField]
		private FloatVar _t;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute() => CheckParameters(_a, _b, _t, _result);

		public override void Execute()
		{
			_result.Value = Mathf.LerpUnclamped(_a.Value, _b.Value, _t.Value * PerSecond);
		}

		public override string GetSummary() => "Lerp {_a} to {_b} at {_t} (unclamped) -> {_result} {PerSecond}";
	}
}
