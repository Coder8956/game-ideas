using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Interpolation)]
	[ActionDescription("Calculates a linear falloff from Distance, Range, and Strength. The result is Strength at zero distance and falls to 0 at or beyond Range.")]
	public sealed class MathfDistanceFalloff : BaseAction
	{
		
		[Tooltip("The distance to evaluate.")]
		[SerializeField]
		private FloatRef _distance;
		
		[Tooltip("Distance where the result reaches zero.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _range;
		
		[Tooltip("Maximum value returned at distance 0.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _strength;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute() => CheckParameters(_distance, _range, _strength, _result);

		public override void Execute()
		{
			var distance = _distance.Value;
			var range = _range.Value;
			var strength = _strength.Value;

			var falloff = range > 0f
				? Mathf.Clamp01(1f - distance / range)
				: Mathf.Approximately(distance, 0f) ? 1f : 0f;

			_result.Value = Mathf.Max(0f, strength * falloff);
		}
		
		public override string GetSummary() => "Distance falloff {_distance}/{_range} x {_strength} -> {_result}";
	}
}
