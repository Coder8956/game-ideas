using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GetComponent")]
    [ActionDescription("Get an FSM Template Component on a GameObject, optionally by FSM template used.")]
    [HelpURL("actions/gameobject-actions/fsm-component/game-object-get-fsm-template-component/")]
    public class GameObjectGetFsmTemplateComponent : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [OptionalField]
        [Tooltip("Optional Fsm Template to check for.")]
        public FsmTemplateVar FsmTemplate;
        
        [WriteOnly]
        [Tooltip("Store the result in an FsmComponent variable")]
        public BaseFsmComponentRef StoreResult;
        
        public override void Execute()
        {
            var go = GameObject.Value;
            if (go == null) return;

            if (FsmTemplate.IsNone || FsmTemplate.Value == null)
            {
                StoreResult.Value = go.GetComponent<FsmTemplateComponent>();
            }
            else
            {
                var components = go.GetComponents<FsmTemplateComponent>();
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
        }
        
        public override string GetSummary() => 
            "Get FSM on {GameObject}" +
            (FsmTemplate.IsNotDefault() ? " with {FsmTemplate} template" : string.Empty) +
            " -> {StoreResult}";
    }
}