
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Use a low pass filter to reduce the influence of sudden changes in a quaternion Variable.")]
	public sealed class QuaternionLowPassFilter : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The quaternion to filter.")]
		[SerializeField]
		private QuaternionRef _quaternion;

		[VarSlider(0,1)]
		[Tooltip("Controls how much the new value affects the filtered result.\n\n" +
		         "Lower values = smoother but more delayed\n" +
		         "Example: 0.1 means blend 10% of new value with 90% of previous value")]		
		[SerializeField, DefaultValue(0.2f)]
		private FloatVar _filteringFactor;		
		
		private Quaternion _filteredQuaternion;
		
		public override bool CanExecute() => CheckParameters(_quaternion);

		public override void OnStart()
		{
			var value = _quaternion.Value;
			_filteredQuaternion = new Quaternion(value.x, value.y, value.z, value.w);
		}

		public override void Execute()
		{
			var value = _quaternion.Value;

			_filteredQuaternion.x = value.x * _filteringFactor.Value +
			                        _filteredQuaternion.x * (1.0f - _filteringFactor.Value);
			_filteredQuaternion.y = value.y * _filteringFactor.Value +
			                        _filteredQuaternion.y * (1.0f - _filteringFactor.Value);
			_filteredQuaternion.z = value.z * _filteringFactor.Value +
			                        _filteredQuaternion.z * (1.0f - _filteringFactor.Value);
			_filteredQuaternion.w = value.w * _filteringFactor.Value +
			                        _filteredQuaternion.w * (1.0f - _filteringFactor.Value);

			// Normalize the quaternion to ensure it remains a valid rotation
			_quaternion.Value = _filteredQuaternion.normalized;
		}
		
		public override string GetSummary()
		{
			return "{_quaternion} low pass filter: {_filteringFactor}";
		}
	}
}
