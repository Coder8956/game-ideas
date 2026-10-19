using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [DisplayName("Skip Loop (Check String)")]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Skips the rest of this loop iteration based on a string condition and starts the next iteration of the loop. " +
                       "\n\nSame as Continue in traditional programming.")]
    [HelpURL("actions/loop-actions/loop-skip/")]
    public class LoopSkip__CheckString : BaseAction
    {
        public override bool SkipsLoop => true;

        [Tooltip("The string variable to check.")]
        public StringRef String;

        [FormerlySerializedAs("CheckIf")]
        [Tooltip("The condition to test for.")]
        [MatchType(nameof(String))]
        public ConditionTest SkipIf = new ();

        public override bool CanExecute() => CheckParameters(String);

        public override void Execute()
        {
            if (SkipIf.Evaluate(String.Value))
            {
                CancelAndContinueLoop();
            }
        }

        public override string GetSummary() => "Skip loop if {String} {SkipIf}";
    }
}
