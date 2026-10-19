using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [DisplayName("Stop Loop (Check String)")]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Stops the loop based on a string condition. " +
                       "\n\nSame as Break in traditional programming.")]
    [HelpURL("actions/loop-actions/loop-stop/")]
    public class LoopStop__CheckString : BaseAction
    {
        public override bool StopsLoop => true;

        [Tooltip("The string variable to check.")]
        public StringRef String;

        [FormerlySerializedAs("CheckIf")]
        [Tooltip("The condition to test for.")]
        [MatchType(nameof(String))]
        public ConditionTest StopIf = new ();

        public override bool CanExecute() => CheckParameters(String);

        public override void Execute()
        {
            if (StopIf.Evaluate(String.Value))
            {
                BreakLoop();
            }
        }

        public override string GetSummary() => "Stop loop if {String} {StopIf}";
    }
}
