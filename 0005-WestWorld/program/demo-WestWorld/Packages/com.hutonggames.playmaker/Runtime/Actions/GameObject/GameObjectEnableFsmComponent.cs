using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("EnableFSM")]
    [ActionDescription("Enable an FSM Component on a GameObject, optionally by FSM name.")]
    [HelpURL("actions/gameobject-actions/fsm-component/game-object-enable-fsm-component/")]
    public class GameObjectEnableFsmComponent : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [OptionalField]
        [Tooltip("Optional name of the FSM to enable.")]
        public StringVar FsmName;
        
        [WriteOnly, OptionalField, DefaultName("FSM")]
        [Tooltip("Store the FsmComponent")]
        public BaseFsmComponentRef StoreFsmComponent;
        
        public override void Execute()
        {
            var go = GameObject.Value;
            if (go == null) return;

            var fsmComponent = FsmHelpers.FindFsmComponent(go, FsmName);
            if (StoreFsmComponent.IsAssigned) 
                StoreFsmComponent.Value = fsmComponent;
            
            if (fsmComponent) 
                fsmComponent.enabled = true;
        }
        
        public override string GetSummary() => 
            "Enable {FsmName:option} FSM on {GameObject} {StoreFsmComponent:output}";
    }
}