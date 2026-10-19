using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a Float to an Integer using a rounding mode.")]
    public sealed class ConvertFloatToInteger : BaseAction
    {
        public enum RoundingMode
        {
            Round,
            Floor,
            Ceil,
            Truncate
        }

        [ActionTarget]
        [Tooltip("The Float to convert.")]
        [SerializeField]
        private FloatRef _float;

        [Tooltip("How the Float should be converted.")]
        [SerializeField, DefaultValue(RoundingMode.Round)]
        private RoundingMode _mode;

        [Tooltip("Store the converted Integer value.")]
        [SerializeField, WriteOnly]
        private IntegerRef _integer;

        public override bool CanExecute() => CheckParameters(_float, _integer);

        public override void Execute()
        {
            var value = _float.Value;
            int result;

            switch (_mode)
            {
                case RoundingMode.Round:
                    result = Mathf.RoundToInt(value);
                    break;

                case RoundingMode.Floor:
                    result = Mathf.FloorToInt(value);
                    break;

                case RoundingMode.Ceil:
                    result = Mathf.CeilToInt(value);
                    break;

                case RoundingMode.Truncate:
                    result = (int)value;
                    break;

                default:
                    result = Mathf.RoundToInt(value);
                    break;
            }

            _integer.Value = result;
        }

        public override string GetSummary() => "Convert {_float} to int -> {_integer}";
    }
}