using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [DisplayName("Skip Loop (Check GameObject)")]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Skips the rest of this loop iteration based on a GameObject condition and starts the next iteration of the loop. " +
                       "\n\nSame as Continue in traditional programming.")]
    [HelpURL("actions/loop-actions/loop-skip/")]
    public class LoopSkip__CheckGameObject : BaseAction
    {
        public override bool SkipsLoop => true;

        [Tooltip("The GameObject variable to check.")]
        public GameObjectRef GameObject;

        [FormerlySerializedAs("CheckIf")]
        [Tooltip("The condition to test for.")]
        [MatchType(nameof(GameObject))]
        public ConditionTest SkipIf = new ();

        public override bool CanExecute() => GameObject is { IsNone: false };

        public override void Execute()
        {
            if (SkipIf.Evaluate(GameObject.Value))
            {
                CancelAndContinueLoop();
            }
        }

        public override string GetSummary() => "Skip loop if {GameObject} {SkipIf}";
    }
}
