using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Vector2)]
    [ActionDescription("Set a Vector2 variable's value.")]
    public class Vector2SetValue : BaseAction
    {
        [DefaultName("Vector2")]
        [WriteOnly, ActionTarget]
        [Tooltip("The Variable to set.")]
        public Vector2Ref Variable;
        
        [Tooltip("Set the Variable to this Value.")]
        public Vector2Var Value;
        
        public override bool CanExecute() => CheckParameters(Variable, Value);

        public override void Execute() => Variable.Value = Value.Value;

        public override string GetSummary() => "Set {Variable} to {Value}";
    }
}
