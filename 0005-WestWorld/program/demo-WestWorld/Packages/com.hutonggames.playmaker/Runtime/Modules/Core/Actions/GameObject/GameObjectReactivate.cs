using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GameObjectActivate")]
    [ActionDescription("Reactivates a GameObject by deactivating it and then activating it." +
                       "<br/>This is a quick way to reset a GameObject's components, for example, " +
                       "to restart all FSMs on the GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html")]
    [MovedFrom( true,null,null,"GameObject_SetActive")]   
    public class GameObjectReactivate : BaseAction
    {
        [Tooltip("The target GameObject.")]
        public GameObjectVar GameObject;
        
        public override bool CanExecute() => CheckParameters(GameObject);
        public override void Execute()
        {
            GameObject.Value.SetActive(false);
            GameObject.Value.SetActive(true);
        }

        public override string GetSummary() => "Reactivate {GameObject}";
    }
}