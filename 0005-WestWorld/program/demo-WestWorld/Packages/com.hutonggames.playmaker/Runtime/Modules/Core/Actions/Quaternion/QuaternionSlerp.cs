
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ConvertibleGroup("QuaternionLerp")]
	[ActionDescription("Spherically linear interpolates between unit quaternions a and b by a ratio of t.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.Slerp.html")]
	public sealed class QuaternionSlerp : BaseAction
	{
		public override bool CanUsePerSecond => true;
		
		[Tooltip("Start unit quaternion value, returned when t = 0.")]
		[SerializeField]
		private QuaternionVar _a;
		
		[Tooltip("End unit quaternion value, returned when t = 1.")]
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
			_result.Value = Quaternion.Slerp(_a.Value, _b.Value, _t.Value * PerSecond);
		}
		
		public override string GetSummary() => "Slerp {_a} to {_b} at {_t} -> {_result} {PerSecond}";
	}
}
