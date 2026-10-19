using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GetComponent")]
    [ActionDescription("Get the names of all FSMs on a GameObject.")]
    [HelpURL("actions/gameobject-actions/fsm-component/game-object-get-fsm-names/")]
    public class GameObjectGetFsmNames : BaseAction
    {
        [Tooltip("The GameObject.")] 
        public GameObjectVar GameObject;

        [WriteOnly] [Tooltip("A list of all FSM names found on the GameObject.")]
        public StringListRef GetFsmNames;

        public override bool CanExecute()
        {
            return CheckParameters(GameObject, GetFsmNames);
        }

        public override void Execute()
        {
            var go = GameObject.Value;
            if (go == null) return;
            
            GetFsmNames.Value.Clear();
            var components = go.GetComponents<BaseFsmComponent>();
            foreach (var fsmComponent in components)
            {
                GetFsmNames.Value.Add(fsmComponent.Fsm.Name);
            }
        }

        public override string GetSummary() => "Get FSM names on {GameObject} -> {GetFsmNames}";
    }
}