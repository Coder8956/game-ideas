using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Vector3)]
    [ConvertibleGroup("Vector3Set")]
    [ActionDescription("Set a Vector3 variable's value.")]
    public class Vector3SetValue : BaseAction
    {
        [DefaultName("Vector3")]
        [WriteOnly, ActionTarget]
        [Tooltip("The Variable to set.")]
        public Vector3Ref Variable;
        
        [Tooltip("Set the Variable to this Value.")]
        public Vector3Var Value;
        
        public override bool CanExecute() => CheckParameters(Variable, Value);

        public override void Execute() => Variable.Value = Value.Value;

        public override string GetSummary() => "Set {Variable} to {Value}";
    }
}