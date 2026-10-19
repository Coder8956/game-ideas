using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Use a high pass filter to reduce the influence of slow changes in a Quaternion Variable.")]
	public sealed class QuaternionHighPassFilter : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The quaternion to filter.")]
		[SerializeField]
		private QuaternionRef _quaternion;

		[VarSlider(0,1)]
		[Tooltip("Controls how much the new value affects the low pass component used by the high pass filter.\n\n" +
		         "Lower values = stronger low-frequency rejection but more lag in the low pass estimate\n" +
		         "Example: 0.1 means blend 10% of new value with 90% of previous low pass value")]
		[SerializeField, DefaultValue(0.2f)]
		private FloatVar _filteringFactor;

		private Quaternion _lowPassQuaternion;

		public override bool CanExecute() => CheckParameters(_quaternion);

		public override void OnStart()
		{
			var value = _quaternion.Value;
			_lowPassQuaternion = new Quaternion(value.x, value.y, value.z, value.w);
		}

		public override void Execute()
		{
			var value = _quaternion.Value;

			_lowPassQuaternion.x = value.x * _filteringFactor.Value +
			                       _lowPassQuaternion.x * (1.0f - _filteringFactor.Value);
			_lowPassQuaternion.y = value.y * _filteringFactor.Value +
			                       _lowPassQuaternion.y * (1.0f - _filteringFactor.Value);
			_lowPassQuaternion.z = value.z * _filteringFactor.Value +
			                       _lowPassQuaternion.z * (1.0f - _filteringFactor.Value);
			_lowPassQuaternion.w = value.w * _filteringFactor.Value +
			                       _lowPassQuaternion.w * (1.0f - _filteringFactor.Value);

			// Keep the low-pass component normalized before deriving the high-pass output.
			_lowPassQuaternion = _lowPassQuaternion.normalized;
			_quaternion.Value = value * Quaternion.Inverse(_lowPassQuaternion);
		}

		public override string GetSummary()
		{
			return "{_quaternion} high pass filter: {_filteringFactor}";
		}
	}
}
