using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ConvertibleGroup("FloatOp")]
    [ActionDescription("Add to a float variable value and wrap the result between min and max.")]
    public class FloatAddWrap : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The float to add to.")]
        public FloatRef Float;

        [Tooltip("The value to add." + Strings.PerSecondNote)]
        public FloatVar Add;

        [Tooltip("The minimum wrapped value.")]
        public FloatVar Min;

        [Tooltip("The maximum wrapped value.")]
        public FloatVar Max;

        public override bool CanUsePerSecond => true;

        public override bool CanExecute() => CheckParameters(Float, Add, Min, Max);

        public override void Execute()
        {
            var min = Min.Value;
            var max = Max.Value;

            if (max < min)
            {
                (min, max) = (max, min);
            }

            if (Mathf.Approximately(min, max))
            {
                Float.Value = min;
                return;
            }

            var value = Float.Value + Add.Value * PerSecond;
            Float.Value = Mathf.Repeat(value - min, max - min) + min;
        }

        public override string GetSummary() => "Add {Add} to {Float} wrap ({Min},{Max}) {PerSecond}";
    }
}
