using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GetComponent")]
    [ActionDescription("Get an FSM Component on a GameObject, or any parent of the GameObject, optionally by FSM name.")]
    [HelpURL("actions/gameobject-actions/fsm-component/game-object-get-fsm-component-in-parent/")]
    public class GameObjectGetFsmComponentInParent : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;

        [OptionalField]
        [Tooltip("Optional name of the FSM to get.")]
        public StringVar FsmName;

        [Tooltip("Whether to include inactive parent GameObjects in the search.")]
        public BoolVar IncludeInactive;

        [WriteOnly, DefaultName("FSM")]
        [Tooltip("Store the result in an FsmComponent variable")]
        public BaseFsmComponentRef StoreResult;

        public override void Execute()
        {
            var go = GameObject.Value;
            if (go == null) return;

            StoreResult.Value = FsmHelpers.FindFsmComponentInParent(go, FsmName, IncludeInactive);
        }

        public override string GetSummary() =>
            "Get FSM on {GameObject} or parent " +
            (FsmName.IsNotDefault() ? $"named {FsmName} " : string.Empty) +
            "-> {StoreResult}" +
            (IncludeInactive.Value ? " (including inactive)" : string.Empty);
    }
}
