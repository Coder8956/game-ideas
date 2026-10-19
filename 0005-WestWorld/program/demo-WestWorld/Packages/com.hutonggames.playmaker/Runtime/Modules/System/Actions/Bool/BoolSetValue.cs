using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Bool)]
    [ActionDescription("Set a Bool variable's value.")]
    public class BoolSetValue : BaseAction
    {
        [DefaultName("Bool")]
        [WriteOnly, ActionTarget]
        [Tooltip("The Variable to set.")]
        public BoolRef Variable;
        
        [BoolVarDropdown]
        [Tooltip("Set the Variable to this Value.")]
        public BoolVar Value;
        
        public override bool CanExecute() => CheckParameters(Variable, Value);

        public override void Execute() => Variable.Value = Value.Value;

        public override string GetSummary() => "Set {Variable} to {Value}";
    }
}
