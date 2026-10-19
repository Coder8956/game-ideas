using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Reset all variables to their starting values.")]
    public class ResetAllVariables : BaseAction
    {
        public override void Execute() => Fsm.ResetVariableValues();

        public override string GetSummary() => "Reset all variables";
    }
}
