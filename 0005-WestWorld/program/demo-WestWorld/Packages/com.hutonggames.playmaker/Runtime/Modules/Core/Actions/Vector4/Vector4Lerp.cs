
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Linearly interpolates between two vectors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.Lerp.html")]
	public sealed class Vector4Lerp : BaseAction
	{
		public override bool CanUsePerSecond => true;

		[Tooltip("A.")]
		[SerializeField]
		private Vector4Var _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private Vector4Var _b;
		
		[Tooltip("Value used to interpolate between a and b. " + Strings.LerpPerSecondNode)]
		[SerializeField]
		private FloatVar _t;
		
		[Tooltip("Store the result in Vector4 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _result;
		
		public override bool CanExecute() => CheckParameters(_a, _b, _t, _result);

		public override void Execute()
		{
			_result.Value = Vector4.Lerp(_a.Value, _b.Value, _t.Value * PerSecond);
		}
		
		public override string GetSummary() => "Lerp {_a} to {_b} at {_t} -> {_result} {PerSecond}";
	}
}
