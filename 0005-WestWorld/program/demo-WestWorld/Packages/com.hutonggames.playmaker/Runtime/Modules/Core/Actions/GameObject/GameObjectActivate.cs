using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GameObjectActivate")]
    [ActionDescription("Activates a GameObject.<br/>Hint: Use the hierarchy to turn on/off groups of objects and behaviours.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html")]
    [MovedFrom( true,null,null,"GameObject_SetActive")]   
    public class GameObjectActivate : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The target GameObject.")]
        public GameObjectVar GameObject;
        
        public override bool CanExecute() => CheckParameters(GameObject);
        public override void Execute()
        {
            if (!GameObject.Value) return;
            GameObject.Value.SetActive(true);
        }

        public override string GetSummary() => "Activate {GameObject}";
    }
}