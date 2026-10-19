using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Integer)]
    [ConvertibleGroup("IntegerMath")]
    [ActionDescription("Add to an int variable value.")]
    public class IntegerAdd : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The integer to add to.")]
        public IntegerRef Integer;

        [Tooltip("The value to add.")]
        public IntegerVar Add;

        public override bool CanExecute() => CheckParameters(Integer, Add);

        public override void Execute() => Integer.Value += Add.Value;

        public override string GetSummary() => "Add {Add} to {Integer}";
    }
}