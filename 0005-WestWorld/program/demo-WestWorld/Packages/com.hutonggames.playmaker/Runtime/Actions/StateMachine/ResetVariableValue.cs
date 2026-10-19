using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Reset a variable to its initial value.")]
    public class ResetVariableValue : BaseAction
    {
        [SerializeReference, WriteOnly]
        [BaseType(typeof(object))]
        [Tooltip("The Variable to reset.")]
        public AnyVariableRef Variable;
        
        public override bool CanExecute() => !Variable.IsNone;

        public override void Execute() => Fsm.ResetVariableValue(Variable.Variable);

        public override string GetSummary() => "Reset {Variable}";
    }
}