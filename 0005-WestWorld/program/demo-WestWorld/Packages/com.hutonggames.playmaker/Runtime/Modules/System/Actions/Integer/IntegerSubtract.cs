using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Integer)]
    [ConvertibleGroup("IntegerMath")]
    [ActionDescription("Subtract from an int variable value.")]
    public class IntegerSubtract : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The integer to subtract from.")]
        public IntegerRef Integer;

        [Tooltip("The value to subtract.")]
        public IntegerVar Subtract;

        public override bool CanExecute()
        {
            return CheckParameters(Integer, Subtract);
        }

        public override void Execute()
        {
            Integer.Value -= Subtract.Value;
        }
        
        public override string GetSummary()
        {
            return "Subtract {Subtract} from {Integer}";
        }
    }
}