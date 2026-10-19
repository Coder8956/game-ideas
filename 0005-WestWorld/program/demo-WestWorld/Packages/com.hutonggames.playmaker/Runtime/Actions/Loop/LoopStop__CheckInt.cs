using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [DisplayName("Stop Loop (Check Integer)")]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Stops the loop based on an integer condition. " +
                       "\n\nSame as Break in traditional programming.")]
    [HelpURL("actions/loop-actions/loop-stop/")]
    public class LoopStop__CheckInt : BaseAction
    {
        public override bool StopsLoop => true;

        [Tooltip("The integer variable to check.")]
        public IntegerRef Integer;

        [FormerlySerializedAs("CheckIf")]
        [Tooltip("The condition to test for.")]
        [MatchType(nameof(Integer))]
        public ConditionTest StopIf = new ();

        public override bool CanExecute() => CheckParameters(Integer);

        public override void Execute()
        {
            if (StopIf.Evaluate(Integer.Value))
            {
                BreakLoop();
            }
        }

        public override string GetSummary() => "Stop loop if {Integer} {StopIf}";
    }
}
