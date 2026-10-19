using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Quaternion)]
    [ActionDescription("Set a Quaternion variable's value.")]
    public class QuaternionSetValue : BaseAction
    {
        [DefaultName("Quaternion")]
        [WriteOnly, ActionTarget]
        [Tooltip("The Variable to set.")]
        public QuaternionRef Variable;
        
        [Tooltip("Set the Variable to this Value.")]
        public QuaternionVar Value;
        
        public override bool CanExecute() => CheckParameters(Variable, Value);

        public override void Execute() => Variable.Value = Value.Value;

        public override string GetSummary() => "Set {Variable} to {Value}";
    }
}
