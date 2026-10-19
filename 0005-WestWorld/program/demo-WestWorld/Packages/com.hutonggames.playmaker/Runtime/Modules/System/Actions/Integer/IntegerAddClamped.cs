using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Integer)]
    [ConvertibleGroup("IntegerMath")]
    [DisplayName("Integer Add Clamp")]
    [ActionDescription("Add to an int variable value and clamp the result between min and max.")]
    public class IntegerAddClamped : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The integer to add to.")]
        public IntegerRef Integer;

        [Tooltip("The value to add.")]
        public IntegerVar Add;

        [Tooltip("The minimum value allowed after adding.")]
        public IntegerVar Min;

        [Tooltip("The maximum value allowed after adding.")]
        public IntegerVar Max;

        public override bool CanExecute() => CheckParameters(Integer, Add, Min, Max);

        public override void Execute() => Integer.Value = Mathf.Clamp(Integer.Value + Add.Value, Min.Value, Max.Value);

        public override string GetSummary() => "Add {Add} to {Integer} clamp ({Min},{Max})";
    }
}
