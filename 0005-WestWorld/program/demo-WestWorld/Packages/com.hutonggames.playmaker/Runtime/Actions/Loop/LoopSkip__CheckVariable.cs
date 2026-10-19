using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [DisplayName("Skip Loop (Check Variable)")]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Skips the rest of this loop iteration based on a variable condition and starts the next iteration of the loop. " +
                       "\n\nSame as Continue in traditional programming.")]
    [HelpURL("actions/loop-actions/loop-skip/")]
    public class LoopSkip__CheckVariable : BaseAction
    {
        public override bool SkipsLoop => true;

        [SerializeReference]
        [BaseType(typeof(object))]
        [Tooltip("The variable to check.")]
        public AnyVariableRef Variable;

        [FormerlySerializedAs("CheckIf")]
        [MatchType(nameof(Variable))]
        [Tooltip("The condition to test for.")]
        public ConditionTest SkipIf = new ();

        public override bool CanExecute() => !Variable.IsNone && CheckParameters(SkipIf);

        public override void Execute()
        {
            if (SkipIf.Evaluate(Variable.GetValue()))
            {
                CancelAndContinueLoop();
            }
        }

        public override string GetSummary() => "Skip loop if {Variable} {SkipIf}";
    }
}
