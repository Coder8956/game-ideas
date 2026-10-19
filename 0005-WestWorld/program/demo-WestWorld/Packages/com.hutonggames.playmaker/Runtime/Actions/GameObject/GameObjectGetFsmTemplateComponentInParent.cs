using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GetComponent")]
    [ActionDescription("Get an FSM Template Component on a GameObject, or any parent of the GameObject, optionally by FSM template used.")]
    [HelpURL("actions/gameobject-actions/fsm-component/game-object-get-fsm-template-component-in-parent/")]
    public class GameObjectGetFsmTemplateComponentInParent : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;

        [OptionalField]
        [Tooltip("Optional Fsm Template to check for.")]
        public FsmTemplateVar FsmTemplate;

        [Tooltip("Whether to include inactive parent GameObjects in the search.")]
        public BoolVar IncludeInactive;

        [WriteOnly]
        [Tooltip("Store the result in an FsmComponent variable")]
        public BaseFsmComponentRef StoreResult;

        public override void Execute()
        {
            var go = GameObject.Value;
            if (go == null) return;

            if (FsmTemplate.IsNone || FsmTemplate.Value == null)
            {
                StoreResult.Value = go.GetComponentInParent<FsmTemplateComponent>(IncludeInactive.Value);
                return;
            }

            var components = go.GetComponentsInParent<FsmTemplateComponent>(IncludeInactive.Value);
            foreach (var fsmComponent in components)
            {
                if (!fsmComponent) continue;
                if (fsmComponent.FsmTemplate == FsmTemplate.Value)
                {
                    StoreResult.Value = fsmComponent;
                    return;
                }
            }

            StoreResult.Value = null;
        }

        public override string GetSummary() =>
            "Get FSM on {GameObject} or parent" +
            (FsmTemplate.IsNotDefault() ? " with {FsmTemplate} template" : string.Empty) +
            " -> {StoreResult}" +
            (IncludeInactive.Value ? " (including inactive)" : string.Empty);
    }
}
