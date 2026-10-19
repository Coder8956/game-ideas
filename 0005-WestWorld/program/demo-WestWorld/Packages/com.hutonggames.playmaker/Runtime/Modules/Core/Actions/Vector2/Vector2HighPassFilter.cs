using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Use a high pass filter to reduce the influence of slow changes in a Vector2 Variable.")]
	public sealed class Vector2HighPassFilter : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The vector to filter.")]
		[SerializeField]
		private Vector2Ref _vector;

		[VarSlider(0,1)]
		[Tooltip("Controls how much the new value affects the low pass component used by the high pass filter.\n\n" +
		         "Lower values = stronger low-frequency rejection but more lag in the low pass estimate\n" +
		         "Example: 0.1 means blend 10% of new value with 90% of previous low pass value")]
		[SerializeField, DefaultValue(0.2f)]
		private FloatVar _filteringFactor;

		private Vector2 _lowPassVector;

		public override bool CanExecute() => CheckParameters(_vector);

		public override void OnStart()
		{
			_lowPassVector = _vector.Value;
		}

		public override void Execute()
		{
			var value = _vector.Value;

			_lowPassVector.x = value.x * _filteringFactor.Value +
			                   _lowPassVector.x * (1.0f - _filteringFactor.Value);
			_lowPassVector.y = value.y * _filteringFactor.Value +
			                   _lowPassVector.y * (1.0f - _filteringFactor.Value);

			_vector.Value = value - _lowPassVector;
		}

		public override string GetSummary()
		{
			return "{_vector} high pass filter: {_filteringFactor}";
		}
	}
}
