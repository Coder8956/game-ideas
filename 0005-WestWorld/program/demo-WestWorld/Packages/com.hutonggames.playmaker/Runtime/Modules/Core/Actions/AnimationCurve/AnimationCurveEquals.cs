
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AnimationCurve)]
	[ActionDescription("Test if an AnimationCurve is equal to another AnimationCurve.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AnimationCurve.html")]
	public sealed class AnimationCurveEquals : BaseAction
	{
		
		[Tooltip("The AnimationCurve.")]
		[SerializeField]
		private AnimationCurveRef _animationCurve;
		
		[Tooltip("Other.")]
		[SerializeField]
		private AnimationCurveVar _other;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute() => CheckParameters(_animationCurve, _other, _result);

		public override void Execute() => _result.Value = Equals(_animationCurve.Value, _other.Value);

		public override string GetSummary()
		{
			return "{_animationCurve} equals {_other} -> {_result}";
		}
	}
}
