using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GameObjectActivate")]
    [ActionDescription("Activates a GameObject and de-activates other GameObjects at the same level of the hierarchy." +
                       "\n\nFor example, if you have multiple UI panels under a parent, you can use this action " +
                       "to activate one panel and deactivate the others. Use it again to switch to another panel.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html")]
    public class GameObjectActivateSolo : BaseAction
    {
        [Tooltip("The target GameObject. It should have a parent, and siblings that will be deactivated.")]
        public GameObjectVar GameObject;
        
        [Tooltip("Re-activate if already active. This means deactivating the target GameObject then activating it again. " +
                 "This will reset FSMs and other components on that GameObject.")]
        public BoolVar ReactivateIfActive;
        
        public override bool CanExecute() => CheckParameters(GameObject, ReactivateIfActive);
        public override void Execute()
        {
            var go = GameObject.Value;
            if (!go || !go.transform.parent) return;

            var goTransform = go.transform;
            var parent = go.transform.parent.transform;

            foreach (Transform child in parent)
            {
                if (child != goTransform)
                {
                    child.gameObject.SetActive(false);
                }
            }

            if (ReactivateIfActive.Value && go.activeSelf)
            {
                goTransform.gameObject.SetActive(false);
            }
            
            go.SetActive(true);
        }

        public override string GetSummary() => "Activate {GameObject} solo";
    }
}
