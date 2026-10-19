
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ConvertibleGroup("QuaternionLerp")]
	[ActionDescription("Interpolates between a and b by t and normalizes the result afterwards. " +
	                   "The parameter t is not clamped.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.LerpUnclamped.html")]
	public sealed class QuaternionLerpUnclamped : BaseAction
	{
		public override bool CanUsePerSecond => true;
		
		[Tooltip("A.")]
		[SerializeField]
		private QuaternionVar _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private QuaternionVar _b;
		
		[Tooltip("Value used to interpolate between a and b. " + Strings.LerpPerSecondNode)]
		[SerializeField]
		private FloatVar _t;
		
		[Tooltip("Store the result in Quaternion variable.")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _result;
		
		public override bool CanExecute() => CheckParameters(_a, _b, _t, _result);

		public override void Execute()
		{
			_result.Value = Quaternion.LerpUnclamped(_a.Value, _b.Value, _t.Value * PerSecond);
		}

		public override string GetSummary() => "Lerp {_a} to {_b} at {_t} (unclamped) -> {_result} {PerSecond}";
	}
}
