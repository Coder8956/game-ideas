using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [DisplayName("Stop Loop (Check GameObject)")]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Stops the loop based on a GameObject condition. " +
                       "\n\nSame as Break in traditional programming.")]
    [HelpURL("actions/loop-actions/loop-stop/")]
    public class LoopStop__CheckGameObject : BaseAction
    {
        public override bool StopsLoop => true;

        [Tooltip("The GameObject variable to check.")]
        public GameObjectRef GameObject;

        [FormerlySerializedAs("CheckIf")]
        [Tooltip("The condition to test for.")]
        [MatchType(nameof(GameObject))]
        public ConditionTest StopIf = new ();

        public override bool CanExecute() => GameObject is { IsNone: false };

        public override void Execute()
        {
            if (StopIf.Evaluate(GameObject.Value))
            {
                BreakLoop();
            }
        }

        public override string GetSummary() => "Stop loop if {GameObject} {StopIf}";
    }
}
