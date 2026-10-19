
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Interpolation)]
	[ActionDescription("Same as Lerp but makes sure the values interpolate correctly " +
	                   "when they wrap around 360 degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.LerpAngle.html")]
	public sealed class MathfLerpAngle : BaseAction
	{
		public override bool CanUsePerSecond => true;
		
		[Tooltip("The start angle. A float expressed in degrees.")]
		[SerializeField]
		private FloatVar _a;
		
		[Tooltip("The end angle. A float expressed in degrees.")]
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
			_result.Value = Mathf.LerpAngle(_a.Value, _b.Value, _t.Value * PerSecond);
		}

	public override string GetSummary() => "Lerp angle {_a} to {_b} at {_t} -> {_result} {PerSecond}";
	}
}
