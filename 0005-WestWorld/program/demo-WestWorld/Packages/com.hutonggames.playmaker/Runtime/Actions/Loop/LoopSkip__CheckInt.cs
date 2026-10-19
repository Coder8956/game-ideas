using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [DisplayName("Skip Loop (Check Integer)")]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Skips the rest of this loop iteration based on an integer condition and starts the next iteration of the loop. " +
                       "\n\nSame as Continue in traditional programming.")]
    [HelpURL("actions/loop-actions/loop-skip/")]
    public class LoopSkip__CheckInt : BaseAction
    {
        public override bool SkipsLoop => true;

        [Tooltip("The integer variable to check.")]
        public IntegerRef Integer;

        [FormerlySerializedAs("CheckIf")]
        [Tooltip("The condition to test for.")]
        [MatchType(nameof(Integer))]
        public ConditionTest SkipIf = new ();

        public override bool CanExecute() => CheckParameters(Integer);

        public override void Execute()
        {
            if (SkipIf.Evaluate(Integer.Value))
            {
                CancelAndContinueLoop();
            }
        }

        public override string GetSummary() => "Skip loop if {Integer} {SkipIf}";
    }
}
