using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GetComponent")]
    [ActionDescription("Get an FSM Component on a GameObject, optionally by FSM name.")]
    [HelpURL("actions/gameobject-actions/fsm-component/game-object-get-fsm-component/")]
    public class GameObjectGetFsmComponent : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [OptionalField]
        [Tooltip("Optional name of the FSM to get.")]
        public StringVar FsmName;
        
        [WriteOnly, DefaultName("FSM")]
        [Tooltip("Store the result in a FsmComponent variable")]
        public BaseFsmComponentRef StoreResult;
        
        public override void Execute()
        {
            var go = GameObject.Value;
            if (go == null) return;

            StoreResult.Value = FsmHelpers.FindFsmComponent(go, FsmName);
        }
        
        public override string GetSummary() => 
            "Get FSM on {GameObject} " +
            (FsmName.IsNotDefault() ? $" named {FsmName} " : string.Empty) +
            " -> {StoreResult}";
    }
}