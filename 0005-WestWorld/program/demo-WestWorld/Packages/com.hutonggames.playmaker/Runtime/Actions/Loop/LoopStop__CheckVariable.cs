using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [DisplayName("Stop Loop (Check Variable)")]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Stops the loop based on a variable condition. " +
                       "\n\nSame as Break in traditional programming.")]
    [HelpURL("actions/loop-actions/loop-stop/")]
    public class LoopStop__CheckVariable : BaseAction
    {
        public override bool StopsLoop => true;

        [SerializeReference]
        [BaseType(typeof(object))]
        [Tooltip("The variable to check.")]
        public AnyVariableRef Variable;

        [FormerlySerializedAs("CheckIf")]
        [MatchType(nameof(Variable))]
        [Tooltip("The condition to test for.")]
        public ConditionTest StopIf = new ();

        public override bool CanExecute() => !Variable.IsNone && CheckParameters(StopIf);

        public override void Execute()
        {
            if (StopIf.Evaluate(Variable.GetValue()))
            {
                BreakLoop();
            }
        }

        public override string GetSummary() => "Stop loop if {Variable} {StopIf}";
    }
}
