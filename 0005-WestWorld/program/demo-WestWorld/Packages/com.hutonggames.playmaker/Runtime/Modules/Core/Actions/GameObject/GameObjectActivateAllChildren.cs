using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GameObjectActivate")]
    [ActionDescription("Activates all children of a GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html")]
    public class GameObjectActivateAllChildren : BaseAction
    {
        [Tooltip("The target GameObject.")]
        public GameObjectVar GameObject;
        
        [Tooltip("Re-activate if already active. This means deactivating the target GameObject then activating it again. " +
                 "This will reset FSMs and other components on that GameObject.")]
        public BoolVar ReactivateIfActive;
        
        public override bool CanExecute() => CheckParameters(GameObject, ReactivateIfActive);
        public override void Execute()
        {
            var go = GameObject.Value;
            if (!go) return;

            var goTransform = go.transform;
            foreach (Transform child in goTransform)
            {
                var target = child.gameObject;
                if (ReactivateIfActive.Value && target.activeSelf)
                {
                    target.gameObject.SetActive(false);
                }
            
                target.SetActive(true);
            }
        }

        public override string GetSummary() => "Activate all children of {GameObject}";
    }
}