using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [DisplayName("Stop Loop (Check Float)")]
    [ActionCategory(Category.Loop)]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Stops the loop based on a float condition. " +
                       "\n\nSame as Break in traditional programming.")]
    [HelpURL("actions/loop-actions/loop-stop/")]
    public class LoopStop__CheckFloat : BaseAction
    {
        public override bool StopsLoop => true;

        [Tooltip("The float variable to check.")]
        public FloatRef Float;

        [FormerlySerializedAs("CheckIf")]
        [Tooltip("The condition to test for.")]
        [MatchType(nameof(Float))]
        public ConditionTest StopIf = new ();

        public override bool CanExecute() => CheckParameters(Float);

        public override void Execute()
        {
            if (StopIf.Evaluate(Float.Value))
            {
                BreakLoop();
            }
        }

        public override string GetSummary() => "Stop loop if {Float} {StopIf}";
    }
}
