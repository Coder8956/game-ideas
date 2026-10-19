using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Activates/Deactivates all children of a GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html")]
    [MovedFrom( true,null,null,"GameObject_SetActive")]   
    public class GameObjectSetChildrenActive : BaseAction
    {
        [Tooltip("The target GameObject.")]
        public GameObjectVar GameObject;
        
        [BoolVarDropdown]
        [Tooltip("True: Activates children.\nFalse: Deactivates children.")]
        public BoolVar setActive;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;

            foreach (Transform child in GameObject.Value.transform)
            {
                child.gameObject.SetActive(setActive.Value);
            }
        }

        public override string GetSummary() => "Set {GameObject} children active to {setActive}";

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
