using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Linearly interpolates between two points.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html")]
	public sealed class Vector3Lerp : BaseAction
	{
		public override bool CanUsePerSecond => true;

		[Tooltip("Start value, returned when t = 0.")]
		[SerializeField]
		private Vector3Var _a;
		
		[Tooltip("End value, returned when t = 1.")]
		[SerializeField]
		private Vector3Var _b;
		
		[Tooltip("Value used to interpolate between a and b. " + Strings.LerpPerSecondNode)]
		[SerializeField]
		private FloatVar _t;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute() => CheckParameters(_a, _b, _t, _result);

		public override void Execute()
		{
			_result.Value = Vector3.Lerp(_a.Value, _b.Value, _t.Value * PerSecond);
		}

		public override string GetSummary() => "Lerp {_a} to {_b} at {_t} -> {_result} {PerSecond}";
	}
}
