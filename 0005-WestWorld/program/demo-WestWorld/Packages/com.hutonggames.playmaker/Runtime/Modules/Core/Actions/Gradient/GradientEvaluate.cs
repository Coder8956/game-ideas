
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gradient)]
	[ActionDescription("Calculate color at a given time.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gradient.Evaluate.html")]
	public sealed class GradientEvaluate : BaseAction
	{
		
		[Tooltip("The Gradient.")]
		[SerializeField]
		private GradientVar _gradient;
		
		[FormerlySerializedAs("_time")]
		[Tooltip("Normalized position (0–1) used to sample the Gradient.")]
		[SerializeField]
		private FloatVar _position;
		
		[Tooltip("Store the result in Color variable.")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _result;
		
		public override bool CanExecute() => CheckParameters(_gradient, _position, _result);

		public override void Execute() => _result.Value = _gradient.Value.Evaluate(_position.Value);

		public override string GetSummary() => "Evaluate {_gradient} at {_position} -> {_result}";
	}
}
