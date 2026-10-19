using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Interpolation)]
	[ActionDescription("Maps a float value from one range into another range.")]
	public sealed class MathfMapRange : BaseAction
	{
		[Tooltip("The value to map.")]
		[SerializeField]
		private FloatVar _value;

		[Tooltip("The start of the input range.")]
		[SerializeField]
		private FloatVar _inputMin;

		[Tooltip("The end of the input range.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _inputMax;

		[Tooltip("The start of the output range.")]
		[SerializeField]
		private FloatVar _outputMin;

		[Tooltip("The end of the output range.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _outputMax;

		[Tooltip("Clamp the mapped result to the output range.")]
		[SerializeField]
		private BoolVar _clamp;

		[Tooltip("Store the mapped value in a Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;

		public override bool CanExecute() => CheckParameters(_value, _inputMin, _inputMax, _outputMin, _outputMax, _clamp, _result);

		public override void Execute()
		{
			var inputDelta = _inputMax.Value - _inputMin.Value;

			if (Mathf.Approximately(inputDelta, 0f))
			{
				_result.Value = _outputMin.Value;
				return;
			}

			var t = (_value.Value - _inputMin.Value) / inputDelta;
			var mappedValue = _outputMin.Value + t * (_outputMax.Value - _outputMin.Value);

			if (_clamp.Value)
			{
				var min = Mathf.Min(_outputMin.Value, _outputMax.Value);
				var max = Mathf.Max(_outputMin.Value, _outputMax.Value);
				mappedValue = Mathf.Clamp(mappedValue, min, max);
			}

			_result.Value = mappedValue;
		}

		public override string GetSummary() => "Map {_value} from {_inputMin}..{_inputMax} to {_outputMin}..{_outputMax} -> {_result}";
	}
}
