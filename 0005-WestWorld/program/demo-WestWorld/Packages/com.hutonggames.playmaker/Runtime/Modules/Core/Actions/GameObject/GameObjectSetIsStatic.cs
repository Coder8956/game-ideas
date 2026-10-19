using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Sets if a GameObject is static.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-isStatic.html")]
    public class GameObjectSetIsStatic : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The target GameObject.")]
        public GameObjectVar GameObject;
        
        [BoolVarDropdown]
        [Tooltip("Sets if the GameObject is static.")]
        public BoolVar SetIsStatic;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject, SetIsStatic)) return;
            GameObject.Value.isStatic = SetIsStatic.Value;
        }

        public override string GetSummary() => "Set {GameObject} is static to {SetIsStatic}";
    }
}
