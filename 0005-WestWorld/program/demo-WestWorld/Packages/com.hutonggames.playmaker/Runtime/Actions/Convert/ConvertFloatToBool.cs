using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a Float to a Bool using a threshold and comparison mode.")]
    public sealed class ConvertFloatToBool : BaseAction
    {
        public enum ComparisonMode
        {
            GreaterThan,
            GreaterThanOrEqual,
            LessThan,
            LessThanOrEqual
        }

        [ActionTarget]
        [Tooltip("The Float to convert.")]
        [SerializeField]
        private FloatRef _float;

        [Tooltip("Comparison used against the Threshold.")]
        [SerializeField, DefaultValue(ComparisonMode.GreaterThanOrEqual)]
        private ComparisonMode _mode;

        [Tooltip("Threshold to compare against.")]
        [SerializeField]
        private FloatRef _threshold;

        [Tooltip("Store the converted Bool value.")]
        [SerializeField, WriteOnly]
        private BoolRef _bool;

        public override bool CanExecute() => CheckParameters(_float, _threshold, _bool);

        public override void Execute()
        {
            var value = _float.Value;
            var threshold = _threshold.Value;

            bool result;
            switch (_mode)
            {
                case ComparisonMode.GreaterThan:
                    result = value > threshold;
                    break;

                case ComparisonMode.GreaterThanOrEqual:
                    result = value >= threshold;
                    break;

                case ComparisonMode.LessThan:
                    result = value < threshold;
                    break;

                case ComparisonMode.LessThanOrEqual:
                    result = value <= threshold;
                    break;

                default:
                    result = value >= threshold;
                    break;
            }

            _bool.Value = result;
        }

        public override string GetSummary() => "Convert {_float} to bool -> {_bool}";
    }
}
