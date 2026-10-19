using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("EnableFSM")]
    [ActionDescription("Disable an FSM Component on a GameObject, optionally by FSM name.")]
    [HelpURL("actions/gameobject-actions/fsm-component/game-object-disable-fsm-component/")]
    public class GameObjectDisableFsmComponent : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [OptionalField]
        [Tooltip("Optional name of the FSM to disable.")]
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
                fsmComponent.enabled = false;
        }
        
        public override string GetSummary() => 
            "Disable {FsmName:option} FSM on {GameObject} {StoreFsmComponent:output}";
    }
}