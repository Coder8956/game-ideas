using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ConvertibleGroup("FloatOp")]
    [DisplayName("Float Add Clamp")]
    [ActionDescription("Add to a float variable value and clamp the result between min and max.")]
    public class FloatAddClamped : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The float to add to.")]
        public FloatRef Float;

        [Tooltip("The value to add." + Strings.PerSecondNote)]
        public FloatVar Add;

        [Tooltip("The minimum value allowed after adding.")]
        public FloatVar Min;

        [Tooltip("The maximum value allowed after adding.")]
        public FloatVar Max;

        public override bool CanUsePerSecond => true;

        public override bool CanExecute() => CheckParameters(Float, Add, Min, Max);

        public override void Execute() => Float.Value = Mathf.Clamp(Float.Value + Add.Value * PerSecond, Min.Value, Max.Value);

        public override string GetSummary() => "Add {Add} to {Float} clamp ({Min},{Max}) {PerSecond}";
    }
}
