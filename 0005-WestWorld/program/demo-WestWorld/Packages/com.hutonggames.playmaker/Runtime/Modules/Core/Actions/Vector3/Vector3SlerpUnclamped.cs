
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Spherically interpolates between two vectors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.SlerpUnclamped.html")]
	public sealed class Vector3SlerpUnclamped : BaseAction
	{
		public override bool CanUsePerSecond => true;

		[Tooltip("A.")]
		[SerializeField]
		private Vector3Var _a;
		
		[Tooltip("B.")]
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
			_result.Value = Vector3.SlerpUnclamped(_a.Value, _b.Value, _t.Value * PerSecond);
		}
		
		public override string GetSummary() => "Slerp {_a} to {_b} at {_t} (unclamped) -> {_result} {PerSecond}";
	}
}
