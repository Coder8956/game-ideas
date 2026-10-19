using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Integer)]
    [ConvertibleGroup("IntegerMath")]
    [ActionDescription("Set an Integer variable's value.")]
    public class IntegerSetValue : BaseAction
    {
        [DefaultName("Integer")]
        [WriteOnly, ActionTarget]
        [Tooltip("The Variable to set.")]
        public IntegerRef Variable;
        
        [Tooltip("Set the Variable to this Value.")]
        public IntegerVar Value;
        
        public override bool CanExecute() => CheckParameters(Variable, Value);

        public override void Execute() => Variable.Value = Value.Value;

        public override string GetSummary() => "Set {Variable} to {Value}";
    }
}
