using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Activates/Deactivates a GameObject.<br/>Hint: Use the hierarchy to turn on/off groups of objects and behaviours.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html")]
    [MovedFrom( true,null,null,"GameObject_SetActive")]   
    public class GameObjectSetActive : BaseAction
    {
        [Tooltip("The target GameObject.")]
        public GameObjectVar GameObject;
        
        [BoolVarDropdown]
        [Tooltip("True: Activates the GameObject.\nFalse: Deactivates the GameObject.")]
        public BoolVar setActive;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            GameObject.Value.SetActive(setActive.Value);
        }

        public override string GetSummary() => "Set {GameObject} active to {setActive}";

        #if UNITY_EDITOR
        
        public override string ErrorCheck()
        {
            if (GameObject.IsConstantValue && GameObject.Value && PrefabUtility.IsPartOfPrefabAsset(GameObject.Value))
            {
                return "SetActive only works on GameObjects in the scene, not Prefabs.";
            }

            return base.ErrorCheck();
        }
        
        #endif
    }
}
