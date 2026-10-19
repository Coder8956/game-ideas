
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color32)]
	[ActionDescription("Linearly interpolates between colors a and b by t.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color32.LerpUnclamped.html")]
	public sealed class Color32LerpUnclamped : BaseAction
	{
		public override bool CanUsePerSecond => true;
		
		[Tooltip("A.")]
		[SerializeField]
		private Color32Var _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private Color32Var _b;
		
		[Tooltip("Value used to interpolate between a and b. " + Strings.LerpPerSecondNode)]
		[SerializeField]
		private FloatVar _t;
		
		[Tooltip("Store the result in Color32 variable.")]
		[SerializeField]
		[WriteOnly]
		private Color32Ref _result;
		
		public override bool CanExecute() => CheckParameters(_a, _b, _t, _result);

		public override void Execute()
		{
			_result.Value = Color32.LerpUnclamped(_a.Value, _b.Value, _t.Value * PerSecond);
		}
		
		public override string GetSummary() => "Lerp {_a} to {_b} at {_t} (unclamped) -> {_result} {PerSecond}";
	}
}
