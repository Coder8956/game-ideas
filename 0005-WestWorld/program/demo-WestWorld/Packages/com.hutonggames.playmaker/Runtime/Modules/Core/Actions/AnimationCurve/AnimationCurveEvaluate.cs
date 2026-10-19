
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AnimationCurve)]
	[ActionDescription("Evaluate the curve at time.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AnimationCurve.Evaluate.html")]
	public sealed class AnimationCurveEvaluate : BaseAction
	{
		
		[Tooltip("The AnimationCurve.")]
		[SerializeField]
		private AnimationCurveRef _animationCurve;
		
		[Tooltip("The time within the curve you want to evaluate (the horizontal axis in the curve graph).")]
		[SerializeField]
		private FloatVar _time;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute() => CheckParameters(_animationCurve, _time, _result);

		public override void Execute() => _result.Value = _animationCurve.Value.Evaluate(_time.Value);

		public override string GetSummary() => "Evaluate {_animationCurve} at {_time} -> {_result}";
	}
}
