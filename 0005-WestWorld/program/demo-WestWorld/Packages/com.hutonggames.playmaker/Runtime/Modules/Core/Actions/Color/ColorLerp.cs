
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Linearly interpolates between colors a and b by t.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color.Lerp.html")]
	public sealed class ColorLerp : BaseAction
	{
		public override bool CanUsePerSecond => true;
		
		[Tooltip("Color a.")]
		[SerializeField]
		private ColorVar _a;
		
		[Tooltip("Color b.")]
		[SerializeField]
		private ColorVar _b;
		
		[Tooltip("Value used to interpolate between a and b. " + Strings.LerpPerSecondNode)]
		[SerializeField]
		private FloatVar _t;
		
		[Tooltip("Store the result in Color variable.")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _result;
		
		public override bool CanExecute() => CheckParameters(_a, _b, _t, _result);

		public override void Execute()
		{
			_result.Value = Color.Lerp(_a.Value, _b.Value, _t.Value * PerSecond);
		}

		public override string GetSummary() => "Lerp {_a} to {_b} at {_t}  -> {_result} {PerSecond}";
	}
}
