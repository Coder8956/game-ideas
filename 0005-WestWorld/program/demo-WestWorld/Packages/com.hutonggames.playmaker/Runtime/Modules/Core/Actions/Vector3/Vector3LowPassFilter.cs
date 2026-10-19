using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Use a low pass filter to reduce the influence of sudden changes in a Vector3 Variable.")]
	public sealed class Vector3LowPassFilter : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The vector to filter.")]
		[SerializeField]
		private Vector3Ref _vector;

		[VarSlider(0,1)]
		[Tooltip("Controls how much the new value affects the filtered result.\n\n" +
		         "Lower values = smoother but more delayed\n" +
		         "Example: 0.1 means blend 10% of new value with 90% of previous value")]
		[SerializeField, DefaultValue(0.2f)]
		private FloatVar _filteringFactor;

		private Vector3 _filteredVector;

		public override bool CanExecute() => CheckParameters(_vector);

		public override void OnStart()
		{
			_filteredVector = _vector.Value;
		}

		public override void Execute()
		{
			var value = _vector.Value;

			_filteredVector.x = value.x * _filteringFactor.Value +
			                    _filteredVector.x * (1.0f - _filteringFactor.Value);
			_filteredVector.y = value.y * _filteringFactor.Value +
			                    _filteredVector.y * (1.0f - _filteringFactor.Value);
			_filteredVector.z = value.z * _filteringFactor.Value +
			                    _filteredVector.z * (1.0f - _filteringFactor.Value);

			_vector.Value = _filteredVector;
		}

		public override string GetSummary()
		{
			return "{_vector} low pass filter: {_filteringFactor}";
		}
	}
}
