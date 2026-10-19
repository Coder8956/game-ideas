using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Integer)]
    [ConvertibleGroup("IntegerMath")]
    [ActionDescription("Add to an int variable value and wrap the result between min and max.")]
    public class IntegerAddWrap : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The integer to add to.")]
        public IntegerRef Integer;

        [Tooltip("The value to add.")]
        public IntegerVar Add;

        [Tooltip("The minimum wrapped value.")]
        public IntegerVar Min;

        [Tooltip("The maximum wrapped value.")]
        public IntegerVar Max;

        public override bool CanExecute() => CheckParameters(Integer, Add, Min, Max);

        public override void Execute()
        {
            var min = Min.Value;
            var max = Max.Value;

            if (max < min)
            {
                (min, max) = (max, min);
            }

            if (min == max)
            {
                Integer.Value = min;
                return;
            }

            var range = (long)max - min + 1;
            var value = (long)Integer.Value + Add.Value;
            var wrapped = ((value - min) % range + range) % range + min;

            Integer.Value = (int)wrapped;
        }

        public override string GetSummary() => "Add {Add} to {Integer} wrap ({Min},{Max})";
    }
}
