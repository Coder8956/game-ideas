using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [DisplayName("Skip Loop (Check Float)")]
    [ActionCategory(Category.Loop)]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Skips the rest of this loop iteration based on a float condition and starts the next iteration of the loop. " +
                       "\n\nSame as Continue in traditional programming.")]
    [HelpURL("actions/loop-actions/loop-skip/")]
    public class LoopSkip__CheckFloat : BaseAction
    {
        public override bool SkipsLoop => true;

        [Tooltip("The float variable to check.")]
        public FloatRef Float;

        [FormerlySerializedAs("CheckIf")]
        [Tooltip("The condition to test for.")]
        [MatchType(nameof(Float))]
        public ConditionTest SkipIf = new ();

        public override bool CanExecute() => CheckParameters(Float);

        public override void Execute()
        {
            if (SkipIf.Evaluate(Float.Value))
            {
                CancelAndContinueLoop();
            }
        }

        public override string GetSummary() => "Skip loop if {Float} {SkipIf}";
    }
}
