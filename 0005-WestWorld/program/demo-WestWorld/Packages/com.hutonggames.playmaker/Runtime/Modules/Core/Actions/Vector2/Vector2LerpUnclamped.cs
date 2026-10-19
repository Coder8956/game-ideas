
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Linearly interpolates between vectors a and b by t.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.LerpUnclamped.html")]
	public sealed class Vector2LerpUnclamped : BaseAction
	{
		public override bool CanUsePerSecond => true;
		
		[Tooltip("A.")]
		[SerializeField]
		private Vector2Var _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private Vector2Var _b;
		
		[Tooltip("Value used to interpolate between a and b. " + Strings.LerpPerSecondNode)]
		[SerializeField]
		private FloatVar _t;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute() => CheckParameters(_a, _b, _t, _result);

		public override void Execute()
		{
			_result.Value = Vector2.LerpUnclamped(_a.Value, _b.Value, _t.Value * PerSecond);
		}

		public override string GetSummary() => "Lerp {_a} to {_b} at {_t} (unclamped) -> {_result} {PerSecond}";
	}
}
